using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DatePartFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<DatePartFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as DatePartFunctionExpression, builder, context);

        public void AppendPart(DatePartFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.DatePart.Item1 != typeof(DateParts))
                throw new DbExpressionConfigurationException($"Excpected {nameof(expression.DatePart)} property to have type {typeof(DateParts)}, but found type {nameof(expression.DatePart.Item1)}");

            builder.Appender
                .Write("DATEPART(")
                .Write(expression.DatePart.Item2.ToString().ToLower())
                .Write(", ");

            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
