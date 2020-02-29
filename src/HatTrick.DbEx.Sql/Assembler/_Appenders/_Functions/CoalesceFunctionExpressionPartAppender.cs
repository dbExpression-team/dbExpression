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
            if (!(expression.Expression.Object is IList<ExpressionContainer> expressions) || !expressions.Any())
                return;

            builder.Appender.Write("COALESCE(");
            for (var i = 0; i < expressions.Count; i++)
            {
                builder.AppendPart(expressions[i], context);
                if (i < expressions.Count - 1)
                    builder.Appender.Write(", ");
            }
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
