namespace Fux.Building
{
    internal static class PatternExtensions
    {
        public static IEnumerable<A.Identifier> Flatten(this A.Pattern.List list, Func<A.Identifier>? genWildcard = null)
        {
            foreach (var item in list)
            {
                foreach (var pim in item.Flatten(genWildcard))
                {
                    yield return pim;
                }
            }
        }

        public static IEnumerable<A.Identifier> Flatten(this A.Pattern pattern, Func<A.Identifier>? genWildcard = null)
        {
            switch (pattern)
            {
                case A.Pattern.LowerId identifier:
                    {
                        yield return identifier.Identifier;
                        break;
                    }
                case A.Pattern.Tuple tuple:
                    {
                        foreach (var item in tuple.Patterns)
                        {
                            foreach (var pim in Flatten(item))
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
                            foreach (var pim in Flatten(argument))
                            {
                                yield return pim;
                            }
                        }
                        break;
                    }
                case A.Pattern.WithAlias with:
                    {
                        foreach (var pim in Flatten(with.Pattern))
                        {
                            yield return pim;
                        }
                        foreach (var pim in Flatten(with.Alias))
                        {
                            yield return pim;
                        }
                        break;
                    }
                case A.Pattern.Record record:
                    {
                        foreach (var item in record.Patterns)
                        {
                            foreach (var pim in Flatten(item))
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
                            yield return genWildcard();
                        }
                        break;
                    }

                case A.Pattern.Unit:
                    break;

                default:
                    Assert(false);
                    throw new NotImplementedException();
            }
        }
    }
}
