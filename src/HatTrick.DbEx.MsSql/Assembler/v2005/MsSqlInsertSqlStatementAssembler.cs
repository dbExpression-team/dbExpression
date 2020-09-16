using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Data.SqlClient;
using System.Linq;

namespace HatTrick.DbEx.MsSql.v2005.Assembler
{
    public class MsSqlInsertSqlStatementAssembler : InsertSqlStatementAssembler
    {
        #region methods
        protected override void AssembleStatement(InsertQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Inserts.Count > 1)
                throw new DbExpressionException("MsSql version 2005 does not support inserting multiple records in a single statement.");

            var insertSet = expression.Inserts.Values.Single().Expressions;
            var identity = (expression.BaseEntity as IExpressionListProvider<FieldExpression>).Expressions.SingleOrDefault(x => builder.FindMetadata(x).IsIdentity);

            builder.Appender.Indent().Write("SET NOCOUNT ON;").LineBreak();
            builder.Appender.Indent().Write("INSERT INTO ");
            builder.AppendPart(expression.BaseEntity, context);
            builder.Appender.Write(" (").LineBreak();
            builder.Appender.Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Alias);
            try
            {
                for (var i = 0; i < insertSet.Count; i++)
                {
                    if (identity is object && (insertSet[i] as IAssignmentExpressionProvider).Assignee == identity)
                        continue; //don't emit identity columns with the values; they can't be inserted into the table

                    builder.Appender.Indent();
                    builder.AppendPart(
                        (insertSet[i] as IAssignmentExpressionProvider).Assignee,
                        context
                    );
                    if (i < insertSet.Count - 1)
                        builder.Appender.Write(", ").LineBreak();
                }
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.LineBreak()
                .Indentation--.Indent().Write(")").LineBreak();

            builder.Appender.Indent().Write("OUTPUT").LineBreak().Indentation++;

            //write the ordinal position for the single entity (required to support standard executor)
            builder.Appender.Indent().Write("0,").LineBreak();

            //write out all fields for the select from INSERTED table
            context.PushAppendStyle(EntityExpressionAppendStyle.None);
            try
            {
                for (var i = 0; i < insertSet.Count; i++)
                {
                    builder.Appender.Indent().Write("INSERTED.");
                    builder.AppendPart(
                        (insertSet[i] as IAssignmentExpressionProvider).Assignee,
                        context
                    );
                    if (i < insertSet.Count - 1)
                        builder.Appender.Write(",");

                    builder.Appender.LineBreak();
                }
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.Indentation--.Indent().Write("VALUES (").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            for (var i = 0; i < insertSet.Count; i++)
            {
                if (identity is object && (insertSet[i] as IAssignmentExpressionProvider).Assignee == identity)
                    continue; //don't emit identity columns with the values; they can't be inserted into the table

                builder.Appender.Indent();

                context.Field = (insertSet[i] as IAssignmentExpressionProvider).Assignee;
                builder.AppendPart((insertSet[i] as IAssignmentExpressionProvider).Assignment, context);
                context.Field = null;

                if (i < insertSet.Count - 1)
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