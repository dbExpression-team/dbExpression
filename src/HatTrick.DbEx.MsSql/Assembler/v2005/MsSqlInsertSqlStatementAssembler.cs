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

﻿using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Assembler.v2005
{
    public class MsSqlInsertSqlStatementAssembler : InsertSqlStatementAssembler
    {
        #region methods
        protected override void AssembleStatement(InsertQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Inserts.Count > 1)
                throw new DbExpressionException("MsSql version 2005 does not support inserting multiple records in a single statement.");

            var inserts = (expression.Inserts.Values.Single() as IExpressionListProvider<InsertExpression>).Expressions.ToList();
            var identity = (expression.BaseEntity as IExpressionListProvider<FieldExpression>).Expressions.SingleOrDefault(x => builder.FindMetadata(x).IsIdentity);

            builder.Appender.Indent().Write("SET NOCOUNT ON;").LineBreak();
            builder.Appender.Indent().Write("INSERT INTO ");
            builder.AppendElement(expression.BaseEntity, context);
            builder.Appender.Write(" (").LineBreak();
            builder.Appender.Indentation++;

            for (var i = 0; i < inserts.Count; i++)
            {
                if (identity is object && (inserts[i] as IAssignmentExpressionProvider).Assignee == identity)
                    continue; //don't emit identity columns with the values; they can't be inserted into the table

                builder.Appender.Indent();
                builder.AppendElement(
                    (inserts[i] as IAssignmentExpressionProvider).Assignee,
                    context
                );
                if (i < inserts.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
            }

            builder.Appender.LineBreak()
                .Indentation--.Indent().Write(")").LineBreak();

            builder.Appender.Indent().Write("OUTPUT").LineBreak().Indentation++;

            //write the ordinal position for the single entity (required to support standard executor)
            builder.Appender.Indent().Write("0,").LineBreak();

            //write out all fields for the select from INSERTED table
            context.PushEntityAppendStyle(EntityExpressionAppendStyle.None);
            try
            {
                for (var i = 0; i < expression.Outputs.Count; i++)
                {
                    builder.Appender.Indent().Write("INSERTED.");
                    builder.AppendElement(
                        expression.Outputs[i],
                        context
                    );
                    if (i < expression.Outputs.Count - 1)
                        builder.Appender.Write(",");

                    builder.Appender.LineBreak();
                }
            }
            finally
            {
                context.PopEntityAppendStyle();
            }

            builder.Appender.Indentation--.Indent().Write("VALUES (").LineBreak()
                .Indentation++;

            //write the ordinal position for the single entity (required to support standard executor)
            //builder.Appender.Indent().Write("0,").LineBreak();

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            for (var i = 0; i < inserts.Count; i++)
            {
                if (identity is object && (inserts[i] as IAssignmentExpressionProvider).Assignee == identity)
                    continue; //don't emit identity columns with the values; they can't be inserted into the table

                builder.Appender.Indent();

                builder.AppendElement((inserts[i] as IAssignmentExpressionProvider).Assignment, context);

                if (i < inserts.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
            }
            context.PopAppendStyles();

            builder.Appender.LineBreak();
            builder.Appender.Indentation--;
            builder.Appender.Indent().Write(");").LineBreak();
        }
        #endregion
    }
}