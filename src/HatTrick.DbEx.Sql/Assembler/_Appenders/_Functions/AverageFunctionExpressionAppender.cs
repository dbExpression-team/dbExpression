using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AverageFunctionExpressionAppender : ExpressionElementAppender<AverageFunctionExpression>
    {
        #region methods
        public override void AppendElement(AverageFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("AVG(");

            AppendDistinct(expression, builder, context);

            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
