namespace AcctIbl.Domain.SharedKernel.Response;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if(!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get;  init; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; init; }

    public static Result<T> Create<T>(T? value)
    {
        return value is null ?  Failure<T>(Error.NullValue) :
            Success(value);
    }

    public static Result Success() => new(true, Error.None);

    public static Result<T> Success<T>(T value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<T> Failure<T>(Error error) => new(default, false, error);
}