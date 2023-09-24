namespace Products.Application.Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() { }

        public BadRequestException(string message) : base(message) { }
    }
}
