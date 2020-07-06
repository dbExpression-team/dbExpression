using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CoalesceFunctionExpressionPartAppender : PartAppender<CoalesceFunctionExpression>
    {
        #region methods
        public override void AppendPart(CoalesceFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!expression.Expression.Any())
                return;

            builder.Appender.Write("COALESCE(");
            for (var i = 0; i < expression.Expression.Count; i++)
            {
                builder.AppendPart(expression.Expression[i], context);
                if (i < expression.Expression.Count - 1)
                    builder.Appender.Write(", ");
            }
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
