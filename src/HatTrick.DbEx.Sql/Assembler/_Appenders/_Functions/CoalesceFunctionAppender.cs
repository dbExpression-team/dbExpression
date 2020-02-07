using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CoalesceFunctionAppender :
        ExpressionAppender,
        IAssemblyPartAppender<CoalesceFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression is CoalesceFunctionExpression exp)
            {
                AppendPart(exp, builder, context);
            }
            else if (expression is IList<(Type, object)> lst)
            {
                AppendPart(lst, builder, context);
            }
        }

        public void AppendPart(CoalesceFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            var expressions = expression.Expression.Item2 as IList<(Type,object)>;

            AppendPart(expressions, builder, context);
            AppendAlias(expression, builder, context);
        }

        public void AppendPart(IList<(Type,object)> expressions, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expressions == null || !expressions.Any())
                return;

            builder.Appender.Write("COALESCE(");
            for (var i = 0; i < expressions.Count; i++)
            {
                builder.AppendPart(expressions[i], context);
                if (i < expressions.Count - 1)
                    builder.Appender.Write(", ");
            }
            builder.Appender.Write(")");
        }
        #endregion
    }
}
