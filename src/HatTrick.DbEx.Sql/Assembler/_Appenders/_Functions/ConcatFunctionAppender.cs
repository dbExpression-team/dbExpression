using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ConcatFunctionAppender : 
         FunctionAppender,
        IAssemblyPartAppender<ConcatFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as ConcatFunctionExpression, builder, context);

    public void AppendPart(ConcatFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
    {
        builder.Appender.Write("CONCAT(");
        for (var i = 0; i < expression.Expressions.Count; i++)
        {
            builder.AppendPart(expression.Expressions[i], context);
            if (i < expression.Expressions.Count - 1)
                builder.Appender.Write(", ");
        }
        builder.Appender.Write(")");

        AppendAlias(expression, builder, context);
    }
    #endregion
    }
}
