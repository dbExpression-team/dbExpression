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
    public abstract class DeleteSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!(expression is DeleteQueryExpression delete))
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(DeleteQueryExpression)}, but is actually type {expression.GetType()}");

            AssembleStatement(delete, builder, context);
        }

        protected virtual void AssembleStatement(DeleteQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent().Write("DELETE");

            if (expression.Top.HasValue)
            {
                builder.Appender.Write(" TOP(").Write(expression.Top.ToString()).Write(")");
            }
            builder.Appender.LineBreak()
                .Indentation++.Indent();

            builder.AppendElement(expression.BaseEntity, context);

            builder.Appender.LineBreak()
                .Indentation--.Indent().Write("FROM").LineBreak()
                .Indentation++.Indent();

            builder.AppendElement(expression.BaseEntity, context);

            builder.Appender.LineBreak()
                .Indentation--;

            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
        }

        protected virtual void AppendJoinClause(DeleteQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions is null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            builder.AppendElement(expression.Joins, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendWhereClause(DeleteQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Where?.LeftArg is null && expression.Where?.RightArg is null)
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