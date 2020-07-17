using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class OrderByExpressionSetPartAppender : PartAppender<OrderByExpressionSet>
    {
        public override void AppendPart(OrderByExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression?.Expressions is null || !expression.Expressions.Any())
                return;

            for (var i = 0; i < expression.Expressions.Count; i++)
            {
                builder.Appender.Indent();

                if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                    builder.Appender.Write(",");

                builder.AppendPart(expression.Expressions[i], context);

                if (!context.Configuration.PrependCommaOnSelectClauseParts && i < expression.Expressions.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }
        }
    }
}
