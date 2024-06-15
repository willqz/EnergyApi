namespace Energy.Domain.DomainObject
{
    public class DomainException : ArgumentException
    {
        public DomainException()
        {

        }

        public DomainException(string message) : base(message)
        {

        }

        public DomainException(string message, ArgumentException innerException) : base(message, innerException)
        {

        }
    }
}
