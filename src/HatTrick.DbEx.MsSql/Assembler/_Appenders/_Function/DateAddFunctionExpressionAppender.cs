using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateAddFunctionExpressionAppender : ExpressionElementAppender<DateAddFunctionExpression>
    {
        #region methods
        public override void AppendElement(DateAddFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("DATEADD(")
                .Write(expression.DatePart.Expression.ToString().ToLower())
                .Write(", ");

            builder.AppendElement(expression.Value, context);
            builder.Appender.Write(", ");
            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
