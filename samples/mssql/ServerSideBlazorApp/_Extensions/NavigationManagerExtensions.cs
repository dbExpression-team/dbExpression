using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using ServerSideBlazorApp.Models;
using System;
using System.ComponentModel;
using System.Text.Json;
using System.Web;

namespace ServerSideBlazorApp
{
    public static class NavigationManagerExtensions
    {
        public static T GetQueryStringParameter<T>(this NavigationManager manager, string parameterName, T defaultValue)
            where T : IComparable
        {
            if (manager.TryGetQueryStringParameter<T>(parameterName, out T value))
                return value;

            return defaultValue;
        }

        public static bool TryGetQueryStringParameter<T>(this NavigationManager manager, string parameterName, out T value)
            where T : IComparable
        {
            value = default;

            var uri = manager.ToAbsoluteUri(manager.Uri);

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(parameterName, out var parameterValue))
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                try
                {
                    value = (T)converter.ConvertFrom(Convert.ToString(parameterValue));
                    return true;
                }
                catch (NotSupportedException)
                {
                    throw new ArgumentException($"Cannot convert {parameterName} to type {typeof(T)}");
                };
            }
            return false;
        }

        public static bool GetPagingFromQueryStringParameters(this NavigationManager manager, out PageRequestModel model)
        {
            model = null;
            if (manager.TryGetQueryStringParameter("page", out string serialized))
            {
                model = JsonSerializer.Deserialize<PageRequestModel>(HttpUtility.UrlDecode(serialized));
                return true;
            }
            return false;
        }
    }
}
