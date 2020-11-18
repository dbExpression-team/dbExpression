using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class OrderByExpressionAppender : ExpressionElementAppender<OrderByExpression>
    {
        public override void AppendElement(OrderByExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(" ")
                .Write(expression.Direction.ToString());
        }
    }
}
