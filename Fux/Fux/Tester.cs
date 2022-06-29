using System.Reflection;

namespace Fux.Tests
{
    public static class Tester
    {
        public static IEnumerable<Source> All()
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var name in assembly.GetManifestResourceNames())
            {
                using (var stream = assembly.GetManifestResourceStream(name)!)
                using (var reader = new IO.StreamReader(stream))
                {
                    var content = reader.ReadToEnd();
                    yield return new StringSource(name, name, content);
                }
            }

            yield break;
        }
    }
}
