using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinAppender : 
        ExpressionAppender,
        IAssemblyPartAppender<JoinExpressionSet>,
        IAssemblyPartAppender<JoinExpression>
    {        
        public void AppendPart(JoinExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder");
        }

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as JoinExpression, builder, context);

        public void AppendPart(JoinExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent()
                .Write(expression.JoinType.ToString())
                .Write(" JOIN ");

            if (expression.JoinToo.Item2 is ExpressionSet joinExpression)
            {
                builder.Appender.Write(" (").LineBreak()
                    .Indentation++;

                //append the subquery
                builder.AppendPart(joinExpression, context);

                //append the subquery alias
                builder.Appender.Indentation--.Indent().Write(") AS ")
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write((expression as IDbExpressionAliasProvider).Alias)
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
