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

using DbExpression.Sql.Attribute;
using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Assembler
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
                AppendFilterExpression(expression, builder, context);
            }
            finally
            {
                context.PopAppendStyles();
            }
        }

        private static void AppendFilterExpression(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            //if either side of the filter expression is equivalent to null, construct the side with an expression and append appropriate "IS NULL"
            if (expression.LeftArg.IsNull() || expression.RightArg.IsNull())
            {
                switch (expression.ExpressionOperator)
                {
                    case FilterExpressionOperator.Equal:
                        builder.AppendElement(expression.LeftArg.IsNull() ? expression.RightArg : expression.LeftArg, context);
                        builder.Appender.Write(expression.Negate ? " IS NOT NULL" : " IS NULL");
                        return;
                    case FilterExpressionOperator.NotEqual:
                        builder.AppendElement(expression.LeftArg.IsNull() ? expression.RightArg : expression.LeftArg, context);
                        builder.Appender.Write(expression.Negate ? " IS NULL" : " IS NOT NULL");
                        return;
                }
            }

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
        #endregion
    }
}
