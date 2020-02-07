using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.MsSql.Assembler
{
    class DateDiffFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<DateDiffFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as DateDiffFunctionExpression, builder, context);

        public void AppendPart(DateDiffFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.DatePart.Item1 != typeof(DateParts))
                throw new DbExpressionConfigurationException($"Excpected {nameof(expression.DatePart)} property to have type {typeof(DateParts)}, but found type {nameof(expression.DatePart.Item1)}");

            builder.Appender
                .Write("DATEDIFF(")
                .Write(expression.DatePart.Item2.ToString().ToLower())
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
