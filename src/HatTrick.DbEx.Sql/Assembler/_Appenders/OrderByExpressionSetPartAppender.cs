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

            var orderBys = expression.Expressions.ToList();
            for (var i = 0; i < orderBys.Count; i++)
            {
                builder.Appender.Indent();

                if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                    builder.Appender.Write(",");

                builder.AppendPart(orderBys[i], context);

                if (!context.Configuration.PrependCommaOnSelectClauseParts && i < orderBys.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }
        }
    }
}
