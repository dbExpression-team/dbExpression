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

using HatTrick.DbEx.Sql.Attribute;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FilterExpressionAppender : ExpressionElementAppender<FilterExpression>
    {
        #region internals
        private static readonly Dictionary<FilterExpressionOperator, string> filterOperatorMap;
        #endregion

        #region constructors
        static FilterExpressionAppender()
        {
            filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators(x => string.IsNullOrWhiteSpace(x) ? " " : $" {x} ").ToDictionary(k => k.Key, v => v.Value!);
        }
        #endregion

        #region methods
        public override void AppendElement(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendFilterExpressionUsingExpressionAppendStyles(expression, builder, context, EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);

        private static void AppendFilterExpressionUsingExpressionAppendStyles(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context, EntityExpressionAppendStyle entityAppendStyle, FieldExpressionAppendStyle fieldAppendStyle)
        {
            context.PushAppendStyles(entityAppendStyle, fieldAppendStyle);
            try
            {
                AppendFilterExpressionThatMayContainNull(expression, builder, context);
            }
            finally
            {
                context.PopAppendStyles();
            }
        }

        private static void AppendFilterExpressionThatMayContainNull(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            //if either side of the filter expression is equivalent to null, construct the side with an expression and append appropriate "IS NULL"
            if (expression.LeftArg.IsNull() || expression.RightArg.IsNull())
            {
                AppendFilterExpressionWithNull(expression, expression.LeftArg.IsNull() ? expression.RightArg : expression.LeftArg, builder, context);
            }
            else
            {
                //neither side of filter expression is equivalent to null
                AppendFilterExpressionWithoutNull(expression, builder, context);
            }
        }

        private static void AppendFilterExpressionWithNull(FilterExpression expression, IExpressionElement nonNullElement, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendElement(nonNullElement, context);

            switch (expression.ExpressionOperator)
            {
                case FilterExpressionOperator.Equal:
                    builder.Appender.Write(expression.Negate ? " IS NOT NULL" : " IS NULL");
                    break;
                case FilterExpressionOperator.NotEqual:
                    builder.Appender.Write(expression.Negate ? " IS NULL" : " IS NOT NULL");
                    break;
                default:
                    throw new ArgumentException($"Operator {expression.ExpressionOperator} invalid with null arguments");
            }
        }

        private static void AppendFilterExpressionWithoutNull(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Negate)
            {
                builder.Appender.Write("NOT (");
            }
            builder.AppendElement(expression.LeftArg, context);

            builder.Appender.Write(filterOperatorMap[expression.ExpressionOperator]);

            if (expression.RightArg is not null)
                builder.AppendElement(expression.RightArg, context);
            
            if (expression.Negate)
            {
                builder.Appender.Write(')');
            }
        }

        public void AppendElement(FilterExpression<bool> expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendElement(expression as FilterExpression, builder, context);

        public void AppendElement(FilterExpression<bool?> expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendElement(expression as FilterExpression, builder, context);
        #endregion
    }
}
