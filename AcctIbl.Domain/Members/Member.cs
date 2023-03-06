using AcctIbl.Domain.SharedKernel;

namespace AcctIbl.Domain.Members;

public class Member : Entity<Guid>
{
    public Member(Guid? guid, string firstName, string lastName, string phone) : base(guid ?? Guid.NewGuid())
    {
        Info = new BasicInfo(firstName, lastName, phone);
        DateCreated = DateTime.Now;
        DateModified = DateTime.Now;
    }

    public BasicInfo Info {get; private set; }
    public DateTime DateCreated { get; private init; }
    public DateTime DateModified { get; private set; }

    public void ChangeProfileData(string? firstName, string? lastName, string? phone)
    {
        Info = Info.CopyWith(firstName, lastName, phone);
        DateModified = DateTime.Now;
    }
}