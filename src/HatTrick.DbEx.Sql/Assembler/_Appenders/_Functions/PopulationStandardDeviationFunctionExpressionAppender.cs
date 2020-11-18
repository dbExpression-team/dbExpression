using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class PopulationStandardDeviationFunctionExpressionAppender : ExpressionElementAppender<PopulationStandardDeviationFunctionExpression>
    {
        #region methods
        public override void AppendElement(PopulationStandardDeviationFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("STDEVP(");

            AppendDistinct(expression, builder, context);

            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
