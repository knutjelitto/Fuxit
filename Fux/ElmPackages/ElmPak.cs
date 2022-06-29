using System.Text.Json;

using Semver;

namespace Fux.ElmPackages
{
    public sealed class ElmPak : Elm
    {
        public ElmPak(ElmPackage package, JsonElement element)
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
                    case "license":
                        License = property.Value.ToString();
                        break;
                    case "version":
                        Version = SemVersion.Parse(property.Value.GetString(), SemVersionStyles.Strict);
                        break;
                    case "exposed-modules":
                        {
                            if (property.Value.ValueKind == JsonValueKind.Array)
                            {
                                Exposed.Add(new ElmModuleGroup("", ParseArray(property.Value)));
                            }
                            else if (property.Value.ValueKind == JsonValueKind.Object)
                            {
                                ParseObject(property.Value);
                            }
                            else
                            {
                                throw new InvalidOperationException();
                            }

                            void ParseObject(JsonElement element)
                            {
                                foreach (var property in element.EnumerateObject())
                                {
                                    Exposed.Add(new ElmModuleGroup(property.Name, ParseArray(property.Value)));
                                }
                            }

                            IEnumerable<ElmModule> ParseArray(JsonElement element)
                            {
                                Assert(element.ValueKind == JsonValueKind.Array);

                                foreach (var property in element.EnumerateArray())
                                {
                                    yield return new ElmModule(Package, property.GetString()!);
                                }
                            }
                        }
                        break;
                    case "elm-version":
                        ElmVersion = new Dependency(property.Name, Constraint.Parse(property.Value.GetString()!));
                        break;
                    case "dependencies":
                        foreach (var prop in property.Value.EnumerateObject())
                        {
                            Dependencies.Add(new Dependency(prop.Name, Constraint.Parse(prop.Value.GetString()!)));
                        }
                        break;
                    case "test-dependencies":
                        foreach (var prop in property.Value.EnumerateObject())
                        {
                            TestDependencies.Add(new Dependency(prop.Name, Constraint.Parse(prop.Value.GetString()!)));
                        }
                        break;
                    default:
                        throw new InvalidOperationException($"can not decode property \"{property.Name}\"");
                }
            }
        }

        public ElmPackage Package { get; }

        public string Name { get; } = string.Empty;
        public string Summary { get; } = string.Empty;
        public string License { get; } = string.Empty;
        public SemVersion Version { get; } = new(0);
        public List<ElmModuleGroup> Exposed { get; } = new();
        public IEnumerable<ElmModule> ExposedModules => Exposed.SelectMany(e => e).ToList();
        public List<Dependency> Dependencies { get; } = new();
        public List<Dependency> TestDependencies { get; } = new();
    }
}
