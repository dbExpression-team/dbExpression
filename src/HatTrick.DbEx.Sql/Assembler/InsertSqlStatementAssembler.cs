using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class InsertSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
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
                    expression.Insert.Expressions[i].Expression.LeftPart, 
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

                context.Field = expression.Insert.Expressions[i].Expression.LeftPart.Object as FieldExpression;
                builder.AppendPart(expression.Insert.Expressions[i].Expression.RightPart, context);
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