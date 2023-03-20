using AcctIbl.Domain.SharedKernel;
using AcctIbl.Domain.Members.ValueObjects;

namespace AcctIbl.Domain.Members;

public class Member : AggregateRoot<MemberId>
{
    private readonly List<Tithe> _tithes = new();
    public Member(MemberId id, string firstName, string lastName, string phone) :
        base(id)
    {
        Info = BasicInfo.Create(firstName, lastName, phone);
        DateCreated = DateTime.Now;
        DateModified = DateTime.Now;
    }

    public BasicInfo Info {get; private set; }
    public DateTime DateCreated { get; private init; }
    public DateTime DateModified { get; private set; }

    public IReadOnlyCollection<Tithe> Tithes => _tithes.AsReadOnly();

    public void AddNewTithe(Tithe tithe)
    {
        _tithes.Add(tithe);
    }

    public void UpdateAmountTithe(Tithe tithe, double newAmount)
    {
        var idx = _tithes.FindIndex(t => t.Equals(tithe));

        if (idx > 0)
            _tithes[idx] = Tithe.Create(tithe.Month, newAmount);
    }

    public void RemoveTithe(Tithe tithe)
    {
        var idx = _tithes.FindIndex(t => t.Equals(tithe));
        if(idx >= 0)
            _tithes.RemoveAt(idx);
    }

    public void ChangeProfileData(string? firstName, string? lastName, string? phone)
    {
        Info = BasicInfo.Create(
            firstName?? Info.FirstName,
            lastName ?? Info.LastName,
            phone ?? Info.Phone);

        DateModified = DateTime.Now;
    }
}