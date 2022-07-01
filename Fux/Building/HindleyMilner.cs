using Newtonsoft.Json;

namespace Fux.Building
{
    public interface INode
    {
        TypeNode FindType(Dictionary<string, TypeNode> Environment, List<TypeNode> NonGeneric);
    }

    public class TypeNode
    {
        public string? Name { get; set; }
        public List<TypeNode>? ArgumentTypes { get; set; }
        public TypeNode? ResultType { get; set; }

        public TypeNode FreshCopy(IdentityDictionary<TypeNode, TypeNode> mappings, List<TypeNode> nonGeneric)
        {
            if (Name == null)
            {
                if (OccursIn(nonGeneric))
                {
                    return this;
                }
                else
                {
                    if (!mappings.ContainsKey(this))
                    {
                        mappings[this] = new TypeNode();
                    }
                    return mappings[this];
                }
            }
            else
            {
                return new TypeNode()
                {
                    Name = Name,
                    ResultType = ResultType?.FreshCopy(mappings, nonGeneric),
                    ArgumentTypes = ArgumentTypes == null ? new List<TypeNode>() : ArgumentTypes.Select(a => a.FreshCopy(mappings, nonGeneric)).ToList()
                };
            }
        }

        public bool OccursInType(TypeNode other)
        {
            return this == other || (other.Name != null && other.ArgumentTypes != null && OccursIn(other.ArgumentTypes));
        }

        public bool OccursIn(List<TypeNode> Types)
        {
            return Types.Any(a => OccursInType(a));
        }

        public void Unify(TypeNode other)
        {
            if (Name == null)
            {
                if (this == other)
                {
                    throw new Exception("Attempt to unify a type with itself.");
                }
                if (OccursInType(other))
                {
                    throw new Exception("Recursive Unification");
                }

                ResultType = other.ResultType;
                Name = other.Name;

                ArgumentTypes = new List<TypeNode>();
                if (other.ArgumentTypes != null)
                {
                    foreach (var item in other.ArgumentTypes)
                    {
                        ArgumentTypes.Add(item);
                    }
                }
            }
            else
            {
                if (other.Name == null)
                {
                    other.Unify(this);
                }
                else
                {
                    Assert(ArgumentTypes != null);
                    Assert(other.ArgumentTypes != null);

                    if (Name != other.Name || ArgumentTypes.Count != other.ArgumentTypes.Count || ResultType == null != (other.ResultType == null))
                    {
                        throw new Exception("Type mismatch!");
                    }

                    for (int i = 0; i < ArgumentTypes.Count; i++)
                    {
                        ArgumentTypes[i].Unify(other.ArgumentTypes[i]);
                    }

                    if (other.ResultType != null)
                    {
                        Assert(ResultType != null);
                        other.ResultType.Unify(ResultType);
                    }
                }
            }
        }
    }

    public class IntNode : INode
    {
        public IntNode(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public TypeNode FindType(Dictionary<string, TypeNode> Environment, List<TypeNode> NonGeneric)
        {
            return new TypeNode() { Name = "Int" };
        }
    }

    public class IdentityNode : INode
    {
        public IdentityNode(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public TypeNode FindType(Dictionary<string, TypeNode> Environment, List<TypeNode> NonGeneric)
        {
            if (!Environment.ContainsKey(Value))
            {
                throw new Exception(string.Format("Invalid identifier: {0}", Value));
            }

            return Environment[Value].FreshCopy(new IdentityDictionary<TypeNode, TypeNode>(), NonGeneric);
        }
    }

    public class LetNode : INode
    {
        public string Name { get; set; }
        public INode Value { get; set; }
        public INode Body { get; set; }

        public LetNode(string name, INode value, INode body)
        {
            Name = name;
            Value = value;
            Body = body;
        }

        public TypeNode FindType(Dictionary<string, TypeNode> Environment, List<TypeNode> NonGeneric)
        {
            if (Environment.ContainsKey(Name))
            {
                throw new Exception(string.Format("Name {0} is already bound to another value.", Name));
            }

            var NewEnvironment = new Dictionary<string, TypeNode>(Environment)
            {
                [Name] = Value.FindType(Environment, NonGeneric)
            };

            return Body.FindType(NewEnvironment, NonGeneric);
        }
    }

    public class LambdaNode : INode
    {
        public List<string> Arguments { get; set; }
        public INode Body { get; set; }

        public LambdaNode(List<string> arguments, INode body)
        {
            Arguments = arguments;
            Body = body;
        }

        public TypeNode FindType(Dictionary<string, TypeNode> environment, List<TypeNode> nonGeneric)
        {
            var temporaryTypes = Arguments.ToDictionary(a => a, a => new TypeNode());

            var newEnvironment = new Dictionary<string, TypeNode>(environment);

            foreach (var type in temporaryTypes)
            {
                newEnvironment[type.Key] = type.Value;
            }

            var newNonGeneric = new List<TypeNode>();
            foreach (var item in nonGeneric)
            {
                newNonGeneric.Add(item);
            }

            foreach (var type in temporaryTypes)
            {
                newNonGeneric.Add(type.Value);
            }

            var resultType = Body.FindType(newEnvironment, newNonGeneric);
            return new TypeNode()
            {
                Name = "lambda",
                ArgumentTypes = temporaryTypes.Select(a => a.Value).ToList(),
                ResultType = resultType
            };
        }
    }

    public class ApplyNode : INode
    {
        public INode? Name { get; init; }
        public List<INode>? Arguments { get; init; }

        public ApplyNode(INode? name = null, List<INode>? arguments = null)
        {
            Name = name;
            Arguments = arguments;
        }

        public TypeNode FindType(Dictionary<string, TypeNode> Environment, List<TypeNode> NonGeneric)
        {
            Assert(Arguments != null);
            Assert(Name != null);

            var ResultType = new TypeNode();
            var ArgumentTypesB = Arguments.Select(a => a.FindType(Environment, NonGeneric)).ToList();
            var FunctionType = Name.FindType(Environment, NonGeneric);
            new TypeNode()
            {
                Name = "lambda",
                ArgumentTypes = ArgumentTypesB,
                ResultType = ResultType
            }.Unify(FunctionType);
            return ResultType;
        }
    }

    public class HindleyMilner
    {
        public static void Main()
        {
            var programs = new List<INode> {
                new LambdaNode( arguments: new[] { "f" }.ToList(), body: new IntNode( 5 ) ),

                new LetNode(
                    /*
                        let
                            five = 5
                        in
                            let
                                g = \f -> f
                            in
                                g five
                    */
                    name: "five",
                    value: new IntNode( 5 ),
                    body: new LetNode(
                        name: "g",
                        value: new LambdaNode(
                            arguments: new[] { "f" }.ToList(),
                            body: new IdentityNode( "f" )
                        ),
                        body: new ApplyNode(
                            name: new IdentityNode( "g"),
                            arguments: new[]
                            {
                                (INode)new IdentityNode( "five" ),
                            }.ToList()
                        )
                    )
                ),
            };

            foreach (var program in programs)
            {
                var environment = new Dictionary<string, TypeNode>();
                var nonGeneric = new List<TypeNode>();

                var foundType = program.FindType(environment, nonGeneric);

                Console.WriteLine("Current Program: ");
                Console.WriteLine(JsonConvert.SerializeObject(program, Formatting.Indented));
                Console.WriteLine("Result: ");
                Console.WriteLine(JsonConvert.SerializeObject(foundType, Formatting.Indented));
            }

            Console.ReadKey();
        }
    }
}
