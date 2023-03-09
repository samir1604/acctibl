using System.Collections.Generic;
using AcctIbl.Domain.SharedKernel;

namespace AcctIbl.Domain.Members;

public class Member : Entity<Guid>
{
    private readonly List<Tithe> _tithes = new();
    public Member(Guid? guid, string firstName, string lastName, string phone) : base(guid ?? Guid.NewGuid())
    {
        Info = new BasicInfo(firstName, lastName, phone);
        DateCreated = DateTime.Now;
        DateModified = DateTime.Now;
    }

    public BasicInfo Info {get; private set; }
    public DateTime DateCreated { get; private init; }
    public DateTime DateModified { get; private set; }

    public IReadOnlyCollection<Tithe> Tithes => _tithes.AsReadOnly();

    public void AddTithe(Tithe tithe)
    {
        var idx = _tithes.FindIndex(t => t.Equals(tithe));
        if (idx >= 0)
        {
            var currentTithe = _tithes[idx];
            _tithes[idx]= Tithe.Create(currentTithe.Month, tithe.Amount + tithe.Amount);
        } else {
            _tithes.Add(tithe);
        }

        DateModified = DateTime.Now;
    }

    public void ChangeProfileData(string? firstName, string? lastName, string? phone)
    {
        Info = Info.CopyWith(firstName, lastName, phone);
    }
}