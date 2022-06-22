﻿using System.Collections.Immutable;

#pragma warning disable CA1822 // Mark members as static

namespace Fux.Building.AlgorithmW
{
    internal class Inferrer
    {
        /// <summary>
        /// The meat of the type inference algorithm.
        /// </summary>
        private static WResult<(Substitution, Type)> InferType(Expr expression, Environment environment)
        {
            switch (expression)
            {
                case DefExpression({ } variable, { } expr):
                    {
                        var result1 = InferType(variable, environment);
                        if (result1 is ((Substitution s1, Type t1), _))
                        {
                            var result2 = InferType(expr, environment);
                            if (result2 is ((Substitution s2, Type t2), _))
                            {
                                var result3 = MostGeneralUnifier(t1, t2);
                                if (result3 is (Substitution s3, _))
                                {
                                    return Result.Ok((ComposeSubstitutions(s3, ComposeSubstitutions(s2, s1)), ApplySubstitution(t1, s3)));
                                }
                                return Result.Fail<(Substitution, Type)>(result3.Error!);
                            }
                            return result2; // error
                        }
                        return result1; // error
                    }

                case Tuple2Expression({ } expr1, { } expr2):
                    {
                        var result1 = InferType(expr1, environment);
                        if (result1 is ((Substitution s1, Type t1), _))
                        {
                            var result2 = InferType(expr2, environment);
                            if (result2 is ((Substitution s2, Type t2), _))
                            {
                                var ty1 = ApplySubstitution(t1, s2);
                                var ty2 = t2;
                                var tuple2 = (Type)new Tuple2Type(ty1, ty2);
                                
                                return Result.Ok((ComposeSubstitutions(s2, s1), tuple2));
                            }
                            return result2; // error
                        }
                        return result1; // error

                        break;
                    }

                case NativeExpression:
                    {
                        var type = (Type)environment.Generator.GetNext();

                        return Result.Ok((Substitution.Empty(), type));
                    }

                //
                // Let (variable binding) is typed by:
                // * Removing any existing type with the same name as the binding variable to prevent name clashes.
                // * Inferring the type of the binding.
                // * Applying the resulting substitution to the environment and generalizing to the binding type.
                // * Inserting the generalized type to the binding variable in the new environment.
                // * Applying the substution for the binding to the environment and inferring the type of the expression.
                //
                case LetExpression({ } term, { } expr1, { } expr2):
                    {
                        var env1 = environment.Remove(term);
                        var result1 = InferType(expr1, environment);
                        if (result1 is ((Substitution s1, Type t1), _))
                        {
                            var tp = GeneralizePolytype(ApplySubstitution(env1, s1), t1);
                            var env2 = env1.Insert(term, tp);
                            var result2 = InferType(expr2, ApplySubstitution(env2, s1));
                            if (result2 is ((Substitution s2, Type t2), _))
                            {
                                return Result.Ok<(Substitution, Type)>((ComposeSubstitutions(s2, s1), t2));
                            }
                            return result2; // error
                        }
                        return result1; // error
                    }

                //
                // A variable is typed as an instantiation of the corresponding type in the
                // environment.
                //
                case Variable(var term):
                    {
                        if (environment.TryGet(term) is Polytype polytype)
                        {
                            return Result.Ok((Substitution.Empty(), InstantiateType(polytype, environment)));
                        }

                        return Result.Fail<(Substitution, Type)>(new Error($"unbound variable: {term}"));
                    }

                //
                // A literal is typed as it's primitive type.
                //
                case Literal literal:
                    {
                        return Result.Ok<(Substitution, Type)>((
                                Substitution.Empty(),
                                literal switch
                                {
                                    IntegerLiteral(_) => new IntegerType(),
                                    FloatLiteral(_) => new FloatType(),
                                    BoolLiteral(_) => new BoolType(),
                                    StringLiteral(_) => new StringType(),
                                    _ => throw new InvalidOperationException($"can not infer - unknown literal type '{literal}'"),
                                }
                            ));
                    }

                case IffExpression({ } cond, { } expr1, { } expr2):
                    {
                        {
                            var result1 = InferType(cond, environment);
                            if (result1 is ((Substitution _, Type t1), _))
                            {
                                var t2 = new BoolType();
                                var result2 = MostGeneralUnifier(t1, t2);
                                if (result2 is (_, Error error))
                                {
                                    return Result.Fail<(Substitution, Type)>(error); // error
                                }
                            }
                            else
                            {
                                return result1; // error
                            }
                        }
                        {
                            var result1 = InferType(expr1, environment);
                            if (result1 is ((Substitution s1, Type t1), _))
                            {
                                var result2 = InferType(expr2, environment);
                                if (result2 is ((Substitution s2, Type t2), _))
                                {
                                    var result3 = MostGeneralUnifier(t1, t2);
                                    if (result3 is (Substitution s3, _))
                                    {
                                        return Result.Ok((ComposeSubstitutions(s3, ComposeSubstitutions(s2, s1)), ApplySubstitution(t1, s3)));
                                    }
                                    return Result.Fail<(Substitution, Type)>(result3.Error!);
                                }
                                return result2; // error
                            }
                            return result1; // error
                        }
                    }

                // An abstraction is typed by:
                // * Removing any existing type with the same name as the argument to prevent name clashes.
                // * Inserting a new type variable for the argument.
                // * Inferring the type of the expression in the new environment to define the type of the expression.
                // * Applying the resulting substitution to the argument to define the type of the argument.
                case AbstractionExpression({ } term, { } exp):
                    {
                        var name = (environment.TryGet(term)?.Type as VariableType)?.TypeVar.Name;

                        var varType = environment.Generator.GetNext(name);
                        var env = environment.Remove(term).Insert(term, new Polytype(varType));
                        return InferType(exp, env) switch
                        {
                            ((Substitution substitution, Type type), _) => Result.Ok<(Substitution, Type)>((substitution, new FunctionType(ApplySubstitution(varType, substitution), type))),
                            (_, Error error) => Result.Fail<(Substitution, Type)>(error)
                        };
                    }

                // An application is typed by:
                // * Inferring the type of the callee.
                // * Applying the resulting substitution to the argument and inferring it's type.
                // * Finding the most general unifier for the callee type and a function from the
                // argument type to a new type variable. This combines the previously known type of the
                // function and the type as it is now being used.
                // * Applying the unifier to the new type variable.
                case ApplicationExpression({ } callee, { } argument):
                    {
                        var result1 = InferType(callee, environment);
                        if (result1 is ((Substitution s1, Type t1), _))
                        {
                            var result2 = InferType(argument, ApplySubstitution(environment, s1));
                            if (result2 is ((Substitution s2, Type t2), _))
                            {
                                var varType = environment.Generator.GetNext();
                                var result3 = MostGeneralUnifier(type1: ApplySubstitution(t1, s2), type2: new FunctionType(t2, varType));
                                if (result3 is (Substitution s3, _))
                                {
                                    return Result.Ok((ComposeSubstitutions(s3, ComposeSubstitutions(s2, s1)), ApplySubstitution(varType, s3)));
                                }
                                return Result.Fail<(Substitution, Type)>(result3.Error!);
                            }
                            return result2; // error
                        }
                        return result1; // error
                    }
            }
            throw new InvalidOperationException($"can not infer - unknown expression type '{expression.GetType().Name} - {expression}'");
        }

