using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Web;
using System.Collections;
using System.Text.Json.Serialization;

namespace ServerSideBlazorApp
{
    public static class NavigationManagerExtensions
    {
        private static readonly string RETURN_URL_PARAM_NAME = "returnUrl";
        private static readonly string PAGING_PARAM_NAME = "paging";
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

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

        public static string GetReturnUrl(this NavigationManager manager)
        {
            if (manager.TryGetQueryStringParameter(RETURN_URL_PARAM_NAME, out string url))
            {
                return new UriBuilder(manager.ToAbsoluteUri(url)).ToString();
            }
            return manager.BaseUri;
        }

        public static bool TryGetPagingParametersFromReturnUrl<T>(this NavigationManager manager, out T model)
            where T : PagingParameters, new()
        {
            model = null;
            if (manager.TryGetQueryStringParameter(PAGING_PARAM_NAME, out string paging))
            {
                model = JsonSerializer.Deserialize<T>(paging);
                return true;
            }
            return false;
        }

        public static string ToReturnUrl<T>(this NavigationManager manager, string path, T page)
            where T : PagingParameters
        {
            if (!string.IsNullOrWhiteSpace(path) && page is object)
                return $"{RETURN_URL_PARAM_NAME}={HttpUtility.UrlEncode($"{manager.ToAbsoluteUri(path)}?{PAGING_PARAM_NAME}={JsonSerializer.Serialize(page, options)}")}";
            if (!string.IsNullOrWhiteSpace(path))
                return $"{RETURN_URL_PARAM_NAME}={HttpUtility.UrlEncode($"{manager.ToAbsoluteUri(path)}")}";
            return string.Empty;
        }
    }
}
