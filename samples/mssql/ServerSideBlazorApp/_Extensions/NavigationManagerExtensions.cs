using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.ComponentModel;

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
    }
}
