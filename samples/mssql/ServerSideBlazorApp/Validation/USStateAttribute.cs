using ServerSideBlazorApp.Service;
using System.ComponentModel.DataAnnotations;

namespace ServerSideBlazorApp.Validation
{
    public class USStateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
            => value is not null && ListProvider.States.ContainsKey(value.ToString() ?? string.Empty);

        public override string FormatErrorMessage(string name)
            => $"{name} must be from the list of valid US states.";
    }
}
