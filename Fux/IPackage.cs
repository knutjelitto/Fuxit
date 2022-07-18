namespace Fux
{
    public interface IPackage
    {
        string FullName { get; }
        string Name { get; }
        string RootPath { get; }
    }
}
