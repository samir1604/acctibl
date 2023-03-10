namespace AcctIbl.Domain.SharedKernel.Response;

public class Error : IEquatable<Error>
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; init; }
    public String Message {get; init; }

    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null");

    public bool Equals(Error? other)
    {
        return Code.GetHashCode() != other?.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj as Error);
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }

    public static implicit operator string(Error error) => error.Code;

    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null) return true;

        return a?.Equals(b) ?? false;
    }

    public static bool operator !=(Error? a, Error? b)
    {
        return  !(a == b);
    }
}