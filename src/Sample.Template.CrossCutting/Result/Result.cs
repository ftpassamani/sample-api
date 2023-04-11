namespace Sample.Template.CrossCutting.Result
{
    public class Result<T>
    {
        public T Value { get; private init; }
        public Error Error { get; private init; }

        public bool IsSuccess => Error == null;

        private Result()
        {
        }

        public static implicit operator Result<T>(T value) =>
            CreateSuccess(value);

        public static implicit operator Result<T>(Error error) =>
            CreateError(error);

        private static Result<T> CreateSuccess(T value) =>
            new()
            {
                Value = value,
                Error = null
            };

        private static Result<T> CreateError(Error error) =>
            new()
            {
                Value = default,
                Error = error
            };
    }
}
