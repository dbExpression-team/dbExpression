#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Attribute
{
    public static class FilterExpressionOperatorAttributeExtensions
    {
        public static string GetFilterOperator(this FilterExpressionOperator value)
        {
            return value.GetStringFromEnum<FilterExpressionOperator, ExpressionOperatorAttribute>(a => a.Operator);
        }
        
        public static FilterExpressionOperator? GetFilterOperator(this string? value)
        {
            return value?.GetEnumFromString<FilterExpressionOperator, ExpressionOperatorAttribute>(a => a.Operator);
        }

        public static SortedDictionary<FilterExpressionOperator, string?> GetValuesAndFilterOperators(this Type type, Func<string, string>? formatValue)
        {
            if (formatValue is null)
                return type.GetEnumAsSortedDictionary<FilterExpressionOperator>(op => GetFilterOperator(op));
            return type.GetEnumAsSortedDictionary<FilterExpressionOperator>(op => { var s = GetFilterOperator(op); return formatValue?.Invoke(s); });
        }
    }
}
