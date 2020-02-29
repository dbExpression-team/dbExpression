using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class DatePartFunctionAppender : PartAppender<DatePartFunctionExpression>
    {
        #region methods
        public override void AppendPart(DatePartFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.DatePart.Type != typeof(DateParts))
                throw new DbExpressionConfigurationException($"Expected {nameof(expression.DatePart)} property to have type {typeof(DateParts)}, but found type {nameof(expression.DatePart.Type)}");

            builder.Appender
                .Write("DATEPART(")
                .Write(expression.DatePart.Object.ToString().ToLower())
                .Write(", ");

            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
