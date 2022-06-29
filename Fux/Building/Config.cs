namespace Fux.Building
{
    public sealed class Config
    {
        public Config()
        {
        }

        public bool WriteTheLines { get; init; } = false;
        public bool WriteTheAst { get; init; } = false;
        public bool WriteTheDeclarations { get; init; } = false;
        public bool WriteTheTyping { get; init; } = false;
    }
}
