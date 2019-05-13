using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.MsSql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DatePartFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<DatePartFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as DatePartFunctionExpression, builder, context);

        public void AppendPart(DatePartFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("DATEPART(")
                .Write(expression.DatePart.ToString().ToLower())
                .Write(", ");

            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
