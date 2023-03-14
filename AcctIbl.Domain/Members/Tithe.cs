using System.Runtime.CompilerServices;
using System;
using AcctIbl.Domain.SharedKernel;
using AcctIbl.Domain.SharedKernel.Enums;

namespace AcctIbl.Domain.Members;

public sealed class Tithe : ValueObject
{
    private Tithe(Month month, double amount)
    {
        Month = month;
        Amount = amount;

        DateCreated = DateTime.Now;
    }

    public Month Month {get; init; }
    public double Amount {get; init; }
    public DateTime DateCreated { get; init; }

    public static Tithe Create(Month month, double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        return new Tithe(month, amount);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Month;
    }
}