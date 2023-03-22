using AcctIbl.Domain.SharedKernel;

namespace AcctIbl.Domain.Members.ValueObjects;

public sealed class Amount : ValueObject
{
    private Amount() {}

    private Amount(double value)
    {
        Value = value;
    }

    public static Amount Create(double value)
    {
        return new(value);
    }

    public double Value { get; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}