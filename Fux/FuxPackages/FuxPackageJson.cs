using System.Text.Json;

namespace Fux.FuxPackages
{
    public sealed class FuxPackageJson : FuxJson
    {
        public FuxPackageJson(Package package, JsonElement element)
        {
            Package = package;

            Assert(element.ValueKind == JsonValueKind.Object);

            foreach (var property in element.EnumerateObject())
            {
                switch (property.Name)
                {
                    case "type":
                        Type = property.Value.ToString();
                        break;
                    case "name":
                        Name = property.Value.ToString();
                        break;
                    case "summary":
                        Summary = property.Value.ToString();
                        break;
                    case "exposed-modules":
                        {
                            modules(Exposed, property.Value);
                            break;
                        }
                    case "internal-modules":
                        {
                            modules(Intern, property.Value);
                            break;
                        }
                    case "waiting-modules":
                        {
                            modules(Waiting, property.Value);
                            break;
                        }
                    case "dependencies":
                        foreach (var prop in property.Value.EnumerateObject())
                        {
                            Dependencies.Add(new Dependency(prop.Name));
                        }
                        break;
                    default:
                        throw new InvalidOperationException($"can not decode property \"{property.Name}\"");
                }
            }

            void modules(List<ModuleGroup> Exposed, JsonElement Value)
            {
                if (Value.ValueKind == JsonValueKind.Array)
                {
                    Exposed.Add(new ModuleGroup("", ParseArray(Value)));
                }
                else if (Value.ValueKind == JsonValueKind.Object)
                {
                    ParseObject(Value);
                }
                else
                {
                    throw new InvalidOperationException();
                }

                void ParseObject(JsonElement element)
                {
                    foreach (var property in element.EnumerateObject())
                    {
                        Exposed.Add(new ModuleGroup(property.Name, ParseArray(property.Value)));
                    }
                }

                IEnumerable<Module> ParseArray(JsonElement element)
                {
                    Assert(element.ValueKind == JsonValueKind.Array);

                    foreach (var property in element.EnumerateArray())
                    {
                        yield return new Module(Package, property.GetString()!);
                    }
                }
            }
        }

        public Package Package { get; }

        public string Name { get; } = string.Empty;
        public string Summary { get; } = string.Empty;
        public List<ModuleGroup> Exposed { get; } = new();
        public List<ModuleGroup> Intern { get; } = new();
        public List<ModuleGroup> Waiting { get; } = new();
        public IEnumerable<Module> ExposedModules => Exposed.SelectMany(e => e).ToList();
        public IEnumerable<Module> InternModules => Intern.SelectMany(e => e).ToList();
        public List<Dependency> Dependencies { get; } = new();
    }
}
