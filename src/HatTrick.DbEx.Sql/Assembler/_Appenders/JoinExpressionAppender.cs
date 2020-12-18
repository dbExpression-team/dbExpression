using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinExpressionAppender : ExpressionElementAppender<JoinExpression>
    {        
        public override void AppendElement(JoinExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent()
                .Write(expression.JoinType.ToString())
                .Write(" JOIN ");

            if (expression.JoinToo is QueryExpression joinExpression)
            {
                builder.Appender.Write("(").LineBreak()
                    .Indentation++;

                //append the subquery
                builder.AppendElement(joinExpression, context);

                //append the subquery alias
                builder.Appender.Indentation--.Indent().Write(") AS ")
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write((expression as IExpressionAliasProvider).Alias)
                    .Write(context.Configuration.IdentifierDelimiter.End)
                    .Write(" ON ");

                builder.AppendElement(expression.JoinOnExpression, context);

                return;
            }

            context.PushEntityAppendStyle(EntityExpressionAppendStyle.Declaration);
            builder.AppendElement(expression.JoinToo, context);
            context.PopEntityAppendStyle();

            if (expression.JoinType == JoinOperationExpressionOperator.CROSS)
                return;

            builder.Appender.Write(" ON ");
            builder.AppendElement(expression.JoinOnExpression, context);
        }
    }
}
