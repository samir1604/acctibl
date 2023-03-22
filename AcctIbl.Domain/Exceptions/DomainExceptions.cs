namespace AcctIbl.Domain.Exceptions;

public static class DomainExceptions
{
    public static class MembersException
    {
        public static readonly DomainException TitheAlreadyExists  = new TitheAlreadyExists("Member");
    }
}

public sealed class TitheAlreadyExists : DomainException
{
    private TitheAlreadyExists() : base()
    {
    }

    private TitheAlreadyExists(string? message) : base(message)
    {
    }

    private TitheAlreadyExists(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

public abstract class DomainException : Exception
{
    protected DomainException() : base() {}

    protected DomainException(string? message) : base(message)
    {
    }

    protected DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected string 
}
