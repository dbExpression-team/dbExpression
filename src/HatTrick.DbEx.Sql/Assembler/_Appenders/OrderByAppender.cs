using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class OrderByAppender :
        IAssemblyPartAppender<OrderByExpressionSet>,
        IAssemblyPartAppender<OrderByExpression>
    {
        public void AppendPart(OrderByExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            throw new NotImplementedException("Should be handled by outer builder");
        }
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as OrderByExpression, builder, context);

        public void AppendPart(OrderByExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(" ").Write(expression.Direction.ToString());
        }
    }
}
