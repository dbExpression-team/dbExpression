using ServerSideBlazorApp.Models;

namespace ServerSideBlazorApp
{
    public static class ModelExtensions
    {
        public static AddressModel Copy(this AddressModel source)
        {
            return new AddressModel
            {
                Line1 = source.Line1,
                Line2 = source.Line2,
                City = source.City,
                State = source.State,
                ZIP = source.ZIP
            };
        }
    }
}
