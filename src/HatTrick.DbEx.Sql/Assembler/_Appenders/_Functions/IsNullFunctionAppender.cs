using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class IsNullFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<IsNullFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as IsNullFunctionExpression, builder, context);

        public void AppendPart(IsNullFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write("ISNULL(");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(", ");
            builder.AppendPart(expression.Value, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
