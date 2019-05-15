using HatTrick.DbEx.MsSql.Expression;
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
        FunctionAppender,
        IAssemblyPartAppender<DateDiffFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as DateDiffFunctionExpression, builder, context);

        public void AppendPart(DateDiffFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Write("DATEDIFF(")
                .Write(expression.DatePart.ToString().ToLower())
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
