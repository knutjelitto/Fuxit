﻿namespace Fux.Building
{
    public static class PatternExtensions
    {
        public static IEnumerable<A.Decl.Parameter> ExtractNamedParameters(this A.Pattern pattern)
        {
            return pattern.Flatten().Select(id => new A.Decl.Parameter(id));
        }

        public static IEnumerable<A.Decl.Parameter> ExtractMatchNames(this A.Pattern pattern)
        {
            return Flatten(pattern, null, true).Select(name => new A.Decl.Parameter(name));
        }

        public static IEnumerable<A.Pattern.LowerId> ExractMatchIds(this A.Pattern pattern)
        {
            return Flatten(pattern, null, true);
        }

        public static IEnumerable<A.Pattern.LowerId> Flatten(this A.Pattern pattern, Func<A.Identifier>? genWildcard = null)
        {
            return Flatten(pattern, genWildcard, false).ToList(); ;
        }

        private static IEnumerable<A.Pattern.LowerId> Flatten(this A.Pattern pattern, Func<A.Identifier>? genWildcard, bool inner)
        {
            switch (pattern)
            {
                case A.Pattern.LowerId identifier:
                    {
                        yield return identifier;
                        break;
                    }

                case A.Pattern.Signature sign when inner && sign.Parameters.Count == 0:
                    {
                        Assert(false);
                        throw new InvalidOperationException();
                    }

                case A.Pattern.Signature sign:
                    {
                        foreach (var argument in sign.Parameters)
                        {
                            foreach (var pim in Flatten(argument, genWildcard, true))
                            {
                                yield return pim;
                            }
                        }
                        break;
                    }

                case A.Pattern.Tuple tuple:
                    {
                        foreach (var item in tuple.Patterns)
                        {
                            foreach (var pim in Flatten(item, genWildcard, true))
                            {
                                yield return pim;
                            }
                        }
                        break;
                    }

                case A.Pattern.List list:
                    {
                        foreach (var item in list.Patterns)
                        {
                            foreach (var pim in Flatten(item, genWildcard, true))
                            {
                                yield return pim;
                            }
                        }
                        break;
                    }

                case A.Pattern.Cons destruct:
                    {
                        foreach (var pim in Flatten(destruct.First, genWildcard, true))
                        {
                            yield return pim;
                        }
                        foreach (var pim in Flatten(destruct.Rest, genWildcard, true))
                        {
                            yield return pim;
                        }
                        break;
                    }

                case A.Pattern.Lambda lambda:
                    {
                        foreach (var argument in lambda.Parameters)
                        {
                            foreach (var pim in Flatten(argument, genWildcard, true))
                            {
                                yield return pim;
                            }
                        }
                        break;
                    }

                case A.Pattern.Ctor ctor:
                    {
                        foreach (var argument in ctor.Arguments)
                        {
                            foreach (var pim in Flatten(argument, genWildcard, true))
                            {
                                yield return pim;
                            }
                        }
                        break;
                    }

                case A.Pattern.WithAlias with:
                    {
                        foreach (var pim in Flatten(with.Pattern, genWildcard, true))
                        {
                            yield return pim;
                        }
                        foreach (var pim in Flatten(with.Alias, genWildcard, true))
                        {
                            yield return pim;
                        }
                        break;
                    }

                case A.Pattern.Record record:
                    {
                        foreach (var item in record.Patterns)
                        {
                            foreach (var pim in Flatten(item, genWildcard, true))
                            {
                                yield return pim;
                            }
                        }
                        break;
                    }

                case A.Pattern.Wildcard:
                    {
                        if (genWildcard != null)
                        {
                            yield return new A.Pattern.LowerId(genWildcard());
                        }
                        break;
                    }

                case A.Pattern.Unit:
                case A.Pattern.Literal:
                case A.Pattern.UpperId:
                    break;

                default:
                    Assert(false);
                    throw new NotImplementedException($"{pattern}");
            }
        }
    }
}
