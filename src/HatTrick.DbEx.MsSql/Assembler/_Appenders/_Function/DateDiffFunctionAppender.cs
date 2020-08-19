using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateDiffFunctionAppender : PartAppender<DateDiffFunctionExpression>
    {
        #region methods
        public override void AppendPart(DateDiffFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("DATEDIFF(")
                .Write(expression.DatePart.Expression.ToString().ToLower())
                .Write(", ");

            builder.AppendPart(expression.StartDate, context);
            builder.Appender.Write(", ");
            builder.AppendPart(expression.EndDate, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