        private static Type ApplySubstitution(Type type, Substitution substitution)
        {
            return type switch
            {
                // If this type references a variable that is in the substitution, return it's
                // replacement type. Otherwise, return the existing type.
                VariableType({ } tv) => substitution.TryGet(tv) ?? type,

                // To apply to a function, we simply apply to each of the input and output.
                FunctionType({ } t1, { } t2) => new FunctionType(ApplySubstitution(t1, substitution), ApplySubstitution(t2, substitution)),

                // A primitive type is not changed by a substitution.
                PrimitiveType => type,

                _ => throw new InvalidOperationException($"can not infer - unknown type '{type.GetType().FullName} - {type}'")
            };
        }

        /// <summary>
        ///  To apply a substitution, we just apply it to each polytype in the type environment.
        /// </summary>
        private static Environment ApplySubstitution(Environment typeEnv, Substitution substitution)
        {
            return new Environment(typeEnv.Generator, typeEnv.Enumerate().Select(vp => (vp.var, ApplySubstitution(vp.polytype, substitution))));
        }

        private static Polytype ApplySubstitution(Polytype polytype, Substitution substitution)
        {
            var sub = substitution;
            foreach (var tv in polytype.TypeVariables)
            {
                sub = sub.Remove(tv);
            }
            return new Polytype(polytype.TypeVariables, ApplySubstitution(polytype.Type, sub));
        }

