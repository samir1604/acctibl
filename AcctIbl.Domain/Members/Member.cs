using System.Collections.Generic;

using AcctIbl.Domain.Errors;
using AcctIbl.Domain.SharedKernel;
using AcctIbl.Domain.SharedKernel.Response;

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

    public Result<Tithe> AddUpdateTithe(Tithe tithe)
    {
        var idx = _tithes.FindIndex(t => t.Equals(tithe));
        if (idx >= 0)
            return Result.Failure<Tithe>(tithe, DomainErrors.Members.AddingNewTithe);

        _tithes.Add(tithe);
        DateModified = DateTime.Now;

        return tithe;
    }

    public Result<Tithe> UpdateTithe(Tithe tithe)
    {
        var idx = _tithes.FindIndex(t => t.Equals(tithe));
        if (idx < 0)
            return Result.Failure<Tithe>(tithe, DomainErrors.Members.EditingTithe);

        var currentTithe = _tithes[idx];
        var updatedTithe = Tithe.Create(currentTithe.Month, tithe.Amount + tithe.Amount);
        _tithes[idx]= updatedTithe;

        return updatedTithe;
    }

    public void ChangeProfileData(string? firstName, string? lastName, string? phone)
    {
        Info = Info.CopyWith(firstName, lastName, phone);
    }
}