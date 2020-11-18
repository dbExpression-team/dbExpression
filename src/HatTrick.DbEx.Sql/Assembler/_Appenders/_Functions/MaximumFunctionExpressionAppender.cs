using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class MaximumFunctionExpressionAppender : ExpressionElementAppender<MaximumFunctionExpression>
    {
        #region methods
        public override void AppendElement(MaximumFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("MAX(");

            AppendDistinct(expression, builder, context);

            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
