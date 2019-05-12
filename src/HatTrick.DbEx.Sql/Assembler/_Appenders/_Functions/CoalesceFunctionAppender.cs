using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Attribute;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CoalesceFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<CoalesceFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as CoalesceFunctionExpression, builder, context);

        public void AppendPart(CoalesceFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("COALESCE(");
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
