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

using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;

namespace DbExpression.Sql.Attribute
{
    public static class ArithmeticExpressionOperatorAttributeExtensions
    {
        public static string GetArithmeticOperator(this ArithmeticExpressionOperator value)
        {
            return value.GetStringFromEnum<ArithmeticExpressionOperator, ExpressionOperatorAttribute>(a => a.Operator);
        }

        public static ArithmeticExpressionOperator? GetArithmeticOperator(this string? value)
        {
            return value?.GetEnumFromString<ArithmeticExpressionOperator, ExpressionOperatorAttribute>(a => a.Operator);
        }

        public static SortedDictionary<ArithmeticExpressionOperator, string?> GetValuesAndArithmeticOperators(this Type type, Func<string, string>? formatValue = null)
        {
            if (formatValue is null)
                return type.GetEnumAsSortedDictionary<ArithmeticExpressionOperator>(op => GetArithmeticOperator(op));
            return type.GetEnumAsSortedDictionary<ArithmeticExpressionOperator>(op => { var s = GetArithmeticOperator(op); return formatValue?.Invoke(s); });
        }
    }
}
