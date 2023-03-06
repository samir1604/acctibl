using AcctIbl.Domain.SharedKernel;

namespace AcctIbl.Domain.Members;

public class BasicInfo : ValueObject
{
    public BasicInfo(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public string FirstName { get; private init; } = string.Empty;
    public string LastName {get; private init; } = string.Empty;
    public string Phone {get; private init; } = string.Empty;
    public string FullName => FirstName  + " " + LastName;

    public BasicInfo CopyWith(string? firstName, string? lastName, string? phone)
    {
        return new BasicInfo(
            firstName ?? FirstName, lastName ?? LastName, phone ?? Phone);
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return FirstName;
        yield return LastName;
        yield return Phone;
    }
}