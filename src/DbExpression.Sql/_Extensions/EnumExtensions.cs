#region license
// Copyright (c) dbExpression.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using System;
using System.Collections.Generic;

namespace DbExpression.Sql
{
    internal static class EnumExtensions
    {
        public static string GetStringFromEnum<TEnum, TAttribute>(this TEnum value, Func<TAttribute, string> getStringFromAttribute)
            where TAttribute : System.Attribute
        {
            var values = Enum.GetValues(typeof(TEnum));
            var fi = typeof(TEnum).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var v = values.GetValue(i);
                if (v is null)
                    continue;

                if (!v.Equals(value))
                    continue;

                var attrs = fi[i + 1].GetCustomAttributes(typeof(TAttribute), false);
                if (attrs is null || attrs.Length == 0)
                    continue;

                return getStringFromAttribute((TAttribute)attrs[0]);
            }

            return Enum.GetName(typeof(TEnum), value!)!;
        }

        public static TEnum? GetEnumFromString<TEnum, TAttribute>(this string value, Func<TAttribute, string?> getStringFromAttribute)
            where TEnum : struct, Enum, IComparable
            where TAttribute : System.Attribute
        {
            if (string.IsNullOrWhiteSpace(value))
                return default;

            var values = Enum.GetValues(typeof(TAttribute));
            var fi = typeof(TAttribute).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var attrs = fi[i + 1].GetCustomAttributes(typeof(TAttribute), false);
                if (attrs is null || attrs.Length == 0)
                    continue;

                var attrValue = getStringFromAttribute((TAttribute)attrs[0]);
                if (attrValue is not null && attrValue.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    var attrObject = values.GetValue(i);
                    return attrObject is null ? null : (TEnum)attrObject;
                }
            }

            if (Enum.TryParse(value, true, out TEnum parsedValue))
                return parsedValue;

            return default;
        }

        public static SortedDictionary<TEnum, string?> GetEnumAsSortedDictionary<TEnum>(this Type type, Func<TEnum, string?> getStringValue)
            where TEnum : struct, Enum, IComparable
        {
            if (type != typeof(TEnum))
                throw new InvalidOperationException($"Type must be {nameof(TEnum)}");

            var sortedDictionary = new SortedDictionary<TEnum, string?>();
            foreach (var value in Enum.GetValues(typeof(TEnum)))
            {
                var filter = getStringValue((TEnum)value);
                sortedDictionary.Add((TEnum)value, filter);
            }
            return sortedDictionary;
        }
    }
}
