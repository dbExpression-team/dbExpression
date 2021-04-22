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

﻿using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Attribute
{
    public static class ArithmeticExpressionOperatorAttributeExtensions
    {
        public static string GetArithmeticOperator(this ArithmeticExpressionOperator value)
        {
            var values = Enum.GetValues(typeof(ArithmeticExpressionOperator));
            var fi = typeof(ArithmeticExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                if (!values.GetValue(i).Equals(value))
                    continue;

                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs is null || attrs.Length == 0)
                    continue;

                return ((ExpressionOperatorAttribute)attrs[0]).Operator;
            }

            return Enum.GetName(typeof(ArithmeticExpressionOperator), value);
        }
        
        public static ArithmeticExpressionOperator GetArithmeticOperator(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return default;

            var values = Enum.GetValues(typeof(ArithmeticExpressionOperator));
            var fi = typeof(ArithmeticExpressionOperator).GetFields();

            for (int i = 0; i < values.Length; i++)
            {
                var attrs = fi[i + 1].GetCustomAttributes(typeof(ExpressionOperatorAttribute), false);
                if (attrs is null || attrs.Length == 0)
                    continue;

                if (((ExpressionOperatorAttribute)attrs[0]).Operator.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    return (ArithmeticExpressionOperator)values.GetValue(i);
            }

            if (Enum.TryParse(value, true, out ArithmeticExpressionOperator parsedValue))
                return parsedValue;

            return default;
        }

        public static SortedDictionary<ArithmeticExpressionOperator, string> GetValuesAndArithmeticOperators(this Type type, Func<string, string> formatValue = null)
        {
            if (type != typeof(ArithmeticExpressionOperator))
                throw new InvalidOperationException($"Type must be {nameof(ArithmeticExpressionOperator)}");

            var sortedDictionary = new SortedDictionary<ArithmeticExpressionOperator, string>();
            foreach (var value in Enum.GetValues(type))
            {
                var o = GetArithmeticOperator((ArithmeticExpressionOperator)value);
                if (formatValue is object)
                    o = formatValue(o);
                sortedDictionary.Add((ArithmeticExpressionOperator)value, o);
            }
            return sortedDictionary;
        }
    }
}