        private static Polytype GeneralizePolytype(Environment typeEnv, Type type)
        {
            return new Polytype(GetFreeTypeVariables(type).Except(GetFreeTypeVariables(typeEnv)).ToList(), type);
        }

        /// <summary>
        /// To compose two substitutions, we apply s1 to each type in s2 and union the resulting substitution with s1.
        /// </summary>
        private static Substitution ComposeSubstitutions(Substitution s1, Substitution s2)
        {
            var map = s2.Enumerate().Select(kv => (typeVar: kv.Key, type: ApplySubstitution(kv.Value, s1))).ToImmutableDictionary(x => x.typeVar, x => x.type);
            return s1.UnionWith(new Substitution(map));
        }

        /// <summary>
        /// Most general unifier, a substitution S such that S(self) is congruent to S(other).
        /// </summary>
        private static WResult<Substitution> MostGeneralUnifier(Type type1, Type type2)
        {
            switch (type1, type2)
            {
                // For functions, we find the most general unifier for the inputs, apply the resulting
                // substitution to the outputs, find the outputs' most general unifier, and finally
                // compose the two resulting substitutions.
                case (FunctionType({ } type1In, { } type1Out), FunctionType({ } type2In, { } type2Out)):
                    {
                        var result1 = MostGeneralUnifier(type1In, type2In);
                        if (result1 is (Substitution sub1, _))
                        {
                            var result2 = MostGeneralUnifier(ApplySubstitution(type1Out, sub1), ApplySubstitution(type2Out, sub1));
                            if (result2 is (Substitution sub2, _))
                            {
                                return Result.Ok(ComposeSubstitutions(sub1, sub2));
                            }
                            else
                            {
                                return result2; // error
                            }
                        }
                        else
                        {
                            return result1; // error
                        }
                    }
                // If one of the types is variable, we can bind the variable to the type.
                // This also handles the case where they are both variables.
                case (VariableType({ } v), { } t):
                    {
                        return BindVariable(v, t);
                    }
                case ({ } t, VariableType({ } v)):
                    {
                        return BindVariable(v, t);
                    }

                // If they are both primitives, no substitution needs to be done.
                case
                    (IntegerType, IntegerType) or
                    (FloatType, FloatType) or
                    (BoolType, BoolType) or
                    (StringType, StringType) or
                    (FloatType, IntegerType) or
                    (IntegerType, FloatType):
                    {
                        return Result.Ok(Substitution.Empty());
                    }

                // Otherwise, the types cannot be unified.
                case (var t1, var t2):
                    {
                        return Result.Fail<Substitution>(new Error($"types do not unify: {t1} vs {t2}"));
                    }
            }
        }

        /// <summary>
        /// Attempt to bind a type variable to a type, returning an appropriate substitution.
        /// </summary>
        private static WResult<Substitution> BindVariable(TypeVariable typeVar, Type type)
        {
            // Check for binding a variable to itself
            if (type is VariableType({ } u) && u == typeVar)
            {
                return Result.Ok(Substitution.Empty());
            }

            // The occurs check prevents illegal recursive types.
            if (GetFreeTypeVariables(type).Contains(typeVar))
            {
                return Result.Fail<Substitution>(new Error($"occur check fails: {typeVar} vs {type}"));
            }

            var subst = Substitution.Empty().Insert(typeVar, type);
            return Result.Ok(subst);
        }

