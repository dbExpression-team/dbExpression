using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlInsertSqlStatementAssembler : InsertSqlStatementAssembler
    {
        #region methods
        protected override void AssembleStatement(InsertQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            AssembleStatementUsingMergeStrategy(expression, builder, context);
        }

        protected void AssembleStatementUsingMergeStrategy(InsertQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            const string ordinalColumnName = "ordinal";
            const string insertValuesName = "__values";

            var template = expression.Inserts.First().Value;
            var identity = (expression.BaseEntity as IExpressionListProvider<FieldExpression>).Expressions.SingleOrDefault(x => builder.FindMetadata(x).IsIdentity);

            builder.Appender.Indent().Write("SET NOCOUNT ON;").LineBreak();
            builder.Appender.Indent().Write("MERGE ");
            builder.AppendPart(expression.BaseEntity, context);
            builder.Appender.Write(" USING (").LineBreak();

            builder.Appender.Indent().Write("VALUES").LineBreak().Indentation++;

            //write out the field values, which will become parameters
            for (var i = 0; i < expression.Inserts.Count; i++)
            {
                var insert = expression.Inserts.Single(x => x.Key == i);

                builder.Appender.Indent().Write("(");

                for (var j = 0; j < insert.Value.Expressions.Count; j++)
                {
                    if (identity is object && (insert.Value.Expressions[j] as IAssignmentExpressionProvider).Assignee == identity)
                        continue; //don't emit identity columns with the values; they can't be inserted into the table

                    context.PushField((insert.Value.Expressions[j] as IAssignmentExpressionProvider).Assignee);
                    try
                    {
                        builder.AppendPart((insert.Value.Expressions[j] as IAssignmentExpressionProvider).Assignment, context);
                    }
                    finally
                    {
                        context.PopField();
                    }
                    builder.Appender.Write(", ");
                    if (j == insert.Value.Expressions.Count - 1)
                        builder.Appender.Write(i.ToString());
                }

                builder.Appender.Write(")");
                if (i < expression.Inserts.Count() - 1)
                    builder.Appender.Write(", ").LineBreak();
            }

            builder.Appender.LineBreak().Indentation--;

            builder.Appender.Indent().Write(") AS ")
                .Write(context.Configuration.IdentifierDelimiter.Begin)
                .Write(insertValuesName)
                .Write(context.Configuration.IdentifierDelimiter.End)
                .Indent().Write(" (").LineBreak()
                .Indentation++;

            //write out the table structure of the  {insertValueNames} table
            for (var i = 0; i < template.Expressions.Count; i++)
            {
                if (identity is object && (template.Expressions[i] as IAssignmentExpressionProvider).Assignee == identity)
                    continue; //don't emit identity columns with the values; they can't be inserted into the table

                builder.Appender.Indent();
                builder.AppendPart(
                    (template.Expressions[i] as IAssignmentExpressionProvider).Assignee,
                    context
                );
                builder.Appender.Write(", ").LineBreak();
                if (i == template.Expressions.Count - 1)
                {
                    builder.Appender.Indent().Write(context.Configuration.IdentifierDelimiter.Begin)
                        .Write(ordinalColumnName)
                        .Write(context.Configuration.IdentifierDelimiter.End);
                }
            }

            builder.Appender.LineBreak().Indentation--
                .Indent().Write(") ON 1 != 1").LineBreak()
                .Indent().Write("WHEN NOT MATCHED THEN").LineBreak()
                .Indent().Write("INSERT (").LineBreak().Indentation++;

            for (var i = 0; i < template.Expressions.Count; i++)
            {
                if (identity is object && (template.Expressions[i] as IAssignmentExpressionProvider).Assignee == identity)
                    continue; //don't emit identity columns with the values; they can't be inserte into the table

                builder.Appender.Indent();
                builder.AppendPart(
                    (template.Expressions[i] as IAssignmentExpressionProvider).Assignee,
                    context
                );
                if (i < template.Expressions.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
                else
                    builder.Appender.LineBreak();
            }
            builder.Appender.Indentation--.Indent().Write(") VALUES (").LineBreak().Indentation++;

            //write out any non-identity field names as the values from the {insertValueNames} table
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.None);
            try
            {
                for (var i = 0; i < template.Expressions.Count; i++)
                {
                    if (identity is object && (template.Expressions[i] as IAssignmentExpressionProvider).Assignee == identity)
                        continue; //don't emit identity columns with the values; they can't be inserted into the table

                    builder.Appender.Indent().Write(context.Configuration.IdentifierDelimiter.Begin)
                        .Write(insertValuesName)
                        .Write(context.Configuration.IdentifierDelimiter.End)
                        .Write(".");

                    context.PushField((template.Expressions[i] as IAssignmentExpressionProvider).Assignee);
                    try
                    {
                        builder.AppendPart((template.Expressions[i] as IAssignmentExpressionProvider).Assignee, context);
                    }
                    finally
                    {
                        context.PopField();
                    }
                    if (i < template.Expressions.Count - 1)
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
            builder.Appender.Indent().Write(insertValuesName);

            //write the delimited ordinal column name
            builder.Appender.Write(".")
                .Write(context.Configuration.IdentifierDelimiter.Begin)
                .Write(ordinalColumnName)
                .Write(context.Configuration.IdentifierDelimiter.End)
                .Write(", ").LineBreak();

            //write out all fields for the select from INSERTED table
            for (var i = 0; i < template.Expressions.Count; i++)
            {
                builder.Appender.Indent();
                builder.Appender.Write("INSERTED.");
                builder.AppendPart(
                    (template.Expressions[i] as IAssignmentExpressionProvider).Assignee,
                    context
                );
                if (i < template.Expressions.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
            }
        }
        #endregion
    }
}