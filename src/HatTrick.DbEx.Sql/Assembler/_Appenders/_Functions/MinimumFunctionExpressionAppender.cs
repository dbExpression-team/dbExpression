using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class MinimumFunctionExpressionAppender : ExpressionElementAppender<MinimumFunctionExpression>
    {
        #region methods
        public override void AppendElement(MinimumFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("MIN(");

            AppendDistinct(expression, builder, context);

            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
