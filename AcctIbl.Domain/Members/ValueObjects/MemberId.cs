using AcctIbl.Domain.SharedKernel;

namespace AcctIbl.Domain.Members.ValueObjects;

public sealed class MemberId : ValueObject
{
    public Guid Value { get; }

    private MemberId() {}

    private MemberId(Guid value)
    {
        Value = value;
    }

    public static MemberId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MemberId Create(Guid value)
    {
        return new(value);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}