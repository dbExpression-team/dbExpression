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
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SelectSqlStatementAssembler : SqlStatementAssembler
    {
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression is not SelectQueryExpression select)
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(SelectQueryExpression)}, but is actually type {expression.GetType()}");
            AssembleStatement(select, builder, context);
        }

        protected virtual void AssembleStatement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);
            AppendOrderByClause(expression, builder, context);
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

        protected virtual void AppendFromClause(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent().Write("FROM").LineBreak();

            builder.Appender
                .Indentation++
                .Indent();

            context.PushEntityAppendStyle(EntityExpressionAppendStyle.Declaration);
            try
            {
                builder.AppendElement(expression.BaseEntity ?? throw new DbExpressionException("Expected base entity to not be null"), context);
            }
            finally
            {
                context.PopEntityAppendStyle();
            }

            builder.Appender
                .Indentation--
                .LineBreak();
        }

        protected virtual void AppendJoinClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions is null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            builder.AppendElement(expression.Joins, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendWhereClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Where is null)
                return;

            var elements = (expression.Where as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)?.Expression;
            if (!elements?.Args?.Any() ?? false)
                return;

            builder.Appender.Indent().Write("WHERE")
                .Indentation++;

            builder.Appender.LineBreak().Indent();

            builder.AppendElement(expression.Where, context);

            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendGroupByClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.GroupBy?.Expressions is null || !expression.GroupBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("GROUP BY").LineBreak()
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

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendHavingClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Having is null)
                return;

            var having = (expression.Having as IExpressionProvider<FilterExpressionSet>)?.Expression;
            if (having is null || (having as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>).Expression is null)
                return;

            builder.Appender.Indent().Write("HAVING").LineBreak()
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

            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendOrderByClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.OrderBy?.Expressions is null || !expression.OrderBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("ORDER BY").LineBreak()
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

            builder.Appender
                .Indentation--;
        }
    }
}