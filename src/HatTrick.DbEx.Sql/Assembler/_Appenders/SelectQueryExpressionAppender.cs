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
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectQueryExpressionAppender : ExpressionElementAppender<SelectQueryExpression>
    {
        public override void AppendElement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);
            AppendOrderByClause(expression, builder, context);
            AppendContinuationExpression(expression, builder, context);
        }

        protected virtual void AppendSelectClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Indent().Write("SELECT");

            if (expression.Distinct == true)
            {
                builder.Appender.Write(" DISTINCT");
            }

            if (expression.Top.HasValue)
            {
                builder.Appender.Write(" TOP(").Write(expression.Top.Value.ToString()).Write(")");
            }

            builder.Appender.LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Declaration);
            try
            {
                builder.AppendElement(expression.Select, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.Indentation--;
        }

        protected virtual void AppendFromClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.From?.Expression is null)
                throw new DbExpressionException($"Expected {nameof(expression.From)} expression to not be null.", new ArgumentNullException(nameof(expression)));

            builder.Appender.LineBreak().Indent().Write("FROM").LineBreak();

            builder.AppendElement(expression.From, context);
        }

        protected virtual void AppendJoinClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions is null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender.LineBreak().Indentation++;

            builder.AppendElement(expression.Joins, context);

            builder.Appender.Indentation--;
        }

        protected virtual void AppendWhereClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Where is null)
                return;

            var elements = (expression.Where as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)?.Expression;
            if (!elements?.Args?.Any() ?? false)
                return;

            builder.Appender.LineBreak()
                .Indent().Write("WHERE")
                .Indentation++;

            builder.Appender.LineBreak().Indent();

            builder.AppendElement(expression.Where, context);

            builder.Appender.Indentation--;
        }

        protected virtual void AppendGroupByClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.GroupBy?.Expressions is null || !expression.GroupBy.Expressions.Any())
                return;

            builder.Appender.LineBreak()
                .Indent().Write("GROUP BY").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            try
            {
                builder.AppendElement(expression.GroupBy, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.Indentation--;
        }

        protected virtual void AppendHavingClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Having is null)
                return;

            var having = (expression.Having as IExpressionProvider<FilterExpressionSet>)?.Expression;
            if (having is null || (having as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>).Expression is null)
                return;

            builder.Appender.LineBreak().Indent().Write("HAVING").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            try
            {
                builder.AppendElement(expression.Having, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.Indentation--;
        }

        protected virtual void AppendOrderByClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.OrderBy?.Expressions is null || !expression.OrderBy.Expressions.Any())
                return;

            builder.Appender.LineBreak().Indent().Write("ORDER BY").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            try
            {
                builder.AppendElement(expression.OrderBy, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.Indentation--;
        }

        protected virtual void AppendContinuationExpression(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.ContinuationExpression is null || expression.ContinuationExpression.ContinuationExpression is null || expression.ContinuationExpression.Expression is null)
                return;

            builder.AppendElement(expression.ContinuationExpression, context);
        }
    }
}