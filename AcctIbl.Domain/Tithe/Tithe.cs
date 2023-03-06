using AcctIbl.Domain.Members;
using AcctIbl.Domain.SharedKernel;

namespace AcctIbl.Domain.Tithe;

public class Tithe : AggregateRoot<int>
{
    public Tithe(int id, Member member, Amount amount) : base(id)
    {
        Member = member;
        Amount = amount;
    }

    public Member Member { get; private init; }

    public Amount Amount {get; private set; }

    public void ChangeAmount(double newValue)
    {
        Amount = new Amount(newValue);
    }
}