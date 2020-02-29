using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class PopulationVarianceFunctionExpressionPartAppender : PartAppender<PopulationVarianceFunctionExpression>
    {
        #region methods
        public override void AppendPart(PopulationVarianceFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("VARP(");

            AppendDistinct(expression, builder, context);

            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
