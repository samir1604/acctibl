using System.Diagnostics.CodeAnalysis;

using AcctIbl.Domain.SharedKernel;

namespace AcctIbl.Domain.Members.ValueObjects;

public sealed class BasicInfo : ValueObject
{
    private BasicInfo() {}

    [SetsRequiredMembers]
    private BasicInfo(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public required string FirstName { get; init; }
    public required string LastName {get; init; }
    public required string Phone {get; init; }
    public string FullName => FirstName  + " " + LastName;

    public static BasicInfo Create(string firstName, string lastName, string phone)
    {
        return new BasicInfo(firstName, lastName, phone);
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return FirstName;
        yield return LastName;
        yield return Phone;
    }
}