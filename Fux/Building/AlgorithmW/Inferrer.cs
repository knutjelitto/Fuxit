using System.Collections.Immutable;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0066 // Convert switch statement to expression
#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Fux.Building.AlgorithmW
{
    public sealed class Inferrer
    {
        public bool Investigated { get; private set; } = false;

        public Type Run(Environment env, Expr expression, bool investigated)
        {
            Investigated = investigated;

            if (Investigated)
            {
                Assert(true);
            }
            var (substitution, type) = InferType(expression, env);
            return ApplySubstitution(type, substitution);
        }

        public Environment GetEmptyEnvironment()
        {
            return Environment.Initial(new TypeVarGenerator());
        }

        private (Substitution, TType) InferType<TType>(Expr expression, Environment env)
            where TType : Type
        {
            return ((Substitution, TType))InferType(expression, env);
        }

        /// <summary>
        /// The meat of the type inference algorithm.
        /// </summary>
        private (Substitution, Type) InferType(Expr expression, Environment env)
        {
            if (Investigated)
            {
                Assert(true);
            }

            switch (expression)
            {
                case Expr.Unify({ } expr, { } type):
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var typee = InstantiateType(type, env);

                        var (s1, type2) = InferType(expr, env);
                        var s2 = MostGeneralUnifier(typee, type2);
                        return (ComposeSubstitutions(s2, s1), ApplySubstitution(typee, s2));
                    }

                case Expr.Tuple2({ } expr1, { } expr2):
                    {
                        var (s1, t1) = InferType(expr1, env);
                        var (s2, t2) = InferType(expr2, env);
                        var ty1 = ApplySubstitution(t1, s2);
                        var ty2 = t2;
                        var tuple2 = (Type)new Type.Tuple2(ty1, ty2);

                        return (ComposeSubstitutions(s2, s1), tuple2);
                    }

                case Expr.Tuple3({ } expr1, { } expr2, { } expr3):
                    {
                        var (s1, t1) = InferType(expr1, env);
                        var (s2, t2) = InferType(expr2, ApplySubstitution(env, s1));
                        var ty1 = ApplySubstitution(t1, s2);
                        var ty2 = t2;
                        var tuple2 = (Type)new Type.Tuple2(ty1, ty2);

                        return (ComposeSubstitutions(s2, s1), tuple2);
                    }

                case Expr.Native:
                    {
                        var type = (Type)env.GetNextTypeVar();

                        return (Substitution.Empty(), type);
                    }

                case Expr.Wildcard:
                    {
                        var type = (Type)env.GetNextTypeVar();

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
                case Expr.Let({ } term, { } expr1, { } expr2):
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

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
                case Expr.Variable({ } term):
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
                case Expr.Literal literal:
                    {
                        return (Substitution.Empty(), literal.Type);
                    }

                case Expr.Iff({ } cond, { } expr1, { } expr2):
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        {
                            var (s1, type1) = InferType(cond, env);
                            var type2 = Type.Bool.Instance;
                            var s2 = MostGeneralUnifier(type1, type2);
                        }
                        {
                            var (s3, type3) = InferType(expr1, env);
                            var (s4, type4) = InferType(expr2, env);
                            var s5 = MostGeneralUnifier(type3, type4);
                            return (ComposeSubstitutions(s5, s4, s3), ApplySubstitution(type3, s5));
                        }
                    }

                // An abstraction is typed by:
                // * Removing any existing type with the same name as the argument to prevent name clashes.
                // * Inserting a new type variable for the argument.
                // * Inferring the type of the expression in the new environment to define the type of the expression.
                // * Applying the resulting substitution to the argument to define the type of the argument.
                case Expr.Lambda({ } term, { } expr):
                    {
                        var typeVariable = env.GetNextTypeVar();
                        var nenv = env.Remove(term).Insert(term, new Polytype(typeVariable));
                        var (substitution, type) = InferType(expr, nenv);
                        return (substitution, new Type.Function(ApplySubstitution(typeVariable, substitution), type));
                    }

                // An application is typed by:
                // * Inferring the type of the callee.
                // * Applying the resulting substitution to the argument and inferring it's type.
                // * Finding the most general unifier for the callee type and a function from the
                // argument type to a new type variable. This combines the previously known type of the
                // function and the type as it is now being used.
                // * Applying the unifier to the new type variable.
                case Expr.Application({ } callee, { } argument):
                    {
                        var (s1, t1) = InferType(callee, env);
                        var (s2, t2) = InferType(argument, ApplySubstitution(env, s1));

                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var varType = env.GetNextTypeVar();
                        var t3 = ApplySubstitution(t1, s2);
                        var s3 = MostGeneralUnifier(t1, new Type.Function(t2, varType));
                        return (ComposeSubstitutions(s3, s2, s1), ApplySubstitution(varType, s3));
                    }

                case Expr.Empty: // the empty list [] / alias list bottom
                    {
                        return (Substitution.Empty(), new Type.List(env.GetNextTypeVar()));
                    }

                case Expr.Cons({ } first, { } rest):
                    {
                        var (s1, firstType) = InferType(first, env);
                        var (s2, restType) = InferType<Type.List>(rest, ApplySubstitution(env, s1));

                        var s3 = MostGeneralUnifier(restType.Type, firstType);

                        return (ComposeSubstitutions(s3, s2, s1), ApplySubstitution(restType, s3));
                    }

                case Expr.Matcher({ } expr, { } cases):
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var (s1, t1) = InferType(expr, env);

                        Type? type = null;

                        foreach (var cheese in cases)
                        {
                            var (s2, t2) = InferType(cheese.Pattern, ApplySubstitution(env, s1));

                            var s3 = MostGeneralUnifier(t1, t2);

                            t1 = ApplySubstitution(t1, s3);
                            t2 = ApplySubstitution(t1, s3);

                            s1 = ComposeSubstitutions(s3, s2, s1);

                            var (s4, t4) = InferType(cheese.Expr, ApplySubstitution(env, s1));

                            s1 = ComposeSubstitutions(s4, s1);

                            if (type != null)
                            {
                                var s5 = MostGeneralUnifier(type, t4);
                                type = ApplySubstitution(t4, s5);
                                s1 = ComposeSubstitutions(s5, s1);
                            }
                            else
                            {
                                type = ApplySubstitution(t4, s1);
                            }
                        }

                        Assert(type != null);

                        return (s1, type);
                    }

                case Expr.Case({ } cenv, { } pattern, { } expr):
                    {
                        break;
                    }

                case Expr.DeCons({ } first, { } rest):
                    {
                        var type = env.GetNextTypeVar();
                        return (Substitution.Empty(), new Type.List(type));
                    }

                case Expr.DeCtor({ } first, { } arguments):
                    {
                        Assert(first is Expr.Variable);

                        var type = env.GetNextTypeVar();
                        return (Substitution.Empty(), type);
                    }

                case Expr.DeVariable({ } var):
                    {
                        Assert(var is Expr.Variable);

                        var type = env.GetNextTypeVar();
                        return (Substitution.Empty(), type);
                    }

                case Expr.Unit:
                    {
                        var type = new Type.Unit();
                        return (Substitution.Empty(), type);
                    }

                case Expr.GetValue({ } expr, { } typeGen, { } index):
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }
                        var (s1, t1) = InferType(expr, env);

                        if (t1 is Type.Custom concrete)
                        {
                            var type = InstantiateType(typeGen(env), env);

                            return (s1, type);
                        }

                        var t2 = InstantiateType(typeGen(env), env);
                        Assert(t2 is WithStructure);
                        var s2 = MostGeneralUnifier(t1, t2);
                        var (s3, t3) = InferType(expr, ApplySubstitution(env, s2));

                        Assert(t2.GetType() == t3.GetType());

                        var s = ComposeSubstitutions(s3, s2, s1);
                        var t = ((WithStructure)t3).At(index);

                        return (s, t);
                    }

                case Expr.GetValue2({ } expr, { } typeGen, { } index):
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        var type = InstantiateType(typeGen(env, index), env);

                        return (Substitution.Empty(), type);
                    }
                case Expr.Record record:
                    {
                        //TODO: @base
                        Assert(record.Base == null);

                        var typeFields = new List<Type.Field>();

                        var subst = Substitution.Empty();

                        foreach (var field in record.Fields)
                        {
                            if (field.Value != null)
                            {
                                var name = field.Name;

                                var (s, type) = InferType(field.Value, ApplySubstitution(env, subst));
                                var typeField = new Type.Field(name, type);

                                subst = ComposeSubstitutions(subst, s);
                                typeFields.Add(typeField);
                            }
                        }

                        var recordType = new Type.Record(typeFields);

                        return (subst, recordType);
                    }

                case Expr.Ctor({ } first, { } arguments) ctor:
                    {
                        Assert(false);

                        var subst = Substitution.Empty();

                        var types = new List<Type>();

                        foreach (var expr in arguments)
                        {
                            var (s, type) = InferType(expr, ApplySubstitution(env, subst));

                            subst = ComposeSubstitutions(subst, s);
                            types.Add(type);
                        }

                        //var c = new Type.Custom()

                        break;
                    }
            }

            throw new InvalidOperationException($"can not infer - unknown expression type '{expression.GetType().Name} - {expression}'");
        }

        private Type ApplySubstitution(Type type, Substitution substitution)
        {
            switch (type)
            {
                // If this type references a variable that is in the substitution, return it's
                // replacement type. Otherwise, return the existing type.
                case Type.Variable({ } tv):
                    return substitution.TryGet(tv) ?? type;

                // To apply to a function, we simply apply to each of the input and output.
                case Type.Function({ } t1, { } t2):
                    return new Type.Function(
                        ApplySubstitution(t1, substitution),
                        ApplySubstitution(t2, substitution));

                case Type.Tuple2({ } t1, { } t2):
                    return new Type.Tuple2(
                        ApplySubstitution(t1, substitution),
                        ApplySubstitution(t2, substitution));

                case Type.Tuple3({ } t1, { } t2, { } t3):
                    return new Type.Tuple3(
                        ApplySubstitution(t1, substitution),
                        ApplySubstitution(t2, substitution),
                        ApplySubstitution(t3, substitution));

                case Type.List({ } tl):
                    return new Type.List(ApplySubstitution(tl, substitution));

                case Type.Record({ } fields):
                    {
                        var newFields = new List<Type.Field>();

                        foreach (var field in fields)
                        {
                            var newField = new Type.Field(field.Name, ApplySubstitution(field.Type, substitution));
                            newFields.Add(newField);
                        }

                        return new Type.Record(newFields);
                    }

                // A primitive type is not changed by a substitution.
                case Type.Integer:
                case Type.Float:
                case Type.Bool:
                case Type.String:
                case Type.Char:
                case Type.Unit:
                    return type;

                // A concrete type is not changed by a substitution.
                case Type.Custom:
                    return type;

                default:
                    throw new InvalidOperationException($"can not infer - unknown type '{type.GetType().FullName} - {type}'");
            };
        }

        /// <summary>
        /// To apply a substitution, we just apply it to each polytype in the type environment.
        /// </summary>
        private Environment ApplySubstitution(Environment env, Substitution substitution)
        {
            return Environment.From(env, env.Enumerate().Select(vp => (vp.var, ApplySubstitution(vp.polytype, substitution))));
        }

        private Polytype ApplySubstitution(Polytype polytype, Substitution substitution)
        {
            var subst = substitution.RemoveRange(polytype.TypeVariables);
            return new Polytype(ApplySubstitution(polytype.Type, subst), polytype.TypeVariables);
        }

        private Polytype GeneralizePolytype(Environment env, Type type)
        {
            return new Polytype(type, GetFreeTypeVariables(type).Except(GetFreeTypeVariables(env)).ToList());
        }

        /// <summary>
        /// To compose two substitutions, we apply s1 to each type in s2 and union the resulting substitution with s1.
        /// </summary>
        private Substitution ComposeSubstitutions(params Substitution[] substitutions)
        {
            Assert(substitutions.Length >= 2);

            var composed = substitutions[0];

            for (var i = 1; i < substitutions.Length; i++)
            {
#if true
                var pairs = substitutions[i].Enumerate().Select(kv => (kv.Key, ApplySubstitution(kv.Value, composed)));
                composed = composed.UnionWith(pairs);
#else
                var map = substitutions[i].Enumerate().Select(kv => (typeVar: kv.Key, type: ApplySubstitution(kv.Value, composed))).ToImmutableDictionary(x => x.typeVar, x => x.type);
                composed = composed.UnionWith(new Substitution(map));
#endif
            }

            return composed;
        }

        /// <summary>
        /// Most general unifier, a substitution S such that S(self) is congruent to S(other).
        /// </summary>
        private Substitution MostGeneralUnifier(Type type1, Type type2)
        {
            if (Investigated)
            {
                Assert(true);
            }

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

                // For 2-tuples, we find the most general unifier for the first types, apply the resulting
                // substitution to the second types, find the seconds' most general unifier, and finally
                // compose the two resulting substitutions.
                case (Type.Tuple2({ } type11, { } type12), Type.Tuple2({ } type21, { } type22)):
                    {
                        var sub1 = MostGeneralUnifier(type11, type21);
                        var sub2 = MostGeneralUnifier(ApplySubstitution(type12, sub1), ApplySubstitution(type22, sub1));
                        return ComposeSubstitutions(sub1, sub2);
                    }


                // If one of the types is variable, we can bind the variable to the type.
                // This also handles the case where they are both variables.
                case (Type.Variable({ } v1) t1, Type.Variable({ } v2) t2):
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        if (v1.ID > v2.ID)
                        {
                            return BindVariable(v1, t2);
                        }
                        else
                        {
                            return BindVariable(v2, t1);
                        }
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
                    (Type.Char, Type.Char) or
                    (Type.Float, Type.Integer) or
                    (Type.Integer, Type.Float):
                    {
                        return Substitution.Empty();
                    }

                case (Type.Primitive p1, Type.Primitive p2) when p1.Name == p2.Name:
                    {
                        return Substitution.Empty();
                    }

                case (Type.Custom c1, Type.Custom c2):
                    {
                        if (Investigated)
                        {
                            Assert(true);
                        }

                        if (c1.Name == c2.Name && c1.Arguments.Count == c2.Arguments.Count)
                        {
                            var subst = Substitution.Empty();

                            for (var i = 0; i < c1.Arguments.Count; i++)
                            {
                                subst = ComposeSubstitutions(subst, MostGeneralUnifier(c1.Arguments[i], c2.Arguments[i]));
                            }

                            return subst;
                        }
                        break;
                    }

                case (Type.Record rec1, Type.Record rec2):
                    {
                        var matchingNames = new HashSet<string>();
                        matchingNames.UnionWith(rec1.Fields.Select(f => f.Name));
                        matchingNames.UnionWith(rec2.Fields.Select(f => f.Name));
                        Assert(rec1.Fields.Count == matchingNames.Count);
                        Assert(rec2.Fields.Count == matchingNames.Count);

                        var subst = Substitution.Empty();

                        foreach (var name in matchingNames)
                        {
                            var field1 = rec1.Fields.Where(f => f.Name == name).Single();
                            var field2 = rec2.Fields.Where(f => f.Name == name).Single();

                            subst = ComposeSubstitutions(subst, MostGeneralUnifier(field1.Type, field2.Type));
                        }

                        return subst;
                    }

                case (Type.List({ } typ1) c1, Type.List({ } typ2) c2):
                    {
                        return MostGeneralUnifier(typ1, typ2);
                    }

                // Otherwise, the types cannot be unified.
                default:
                    
                    break;
            }

            Assert(true);
            if (type1 == type2)
            {
                throw new WError($"types do not unify: {type1} vs {type2}");
            }
            else
            {
                throw new WError($"types do not unify: {type1.GetType().FullName}({type1}) vs {type2.GetType().FullName}({type2})");
            }
        }

        /// <summary>
        /// Attempt to bind a type variable to a type, returning an appropriate substitution.
        /// </summary>
        private Substitution BindVariable(TypeVariable typeVar, Type type)
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

            var subst = Substitution.Solo(typeVar, type);
            return subst;
        }

        private HashSet<TypeVariable> GetFreeTypeVariables(Type type)
        {
            switch (type)
            {
                // For a type variable, there is one free variable: the variable itself.
                case Type.Variable({ } typeVar):
                    return new HashSet<TypeVariable>(new[] { typeVar });

                // For functions, we take the union of the free type variables of the input and output.
                case Type.Function({ } inType, { } outType):
                    return union(GetFreeTypeVariables(inType), GetFreeTypeVariables(outType));

                case Type.Tuple2({ } type1, { } type2):
                    return union(GetFreeTypeVariables(type1), GetFreeTypeVariables(type2));

                case Type.Tuple3({ } type1, { } type2, { } type3):
                    return union(union(GetFreeTypeVariables(type1), GetFreeTypeVariables(type2)), GetFreeTypeVariables(type3));

                // Primitive types have no free variables
                case Type.Primitive:
                    return new HashSet<TypeVariable>();

                // Concrete types have no free variables
                case Type.Custom:
                    return new HashSet<TypeVariable>();

                case Type.List list:
                    {
                        return new HashSet<TypeVariable>(GetFreeTypeVariables(list.Type));
                    }

                case Type.Record({ } fields):
                    {
                        var free = new HashSet<TypeVariable>();
                        foreach (var field in fields)
                        {
                            free = union(free, GetFreeTypeVariables(field.Type));
                        }
                        return free;
                    }

                default:
                    break;
            };

            throw new InvalidOperationException($"unexpected type '{type}'");

            static HashSet<TypeVariable> union(HashSet<TypeVariable> a, HashSet<TypeVariable> b)
            {
                a.UnionWith(b);
                return a;
            }
        }

        /// <summary>
        /// The free type variables in a polytype are those that are free in the internal type and
        /// not bound by the variable mapping.
        /// </summary>
        private HashSet<TypeVariable> GetFreeTypeVariables(Polytype polytype)
        {
            // The free type variables in a polytype are those that are free in the internal type and not bound by the variable mapping.
            var set = GetFreeTypeVariables(polytype.Type);
            set.ExceptWith(polytype.TypeVariables);
            return set;
        }

        /// <summary>
        /// The free type variables of a type environment is the union of the free type variables
        /// of each polytype in the environment.
        /// </summary>
        private HashSet<TypeVariable> GetFreeTypeVariables(Environment typeEnv)
        {
            return GetFreeTypeVariables(typeEnv.Polytypes);
        }

        /// <summary>
        /// The free type variables of a vector of types is the union of the free type variables of
        /// each of the types in the vector.
        /// </summary>
        private HashSet<TypeVariable> GetFreeTypeVariables(IEnumerable<Polytype> polytypes)
        {
            var union = new HashSet<TypeVariable>();
            foreach (var polytype in polytypes)
            {
                union.UnionWith(GetFreeTypeVariables(polytype));
            }
            return union;
        }

        /// <summary>
        /// Instantiates a polytype into a type. Replaces all bound type variables with fresh type
        /// variables and return the resulting type.
        /// </summary>
        private Type InstantiateType(Polytype polytype, Environment env)
        {
            var newVarMap = polytype.TypeVariables.Select(typeVar => (typeVar, newVar: env.GetNextTypeVar())).ToImmutableDictionary(x => x.typeVar, x => (Type)x.newVar);
            var substitution = new Substitution(newVarMap);
            return ApplySubstitution(polytype.Type, substitution);
        }
    }
}
