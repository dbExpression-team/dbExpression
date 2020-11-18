using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateDiffFunctionExpressionAppender : ExpressionElementAppender<DateDiffFunctionExpression>
    {
        #region methods
        public override void AppendElement(DateDiffFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("DATEDIFF(")
                .Write(expression.DatePart.Expression.ToString().ToLower())
                .Write(", ");

            builder.AppendElement(expression.StartDate, context);
            builder.Appender.Write(", ");
            builder.AppendElement(expression.EndDate, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
