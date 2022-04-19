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
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class UpdateSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression is not UpdateQueryExpression update)
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(UpdateQueryExpression)}, but is actually type {expression.GetType()}");

            AssembleStatement(update, builder, context);
        }
        
        protected virtual void AssembleStatement(UpdateQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Indent().Write("UPDATE");

            if (expression.Top.HasValue)
            {
                builder.Appender.Write(" TOP(").Write(expression.Top.Value.ToString()).Write(")");
            }

            builder.Appender.LineBreak()
                .Indentation++.Indent();

            context.PushEntityAppendStyle(EntityExpressionAppendStyle.None);
            try
            {
                builder.AppendElement(expression.BaseEntity ?? throw new DbExpressionException("Expected base entity to not be null"), context);
            }
            finally
            {
                context.PopEntityAppendStyle();
            }

            builder.Appender
                .Indentation--.LineBreak()
                .Indent().Write("SET").LineBreak()
                .Indentation++;

            builder.AppendElement(expression.Assign, context);

            builder.Appender.LineBreak()
                .Indentation--.Indent().Write("FROM").LineBreak()
                .Indentation++.Indent();

            context.PushEntityAppendStyle(EntityExpressionAppendStyle.Declaration);
            try
            {
                builder.AppendElement(expression.BaseEntity, context);
            }
            finally
            {
                context.PopEntityAppendStyle();
            }

            builder.Appender.LineBreak()
                .Indentation--;
            
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
        }

        protected virtual void AppendJoinClause(UpdateQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions is null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            builder.AppendElement(expression.Joins, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendWhereClause(UpdateQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
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
        #endregion
    }
}