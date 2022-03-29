using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;
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

        public static string ToQueryStringParameters(this PagingParameters model)
            => $"page={HttpUtility.UrlEncode(JsonSerializer.Serialize(model))}";

        public static string ToQueryStringParameters(this PagingParameters model, string path)
        {
            var serialized = JsonSerializer.Serialize(model);
            var keysAndValues = JsonSerializer.Deserialize<Dictionary<string, string>>(serialized);
            if (keysAndValues is null)
                return $"returnUrl={HttpUtility.UrlEncode($"{path}")}";

            var queryString = keysAndValues.Aggregate(string.Empty, (acc, kvp) => $"{acc}{kvp.Key}:{kvp.Value}&");

            return $"returnUrl={HttpUtility.UrlEncode($"{path}?{queryString}")}";
        }
    }
}
