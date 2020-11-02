using ServerSideBlazorApp.Service;
using System.ComponentModel.DataAnnotations;

namespace ServerSideBlazorApp.Validation
{
    public class USStateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
            => ListProvider.States.ContainsKey(value.ToString());

        public override string FormatErrorMessage(string name)
            => $"{name} must be from the list of valid US states.";
    }
}
