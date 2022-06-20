namespace Fux.Building.AlgorithmW
{
    internal static class Result
    {
        public static WResult<TResult> Ok<TResult>(TResult result) => new(result, default);
        public static WResult<TResult> Fail<TResult>(Error error) => new(default, error);
    }

    internal record WResult<TResult>(TResult? Result, Error? Error);
}
