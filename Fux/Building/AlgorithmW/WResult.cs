namespace Fux.Building.AlgorithmW
{
    public static class WResult
    {
        public static WResult<TResult> Ok<TResult>(TResult result) => new(result, default);
        public static WResult<TResult> Fail<TResult>(WError error) => new(default, error);
    }

    public record WResult<TResult>(TResult? Result, WError? Error);
}
