using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

using Semver;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Fux.ElmPackages
{
    internal class ElmPak : Elm
    {
        public ElmPak(Package package, JsonElement element)
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
                                Exposed.Add(new ExposedGroup("", ParseArray(property.Value)));
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
                                    Exposed.Add(new ExposedGroup(property.Name, ParseArray(property.Value)));
                                }
                            }

                            IEnumerable<ExposedModule> ParseArray(JsonElement element)
                            {
                                Assert(element.ValueKind == JsonValueKind.Array);

                                foreach (var property in element.EnumerateArray())
                                {
                                    yield return new ExposedModule(Package, property.GetString()!);
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

        public Package Package { get; }

        public string Type { get; }
        public string Name { get; }
        public string Summary { get; }
        public string License { get; }
        public SemVersion Version { get; }
        public List<ExposedGroup> Exposed { get; } = new();
        public IEnumerable<ExposedModule> Modules => Exposed.SelectMany(e => e);
        public Dependency ElmVersion { get; }
        public List<Dependency> Dependencies { get; } = new();
        public List<Dependency> TestDependencies { get; } = new();
    }
}
