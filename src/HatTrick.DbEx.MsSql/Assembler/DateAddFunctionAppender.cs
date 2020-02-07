using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DateAddFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<DateAddFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as DateAddFunctionExpression, builder, context);

        public void AppendPart(DateAddFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("DATEADD(")
                .Write(expression.DatePart.Item2.ToString().ToLower())
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
