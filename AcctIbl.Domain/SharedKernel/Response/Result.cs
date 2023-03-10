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

    public static Result<T> Create<T>(T? value) {
        if (value == null)
        {
            return new Result<T>(value, true, Error.NullValue );
        }
        return new(value, true, Error.None);
    }

    public static Result Success() => new(true, Error.None);

    public static Result<T> Success<T>(T value) => new(value, true, Error.None);

    public static Result Failure() => new(false, Error.NullValue);

    public static Result<T> Failure<T>(T? value, Error error) => new(value, false, error);
}