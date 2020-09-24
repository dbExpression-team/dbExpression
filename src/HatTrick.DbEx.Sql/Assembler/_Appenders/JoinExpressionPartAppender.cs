using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinExpressionPartAppender : PartAppender<JoinExpression>
    {        
        public override void AppendPart(JoinExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent()
                .Write(expression.JoinType.ToString())
                .Write(" JOIN ");

            if (expression.JoinToo is QueryExpression joinExpression)
            {
                builder.Appender.Write("(").LineBreak()
                    .Indentation++;

                //append the subquery
                builder.AppendPart(joinExpression, context);

                //append the subquery alias
                builder.Appender.Indentation--.Indent().Write(") AS ")
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write((expression as IExpressionAliasProvider).Alias)
                    .Write(context.Configuration.IdentifierDelimiter.End)
                    .Write(" ON ");

                builder.AppendPart(expression.JoinOnExpression, context);

                return;
            }

            context.PushAppendStyle(EntityExpressionAppendStyle.Declaration);
            builder.AppendPart(expression.JoinToo, context);
            context.PopAppendStyles();

            if (expression.JoinType == JoinOperationExpressionOperator.CROSS)
                return;

            builder.Appender.Write(" ON ");
            builder.AppendPart(expression.JoinOnExpression, context);
        }
    }
}
