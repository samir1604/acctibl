using AcctIbl.Domain.SharedKernel;

namespace AcctIbl.Domain.Tithe;

public class Amount : ValueObject
{
    public Amount(double value)
    {
        Value = value;
    }

    public double Value {get; private init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}