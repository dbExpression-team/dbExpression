using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
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

            builder.Appender.Write("INSERT INTO ");
            builder.AppendPart(expression.BaseEntity, context);
            builder.Appender.Write(" (").LineBreak();
            builder.Appender.Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Alias);
            for (var i = 0; i < insertSet.Count; i++)
            {
                builder.Appender.Indent();
                builder.AppendPart(
                    insertSet[i],
                    context
                );
                if (i < insertSet.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
            }
            context.PopAppendStyles();

            builder.Appender.LineBreak()
                .Indentation--.Write(") VALUES (").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            for (var i = 0; i < insertSet.Count; i++)
            {
                builder.Appender.Indent();

                context.Field = (insertSet[i] as IAssignmentExpressionProvider).Assignee;
                builder.AppendPart(insertSet[i], context);
                context.Field = null;

                if (i < insertSet.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
            }
            context.PopAppendStyles();

            builder.Appender.LineBreak();
            builder.Appender.Indentation--;
            builder.Appender.Indent().Write(")");
        }
        #endregion
    }
}