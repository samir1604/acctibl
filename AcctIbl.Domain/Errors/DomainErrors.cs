using AcctIbl.Domain.SharedKernel.Response;

namespace AcctIbl.Domain.Errors;

public static class DomainErrors
{
    public static class Members
    {
        public static readonly Error TitheAlreadyExists = new(
                "Member.AddNewTithe",
                "Tithe already exists"
            );

        public static readonly Error TitheNotFound = new(
                "Member.UpdateAmountTithe",
                "Tithe not found"
            );
    }

    public static class Tithe
    {
        public static readonly Error TitheZero = new(
            "Tithe.Create",
            "Tithe amount must be greater than zero"
        );
    }
}