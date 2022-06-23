using System.Collections.Immutable;

#pragma warning disable CA1822 // Mark members as static

namespace Fux.Building.AlgorithmW
{
    internal class Inferrer
    {
        /// <summary>
        /// The meat of the type inference algorithm.
        /// </summary>
        private static (Substitution, Type) InferType(Expr expression, Environment env)
        {
            switch (expression)
            {
                case DefExpression({ } variable, { } expr):
                    {
                        var (s1, t1) = InferType(variable, env);
                        var (s2, t2) = InferType(expr, env);
                        var s3 = MostGeneralUnifier(t1, t2);
                        return (ComposeSubstitutions(s3, ComposeSubstitutions(s2, s1)), ApplySubstitution(t1, s3));
                    }

                case Tuple2Expression({ } expr1, { } expr2):
                    {
                        var (s1, t1) = InferType(expr1, env);
                        var (s2, t2) = InferType(expr2, env);
                        var ty1 = ApplySubstitution(t1, s2);
                        var ty2 = t2;
                        var tuple2 = (Type)new Type.Tuple2(ty1, ty2);

                        return (ComposeSubstitutions(s2, s1), tuple2);
                    }

                case NativeExpression:
                    {
                        var type = (Type)env.Generator.GetNext();

                        return (Substitution.Empty(), type);
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
                        var env1 = env.Remove(term);
                        var (s1, t1) = InferType(expr1, env);
                        var tp = GeneralizePolytype(ApplySubstitution(env1, s1), t1);
                        var env2 = env1.Insert(term, tp);
                        var (s2, t2) = InferType(expr2, ApplySubstitution(env2, s1));
                        return (ComposeSubstitutions(s2, s1), t2);
                    }

                //
                // A variable is typed as an instantiation of the corresponding type in the
                // environment.
                //
                case Variable(var term):
                    {
                        if (env.TryGet(term) is Polytype polytype)
                        {
                            return (Substitution.Empty(), InstantiateType(polytype, env));
                        }

                        throw new WError($"unbound variable: {term}");
                    }

                //
                // A literal is typed as it's primitive type.
                //
                case Literal literal:
                    {
                        return (
                            Substitution.Empty(),
                            literal switch
                            {
                                IntegerLiteral(_) => new Type.Integer(),
                                FloatLiteral(_) => new Type.Float(),
                                BoolLiteral(_) => new Type.Bool(),
                                StringLiteral(_) => new Type.String(),
                                _ => throw new WError($"can not infer - unknown literal type '{literal}'"),
                            });
                    }

                case IffExpression({ } cond, { } expr1, { } expr2):
                    {
                        {
                            var (_, t1) = InferType(cond, env);
                            var t2 = new Type.Bool();
                            _ = MostGeneralUnifier(t1, t2);
                        }
                        {
                            var (s1, t1) = InferType(expr1, env);
                            var (s2, t2) = InferType(expr2, env);
                            var s3 = MostGeneralUnifier(t1, t2);
                            return (ComposeSubstitutions(s3, ComposeSubstitutions(s2, s1)), ApplySubstitution(t1, s3));
                        }
                    }

                // An abstraction is typed by:
                // * Removing any existing type with the same name as the argument to prevent name clashes.
                // * Inserting a new type variable for the argument.
                // * Inferring the type of the expression in the new environment to define the type of the expression.
                // * Applying the resulting substitution to the argument to define the type of the argument.
                case AbstractionExpression({ } term, { } exp):
                    {
                        var name = (env.TryGet(term)?.Type as Type.Variable)?.TypeVar.Name;

                        var varType = env.Generator.GetNext(name);
                        var nenv = env.Remove(term).Insert(term, new Polytype(varType));
                        var (substitution, type) = InferType(exp, nenv);
                        return (substitution, new Type.Function(ApplySubstitution(varType, substitution), type));
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
                        var (s1, t1) = InferType(callee, env);
                        var (s2, t2) = InferType(argument, ApplySubstitution(env, s1));
                        var varType = env.Generator.GetNext();
                        var s3 = MostGeneralUnifier(type1: ApplySubstitution(t1, s2), type2: new Type.Function(t2, varType));
                        return (ComposeSubstitutions(s3, ComposeSubstitutions(s2, s1)), ApplySubstitution(varType, s3));
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
                Type.Variable({ } tv) => substitution.TryGet(tv) ?? type,

                // To apply to a function, we simply apply to each of the input and output.
                Type.Function({ } t1, { } t2) => new Type.Function(ApplySubstitution(t1, substitution), ApplySubstitution(t2, substitution)),

                Type.Tuple2({ } t1, { } t2) => new Type.Tuple2(ApplySubstitution(t1, substitution), ApplySubstitution(t2, substitution)),

                // A primitive type is not changed by a substitution.
                Type.Primitive => type,

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
        private static Substitution MostGeneralUnifier(Type type1, Type type2)
        {
            switch (type1, type2)
            {
                // For functions, we find the most general unifier for the inputs, apply the resulting
                // substitution to the outputs, find the outputs' most general unifier, and finally
                // compose the two resulting substitutions.
                case (Type.Function({ } type1In, { } type1Out), Type.Function({ } type2In, { } type2Out)):
                    {
                        var sub1 = MostGeneralUnifier(type1In, type2In);
                        var sub2 = MostGeneralUnifier(ApplySubstitution(type1Out, sub1), ApplySubstitution(type2Out, sub1));
                        return ComposeSubstitutions(sub1, sub2);
                    }

                // If one of the types is variable, we can bind the variable to the type.
                // This also handles the case where they are both variables.
                case (Type.Variable({ } v), { } t):
                    {
                        return BindVariable(v, t);
                    }

                case ({ } t, Type.Variable({ } v)):
                    {
                        return BindVariable(v, t);
                    }

                // If they are both primitives, no substitution needs to be done.
                case
                    (Type.Integer, Type.Integer) or
                    (Type.Float, Type.Float) or
                    (Type.Bool, Type.Bool) or
                    (Type.String, Type.String) or
                    (Type.Float, Type.Integer) or
                    (Type.Integer, Type.Float):
                    {
                        return Substitution.Empty();
                    }

                // Otherwise, the types cannot be unified.
                case (var t1, var t2):
                    {
                        throw new WError($"types do not unify: {t1} vs {t2}");
                    }
            }
        }

        /// <summary>
        /// Attempt to bind a type variable to a type, returning an appropriate substitution.
        /// </summary>
        private static Substitution BindVariable(TypeVariable typeVar, Type type)
        {
            // Check for binding a variable to itself
            if (type is Type.Variable({ } u) && u == typeVar)
            {
                return Substitution.Empty();
            }

            // The occurs check prevents illegal recursive types.
            if (GetFreeTypeVariables(type).Contains(typeVar))
            {
                throw new WError($"occur check fails: {typeVar} vs {type}");
            }

            var subst = Substitution.Empty().Insert(typeVar, type);
            return subst;
        }

        private static HashSet<TypeVariable> GetFreeTypeVariables(Type type)
        {
            return type switch
            {
                // For a type variable, there is one free variable: the variable itself.
                Type.Variable({ } typeVar) => new HashSet<TypeVariable>(new[] { typeVar }),

                // For functions, we take the union of the free type variables of the input and output.
                Type.Function({ } inType, { } outType) => union(GetFreeTypeVariables(inType), GetFreeTypeVariables(outType)),

                Type.Tuple2({ } type1, { } type2) => union(GetFreeTypeVariables(type1), GetFreeTypeVariables(type2)),

                // Primitive types have no free variables
                Type.Primitive => new HashSet<TypeVariable>(),

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

        public Type Run(Expr expression, Environment typeEnvironment)
        {
            var (substitution, type) = InferType(expression, typeEnvironment);
            return ApplySubstitution(type, substitution);
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
                ("+", new Polytype(new Type.Function(number1, new Type.Function(number1, number1)))),

                // - :: number -> number -- unary negation
                ("-", new Polytype(new Type.Function(number2, number2))),

                // less-than :: number -> number -> bool
                ("<", new Polytype(new Type.Function(number3, new Type.Function(number3, new Type.Bool())))),

                // - :: integer -> float -- conversion
                ("toFloat", new Polytype(new Type.Function(new Type.Integer(), new Type.Float())))
            );
        }
    }
}
