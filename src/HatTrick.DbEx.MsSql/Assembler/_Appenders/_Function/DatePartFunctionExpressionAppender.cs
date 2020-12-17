using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DatePartFunctionExpressionAppender : ExpressionElementAppender<DatePartFunctionExpression>
    {
        #region methods
        public override void AppendElement(DatePartFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("DATEPART(")
                .Write(expression.DatePart.Expression.ToString().ToLower())
                .Write(", ");

            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
