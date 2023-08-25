namespace KitchenRouter.Domain.Errors
{
    public static class DomainErrors
    {
        public static Dictionary<DomainErrorCode, string> Errors { get; } =
            new Dictionary<DomainErrorCode, string>()
            {
                { DomainErrorCode.CannotBeEmpty, "{0} cannot be empty" },
                { DomainErrorCode.InvalidValue, "Invalid {0}" }
            };

        public enum DomainErrorCode
        { 
            Unknown = 0,
            CannotBeEmpty = 1,
            InvalidValue = 2
        }
    }
}
