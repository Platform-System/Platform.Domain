namespace Platform.Domain.Common
{
    public static class DomainErrors
    {
        public static class Validation
        {
            public static Error InvalidInput => new("Validation.InvalidInput", "One or more validation errors occurred.");
            public static Error Required(string fieldName) => new("Validation.Required", $"The field '{fieldName}' is required.");
        }

        public static class Global
        {
            public static Error InternalError => new("Global.InternalError", "An unexpected error occurred on the server.");
            public static Error NotFound(string entityName, object id) => new("Global.NotFound", $"The entity '{entityName}' with ID '{id}' was not found.");
            public static Error Unauthorized => new("Global.Unauthorized", "You are not authorized to perform this action.");
        }
    }
}
