namespace Estoque.Domain.Validation
{
    internal class DomainExceptionValidation
    {
        public DomainExceptionValidation() { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new Exception(error);
        }
    }
}
