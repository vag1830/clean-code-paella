namespace Paella.Domain.Exceptions
{
    public class ProductAlreadyExistsException : DomainException
    {
        public ProductAlreadyExistsException() { }

        public ProductAlreadyExistsException(string message)
            : base(message) { }
    }
}