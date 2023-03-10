namespace AcctIbl.Domain.SharedKernel.Response;

public class Result<T> : Result
{
    protected internal Result(T? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    private readonly T? _value;
    public T Value => IsSuccess
    ? _value!
    : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<T>(T? value) => Create(value);
}