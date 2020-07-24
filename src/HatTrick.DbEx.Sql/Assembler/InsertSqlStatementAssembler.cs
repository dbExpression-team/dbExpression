using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class InsertSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!(expression is InsertQueryExpression insert))
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(InsertQueryExpression)}, but is actually type {expression.GetType()}");

            AssembleStatement(insert, builder, context);
        }

        private void AssembleStatement(InsertQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("INSERT INTO ");
            builder.AppendPart<EntityExpression>(expression.BaseEntity, context);
            builder.Appender.Write(" (").LineBreak();
            builder.Appender.Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Alias);
            for (var i = 0; i < expression.Insert.Expressions.Count; i++)
            {
                builder.Appender.Indent();
                builder.AppendPart(
                    (expression.Insert.Expressions[i] as IDbInsertExpressionProvider).Assignee, 
                    context
                );
                if (i < expression.Insert.Expressions.Count - 1)
                    builder.Appender.Write(", ").LineBreak();
            }
            context.PopAppendStyles();

            builder.Appender.LineBreak()
                .Indentation--.Write(") VALUES (").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);
            for (var i = 0; i < expression.Insert.Expressions.Count; i++)
            {
                builder.Appender.Indent();

                context.Field = (expression.Insert.Expressions[i] as IDbInsertExpressionProvider).Assignee;
                builder.AppendPart((expression.Insert.Expressions[i] as IDbInsertExpressionProvider).Assignment, context);
                context.Field = null;

                if (i < expression.Insert.Expressions.Count - 1)
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