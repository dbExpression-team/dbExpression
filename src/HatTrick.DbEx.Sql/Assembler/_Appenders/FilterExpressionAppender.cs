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

﻿using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FilterExpressionAppender : ExpressionElementAppender<FilterExpression>
    {
        #region internals
        private static IDictionary<FilterExpressionOperator, string> _filterOperatorMap;
        private static IDictionary<FilterExpressionOperator, string> FilterOperatorMap => _filterOperatorMap ?? (_filterOperatorMap = typeof(FilterExpressionOperator).GetValuesAndFilterOperators(x => string.IsNullOrWhiteSpace(x) ? " " : $" {x} "));
        #endregion

        #region methods
        public override void AppendElement(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendFilterExpressionUsingExpressionAppendStyles(expression, builder, context, EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);

        private void AppendFilterExpressionUsingExpressionAppendStyles(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context, EntityExpressionAppendStyle entityAppendStyle, FieldExpressionAppendStyle fieldAppendStyle)
        {
            context.PushAppendStyles(entityAppendStyle, fieldAppendStyle);
            try
            {
                AppendFilterExpressionThatMayContainDBNull(expression, builder, context);
            }
            finally
            {
                context.PopAppendStyles();
            }
        }

        private void AppendFilterExpressionThatMayContainDBNull(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            //if either side of the filter expression is DBNull.Value, construct the side with an expression and append appropriate "IS NULL"
            if (expression.LeftArg.IsDBNull() || expression.RightArg.IsDBNull())
            {
                AppendFilterExpressionWithLeftOrRightEqualToDBNull(expression, builder, context);
            }
            else
            {
                //neither side of filter expression is DBNull.Value
                AppendFilterExpressionWithoutDBNull(expression, builder, context);
            }
        }

        private void AppendFilterExpressionWithLeftOrRightEqualToDBNull(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.LeftArg.IsDBNull())
            {
                AppendFilterExpressionWithDBNull(expression, expression.RightArg, builder, context);
            }
            else
            {
                AppendFilterExpressionWithDBNull(expression, expression.LeftArg, builder, context);
            }
        }

        private void AppendFilterExpressionWithDBNull(FilterExpression expression, IExpressionElement nonDBNull, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendElement(nonDBNull, context);
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

        private void AppendFilterExpressionWithoutDBNull(FilterExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Negate)
            {
                builder.Appender.Write("NOT (");
            }
            builder.AppendElement(expression.LeftArg, context);

            builder.Appender.Write(FilterOperatorMap[expression.ExpressionOperator]);
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
