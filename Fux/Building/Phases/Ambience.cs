namespace Fux.Building.Phases
{
    public sealed class Ambience
    {
        public Ambience(ErrorBag errors)
        {
            Errors = errors;
        }

        public ErrorBag Errors { get; set; }

        public Config Config { get; init; } = new();
    }
}
