using AcctIbl.Domain.Members.ValueObjects;
using AcctIbl.Domain.SharedKernel;
using AcctIbl.Domain.SharedKernel.Enums;

namespace AcctIbl.Domain.Members;

public sealed class Tithe : ValueObject
{
    private Tithe(Month month, Amount amount)
    {
        Month = month;
        Amount = amount;
        DateCreated = DateTime.Now;
    }

    public Month Month {get; init; }
    public Amount Amount {get; init; }
    public DateTime DateCreated { get; init; }

    public static Tithe Create(Month month, Amount amount)
    {
        return new(month, amount);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Month;
    }
}