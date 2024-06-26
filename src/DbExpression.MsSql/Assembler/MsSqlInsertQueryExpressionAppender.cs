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

using DbExpression.Sql;
using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using System.Linq;

namespace DbExpression.MsSql.Assembler
{
    public class MsSqlInsertQueryExpressionAppender : InsertQueryExpressionAppender
    {
        #region methods
        public override void AppendElement(InsertQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            const string ordinalColumnName = "__ordinal";
            const string insertValuesName = "__values";

            var template = expression.Inserts.First().Value;
            var identityField = expression.Into!.Fields.SingleOrDefault(field =>
            {
                var column = builder.GetPlatformMetadata(field);
                return column.IsIdentity == true;
            });
            var identity = identityField is not null ? identityField as FieldExpression ??
                DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<FieldExpression>(expression)
                : null;

            builder.Appender.Indent().Write("SET NOCOUNT ON;").LineBreak();
            builder.Appender.Indent().Write("MERGE ");
            context.PushEntityAppendStyle(EntityExpressionAppendStyle.Name);
            try
            {
                builder.AppendElement(expression.Into, context);
            }
            finally
            { 
                context.PopEntityAppendStyle();
            }
            builder.Appender.Write(" USING (").LineBreak();

            builder.Appender.Indent().Write("VALUES").LineBreak().Indentation++;

            //write out the field values, which will become parameters
            for (var i = 0; i < expression.Inserts.Count; i++)
            {
                var insert = expression.Inserts.Single(x => x.Key == i);

                builder.Appender.Indent().Write("(");

                var inserts = (insert.Value as IExpressionListProvider<InsertExpression>).Expressions.ToList();
                for (var j = 0; j < inserts.Count; j++)
                {
                    if (identity is not null && (inserts[j] as IAssignmentExpressionProvider).Assignee == identity)
                        continue; //don't emit identity columns with the values; they can't be inserted into the table

                    var originalTryShareParameterSetting = context.TrySharingExistingParameter;
                    context.TrySharingExistingParameter = true;
                    try
                    {
                        builder.AppendElement((inserts[j] as IAssignmentExpressionProvider).Assignment, context);
                    }
                    finally
                    {
                        context.TrySharingExistingParameter = originalTryShareParameterSetting;
                    }
                    builder.Appender.Write(", ");
                    if (j == inserts.Count - 1)
                        builder.Appender.Write(i.ToString());
                }

                builder.Appender.Write(")");
                if (i < expression.Inserts.Count() - 1)
                    builder.Appender.Write(", ").LineBreak();
            }

            builder.Appender.LineBreak().Indentation--;

            builder.Appender.Indent().Write(") AS ")
                .Write(context.IdentifierDelimiter.Begin)
                .Write(insertValuesName)
                .Write(context.IdentifierDelimiter.End)
                .Indent().Write(" (").LineBreak()
                .Indentation++;

            //write out the table structure of the  {insertValueNames} table
            var templateInserts = (template as IExpressionListProvider<InsertExpression>).Expressions.ToList();
            for (var i = 0; i < templateInserts.Count; i++)
            {
                if (identity is not null && (templateInserts[i] as IAssignmentExpressionProvider).Assignee == identity)
                    continue; //don't emit identity columns with the values; they can't be inserted into the table

                builder.Appender.Indent();
                builder.AppendElement(
                    (templateInserts[i] as IAssignmentExpressionProvider).Assignee,
                    context
                );
                builder.Appender.Write(", ").LineBreak();
                if (i == templateInserts.Count - 1)
                {
                    builder.Appender.Indent().Write(context.IdentifierDelimiter.Begin)
                        .Write(ordinalColumnName)
                        .Write(context.IdentifierDelimiter.End);
                }
            }

            builder.Appender.LineBreak().Indentation--
                .Indent().Write(") ON 1 != 1").LineBreak()
                .Indent().Write("WHEN NOT MATCHED THEN").LineBreak()
                .Indent().Write("INSERT (").LineBreak().Indentation++;

            for (var i = 0; i < templateInserts.Count; i++)
            {
                if (identity is not null && (templateInserts[i] as IAssignmentExpressionProvider).Assignee == identity)
                    continue; //don't emit identity columns with the values; they can't be insert into the table

                builder.Appender.Indent();
                builder.AppendElement(
                    (templateInserts[i] as IAssignmentExpressionProvider).Assignee,
                    context
                );
                if (i < templateInserts.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
                else
                    builder.Appender.LineBreak();
            }
            builder.Appender.Indentation--.Indent().Write(") VALUES (").LineBreak().Indentation++;

            //write out any non-identity field names as the values from the {insertValueNames} table
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.None);
            try
            {
                for (var i = 0; i < templateInserts.Count; i++)
                {
                    if (identity is object && (templateInserts[i] as IAssignmentExpressionProvider).Assignee == identity)
                        continue; //don't emit identity columns with the values; they can't be inserted into the table

                    builder.Appender.Indent().Write(context.IdentifierDelimiter.Begin)
                        .Write(insertValuesName)
                        .Write(context.IdentifierDelimiter.End)
                        .Write(".");

                    builder.AppendElement((templateInserts[i] as IAssignmentExpressionProvider).Assignee, context);

                    if (i < templateInserts.Count - 1)
                        builder.Appender.Write(", ");
                    builder.Appender.LineBreak();
                }
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.Write(")").LineBreak().Indentation--;

            builder.Appender.Indent().Write("OUTPUT").LineBreak().Indentation++;
            builder.Appender.Indent()
                .Write(context.IdentifierDelimiter.Begin)
                .Write(insertValuesName)
                .Write(context.IdentifierDelimiter.End);

            //write the delimited ordinal column name
            builder.Appender.Write(".")
                .Write(context.IdentifierDelimiter.Begin)
                .Write(ordinalColumnName)
                .Write(context.IdentifierDelimiter.End)
                .Write(", ").LineBreak();

            //write out all fields for the select from INSERTED table
            for (var i = 0; i < expression.Outputs.Count; i++)
            {
                builder.Appender.Indent();
                builder.Appender
                    .Write(context.IdentifierDelimiter.Begin)
                    .Write("inserted")
                    .Write(context.IdentifierDelimiter.End)
                    .Write('.');
                builder.AppendElement(
                    expression.Outputs[i],
                    context
                );
                if (i < expression.Outputs.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
            }
        }
        #endregion
    }
}