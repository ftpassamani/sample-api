namespace Sample.Template.CrossCutting.Result
{
    public class Error
    {
        public string Message { get; private init; }
        public ErrorType Type { get; private init; }
        private Error()
        {
        }

        public static Error CreateNotFound(string name, object key)
        {
            return new()
            {
                Type = ErrorType.NotFound,
                Message = $"Entity \"{name}\" ({key}) was not found."
            };
        }
    }
}
