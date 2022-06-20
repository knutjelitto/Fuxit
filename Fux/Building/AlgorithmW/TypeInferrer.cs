using System.Collections.Immutable;

#pragma warning disable CA1822 // Mark members as static

namespace Fux.Building.AlgorithmW
{
    public class TypeInferrer
    {
        /// <summary>
        /// The meat of the type inference algorithm.
        /// </summary>
        private static WResult<(Substitution, WType)> InferType(WExpr expression, WEnvironment typeEnvironment, TypeVarGenerator typeVarGenerator)
        {
            switch (expression)
            {
                // A variable is typed as an instantiation of the corresponding type in the
                // environment.
                case Variable(var term):
                    if (typeEnvironment.TryGet(term) is Polytype polytype)
                    {
                        return WResult.Ok((Substitution.Empty(), InstantiateType(polytype, typeVarGenerator)));
                    }

                    return WResult.Fail<(Substitution, WType)>(new WError($"unbound variable: {term}"));

                // A literal is typed as it's primitive type.
                case Literal literal:
                    return WResult.Ok<(Substitution, WType)>((
                            Substitution.Empty(),
                            literal switch
                            {
                                IntegerLiteral(_) => new IntegerType(),
                                FloatLiteral(_) => new FloatType(),
                                BoolLiteral(_) => new BoolType(),
                                StringLiteral(_) => new StringType(),
                                _ => throw new InvalidOperationException($"unknown literal type '{literal}'"),
                            }
                        ));

                case IffExpression({ } cond, { } expr1, { } expr2):
                    {
                        {
                            var result1 = InferType(cond, typeEnvironment, typeVarGenerator);
                            if (result1 is ((Substitution s1, WType t1), _))
                            {
                                var t2 = new BoolType();
                                var result2 = MostGeneralUnifier(t1, t2);
                                if (result2 is (_, WError error))
                                {
                                    return WResult.Fail<(Substitution, WType)>(error);
                                }
                            }
                            else
                            {
                                return result1; // error
                            }
                        }
                        {
                            var result1 = InferType(expr1, typeEnvironment, typeVarGenerator);
                            if (result1 is ((Substitution s1, WType t1), _))
                            {
                                var result2 = InferType(expr2, typeEnvironment, typeVarGenerator);
                                if (result2 is ((Substitution s2, WType t2), _))
                                {
                                    var result3 = MostGeneralUnifier(t1, t2);
                                    if (result3 is (Substitution s3, _))
                                    {
                                        return WResult.Ok((ComposeSubstitutions(s3, ComposeSubstitutions(s2, s1)), ApplySubstitution(t1, s3)));
                                    }
                                    return WResult.Fail<(Substitution, WType)>(result3.Error!);
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
                        var varType = typeVarGenerator.GetNext();
                        var env = typeEnvironment.Remove(term).Insert(term, new Polytype(varType));
                        return InferType(exp, env, typeVarGenerator) switch
                        {
                            ((Substitution substitution, WType type), _) => WResult.Ok<(Substitution, WType)>((substitution, new FunctionType(ApplySubstitution(varType, substitution), type))),
                            (_, WError error) => WResult.Fail<(Substitution, WType)>(error)
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
                        var result1 = InferType(callee, typeEnvironment, typeVarGenerator);
                        if (result1 is ((Substitution s1, WType t1), _))
                        {
                            var result2 = InferType(argument, ApplySubstitution(typeEnvironment, s1), typeVarGenerator);
                            if (result2 is ((Substitution s2, WType t2), _))
                            {
                                var varType = typeVarGenerator.GetNext();
                                var result3 = MostGeneralUnifier(type1: ApplySubstitution(t1, s2), type2: new FunctionType(t2, varType));
                                if (result3 is (Substitution s3, _))
                                {
                                    return WResult.Ok((ComposeSubstitutions(s3, ComposeSubstitutions(s2, s1)), ApplySubstitution(varType, s3)));
                                }
                                return WResult.Fail<(Substitution, WType)>(result3.Error!);
                            }
                            return result2; // error
                        }
                        return result1; // error
                    }
                // Let (variable binding) is typed by:
                // * Removing any existing type with the same name as the binding variable to prevent name clashes.
                // * Inferring the type of the binding.
                // * Applying the resulting substitution to the environment and generalizing to the binding type.
                // * Inserting the generalized type to the binding variable in the new environment.
                // * Applying the substution for the binding to the environment and inferring the type of the expression.
                case LetExpression({ } term, { } exp1, { } exp2):
                    {
                        var env1 = typeEnvironment.Remove(term);
                        var result1 = InferType(exp1, typeEnvironment, typeVarGenerator);
                        if (result1 is ((Substitution s1, WType t1), _))
                        {
                            var tp = GeneralizePolytype(ApplySubstitution(env1, s1), t1);
                            var env2 = env1.Insert(term, tp);
                            var result2 = InferType(exp2, ApplySubstitution(env2, s1), typeVarGenerator);
                            if (result2 is ((Substitution s2, WType t2), _))
                            {
                                return WResult.Ok<(Substitution, WType)>((ComposeSubstitutions(s2, s1), t2));
                            }
                            return result2; // error
                        }
                        return result1; // error
                    }

                default:
                    throw new InvalidOperationException($"unknown expression type '{expression}'");
            }
        }

        private static WType ApplySubstitution(WType type, Substitution substitution)
        {
            return type switch
            {
                // If this type references a variable that is in the substitution, return it's
                // replacement type. Otherwise, return the existing type.
                VariableType({ } tv) => substitution.TryGet(tv) ?? type,

                // To apply to a function, we simply apply to each of the input and output.
                FunctionType({ } t1, { } t2) => new FunctionType(ApplySubstitution(t1, substitution), ApplySubstitution(t2, substitution)),

                PrimitiveType => type,

                // A primitive type is not changed by a substitution.
                _ => throw new InvalidOperationException($"unexpected type '{type}'")
            };
        }

        /// <summary>
        ///  To apply a substitution, we just apply it to each polytype in the type environment.
        /// </summary>
        private static WEnvironment ApplySubstitution(WEnvironment typeEnv, Substitution substitution)
        {
            return new WEnvironment(typeEnv.Enumerate().Select(vp => (vp.var, ApplySubstitution(vp.polytype, substitution))));
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

        private static Polytype GeneralizePolytype(WEnvironment typeEnv, WType type)
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
        private static WResult<Substitution> MostGeneralUnifier(WType type1, WType type2)
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
                                return WResult.Ok(ComposeSubstitutions(sub1, sub2));
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
                case (IntegerType, IntegerType) or (FloatType, FloatType) or (BoolType, BoolType) or (StringType, StringType):
                    {
                        return WResult.Ok(Substitution.Empty());
                    }
                // Otherwise, the types cannot be unified.
                case (var t1, var t2):
                    {
                        return WResult.Fail<Substitution>(new WError($"types do not unify: {t1} vs {t2}"));
                    }
            }
        }

        /// <summary>
        /// Attempt to bind a type variable to a type, returning an appropriate substitution.
        /// </summary>
        private static WResult<Substitution> BindVariable(TypeVar typeVar, WType type)
        {
            // Check for binding a variable to itself
            if (type is VariableType({ } u) && u == typeVar)
            {
                return WResult.Ok(Substitution.Empty());
            }

            // The occurs check prevents illegal recursive types.
            if (GetFreeTypeVariables(type).Contains(typeVar))
            {
                return WResult.Fail<Substitution>(new WError($"occur check fails: {typeVar} vs {type}"));
            }

            var subst = Substitution.Empty().Insert(typeVar, type);
            return WResult.Ok(subst);
        }

        private static HashSet<TypeVar> GetFreeTypeVariables(WType type)
        {
            return type switch
            {
                // For a type variable, there is one free variable: the variable itself.
                VariableType({ } typeVar) => new HashSet<TypeVar>(new[] { typeVar }),

                // For functions, we take the union of the free type variables of the input and output.
                FunctionType({ } inType, { } outType) => union(GetFreeTypeVariables(inType), GetFreeTypeVariables(outType)),

                // Primitive types have no free variables
                PrimitiveType => new HashSet<TypeVar>(),

                _ => throw new InvalidOperationException($"unexpected type '{type}'")
            };

            static HashSet<TypeVar> union(HashSet<TypeVar> a, HashSet<TypeVar> b)
            {
                a.UnionWith(b);
                return a;
            }
        }

        /// <summary>
        /// The free type variables in a polytype are those that are free in the internal type and not bound by the variable mapping.
        /// </summary>
        private static HashSet<TypeVar> GetFreeTypeVariables(Polytype polytype)
        {
            // The free type variables in a polytype are those that are free in the internal type and not bound by the variable mapping.
            var set = GetFreeTypeVariables(polytype.Type);
            set.ExceptWith(polytype.TypeVariables);
            return set;
        }

        /// <summary>
        /// The free type variables of a type environment is the union of the free type variables of each polytype in the environment.
        /// </summary>
        private static HashSet<TypeVar> GetFreeTypeVariables(WEnvironment typeEnv)
        {
            return GetFreeTypeVariables(typeEnv.Polytypes);
        }

        /// <summary>
        /// The free type variables of a vector of types is the union of the free type variables of each of the types in the vector.
        /// </summary>
        private static HashSet<TypeVar> GetFreeTypeVariables(IEnumerable<Polytype> polytypes)
        {
            var union = new HashSet<TypeVar>();
            foreach (var polytype in polytypes)
            {
                union.UnionWith(GetFreeTypeVariables(polytype));
            }
            return union;
        }

        /// <summary>
        /// Instantiates a polytype into a type. Replaces all bound type variables with fresh type variables and return the resulting type.
        /// </summary>
        private static WType InstantiateType(Polytype polytype, TypeVarGenerator typeVarGenerator)
        {
            var newVarMap = polytype.TypeVariables.Select(typeVar => (typeVar, newVar: typeVarGenerator.GetNext())).ToImmutableDictionary(x => x.typeVar, x => (WType)x.newVar);
            var substitution = new Substitution(newVarMap);
            return ApplySubstitution(polytype.Type, substitution);
        }

        public WResult<WType> Run(WExpr expression, WEnvironment typeEnvironment, TypeVarGenerator typeVarGenerator)
        {
            return InferType(expression, typeEnvironment, typeVarGenerator) switch
            {
                ((Substitution substitution, WType type), _) => new(ApplySubstitution(type, substitution), null),
                (_, WError error) => new(null, error)
            };
        }

        public WEnvironment GetDefaultTypeEnvironment(TypeVarGenerator typeVarGenerator)
        {
            var number1 = typeVarGenerator.GetNext();
            var number2 = typeVarGenerator.GetNext();
            var number3 = typeVarGenerator.GetNext();

            return WEnvironment.Initial(

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
