using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CoalesceFunctionExpressionAppender : ExpressionElementAppender<CoalesceFunctionExpression>
    {
        #region methods
        public override void AppendElement(CoalesceFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!expression.Expression.Any())
                return;

            builder.Appender.Write("COALESCE(");
            for (var i = 0; i < expression.Expression.Count; i++)
            {
                builder.AppendElement(expression.Expression[i], context);
                if (i < expression.Expression.Count - 1)
                    builder.Appender.Write(", ");
            }
            builder.Appender.Write(")");
        }
        #endregion
    }
}
