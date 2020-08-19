using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateAddFunctionAppender : PartAppender<DateAddFunctionExpression>
    {
        #region methods
        public override void AppendPart(DateAddFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("DATEADD(")
                .Write(expression.DatePart.Expression.ToString().ToLower())
                .Write(", ");

            builder.AppendPart(expression.Value, context);
            builder.Appender.Write(", ");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
