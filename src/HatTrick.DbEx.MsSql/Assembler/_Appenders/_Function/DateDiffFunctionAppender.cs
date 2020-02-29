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
    public class DateDiffFunctionAppender : PartAppender<DateDiffFunctionExpression>
    {
        #region methods
        public override void AppendPart(DateDiffFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.DatePart.Type != typeof(DateParts))
                throw new DbExpressionConfigurationException($"Expected {nameof(expression.DatePart)} property to have type {typeof(DateParts)}, but found type {nameof(expression.DatePart.Type)}");

            builder.Appender
                .Write("DATEDIFF(")
                .Write(expression.DatePart.Object.ToString().ToLower())
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
