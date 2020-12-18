using ServerSideBlazorApp.Models;
using System.Text.Json;
using System.Web;

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

        public static string ToQueryStringParameters(this PageRequestModel model)
            => $"page={HttpUtility.UrlEncode(JsonSerializer.Serialize(model))}";
    }
}
