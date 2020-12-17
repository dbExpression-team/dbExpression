using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ConcatFunctionExpressionAppender : ExpressionElementAppender<ConcatFunctionExpression>
    {
        #region methods
        public override void AppendElement(ConcatFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!expression.Expression.Any())
                return;

            builder.Appender.Write("CONCAT(");
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
