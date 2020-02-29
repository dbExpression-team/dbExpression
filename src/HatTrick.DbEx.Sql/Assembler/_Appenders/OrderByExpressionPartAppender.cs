using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class OrderByExpressionPartAppender : PartAppender<OrderByExpression>
    {
        public override void AppendPart(OrderByExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(" ")
                .Write(expression.Direction.ToString());
        }
    }
}
