using AcctIbl.Domain.SharedKernel.Response;

namespace AcctIbl.Domain.Errors;

public static class DomainErrors
{
    public static class Members
    {
        public static readonly Error AddingNewTithe = new(
                "Member.AddUpdateTithe",
                "Tithe already exists"
            );

        public static readonly Error EditingTithe = new(
                "Member.UpdateTithe",
                "Tithe not found"
            );
    }
}