        private static HashSet<TypeVariable> GetFreeTypeVariables(Type type)
        {
            return type switch
            {
                // For a type variable, there is one free variable: the variable itself.
                VariableType({ } typeVar) => new HashSet<TypeVariable>(new[] { typeVar }),

                // For functions, we take the union of the free type variables of the input and output.
                FunctionType({ } inType, { } outType) => union(GetFreeTypeVariables(inType), GetFreeTypeVariables(outType)),

                // Primitive types have no free variables
                PrimitiveType => new HashSet<TypeVariable>(),

                _ => throw new InvalidOperationException($"unexpected type '{type}'")
            };

            static HashSet<TypeVariable> union(HashSet<TypeVariable> a, HashSet<TypeVariable> b)
            {
                a.UnionWith(b);
                return a;
            }
        }

        /// <summary>
        /// The free type variables in a polytype are those that are free in the internal type and not bound by the variable mapping.
        /// </summary>
        private static HashSet<TypeVariable> GetFreeTypeVariables(Polytype polytype)
        {
            // The free type variables in a polytype are those that are free in the internal type and not bound by the variable mapping.
            var set = GetFreeTypeVariables(polytype.Type);
            set.ExceptWith(polytype.TypeVariables);
            return set;
        }

        /// <summary>
        /// The free type variables of a type environment is the union of the free type variables of each polytype in the environment.
        /// </summary>
        private static HashSet<TypeVariable> GetFreeTypeVariables(Environment typeEnv)
        {
            return GetFreeTypeVariables(typeEnv.Polytypes);
        }

        /// <summary>
        /// The free type variables of a vector of types is the union of the free type variables of each of the types in the vector.
        /// </summary>
        private static HashSet<TypeVariable> GetFreeTypeVariables(IEnumerable<Polytype> polytypes)
        {
            var union = new HashSet<TypeVariable>();
            foreach (var polytype in polytypes)
            {
                union.UnionWith(GetFreeTypeVariables(polytype));
            }
            return union;
        }

        /// <summary>
        /// Instantiates a polytype into a type. Replaces all bound type variables with fresh type variables and return the resulting type.
        /// </summary>
        private static Type InstantiateType(Polytype polytype, Environment environment)
        {
            var newVarMap = polytype.TypeVariables.Select(typeVar => (typeVar, newVar: environment.Generator.GetNext(typeVar.Name))).ToImmutableDictionary(x => x.typeVar, x => (Type)x.newVar);
            var substitution = new Substitution(newVarMap);
            return ApplySubstitution(polytype.Type, substitution);
        }

        public WResult<Type> Run(Expr expression, Environment typeEnvironment)
        {
            return InferType(expression, typeEnvironment) switch
            {
                ((Substitution substitution, Type type), _) => new(ApplySubstitution(type, substitution), null),
                (_, Error error) => new(null, error)
            };
        }

        public Environment GetEmptyEnvironment()
        {
            return Environment.Initial(new TypeVarGenerator());
        }

        public Environment GetDefaultEnvironment(TypeVarGenerator typeVarGenerator)
        {
            var number1 = typeVarGenerator.GetNext("number");
            var number2 = typeVarGenerator.GetNext("number");
            var number3 = typeVarGenerator.GetNext("number");

            return Environment.Initial(typeVarGenerator,

                // + :: number -> number -> number -- binary addition
                ("+", new Polytype(new FunctionType(number1, new FunctionType(number1, number1)))),

                // - :: number -> number -- unary negation
                ("-", new Polytype(new FunctionType(number2, number2))),

                // less-than :: number -> number -> bool
                ("<", new Polytype(new FunctionType(number3, new FunctionType(number3, new BoolType())))),

                // - :: integer -> float -- conversion
                ("toFloat", new Polytype(new FunctionType(new IntegerType(), new FloatType())))
            );
        }
    }
}