using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class PopulationVarianceFunctionExpressionAppender : ExpressionElementAppender<PopulationVarianceFunctionExpression>
    {
        #region methods
        public override void AppendElement(PopulationVarianceFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("VARP(");

            AppendDistinct(expression, builder, context);

            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
