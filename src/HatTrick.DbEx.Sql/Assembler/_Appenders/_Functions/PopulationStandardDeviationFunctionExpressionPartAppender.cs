using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class PopulationStandardDeviationFunctionExpressionPartAppender : PartAppender<PopulationStandardDeviationFunctionExpression>
    {
        #region methods
        public override void AppendPart(PopulationStandardDeviationFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("STDEVP(");

            AppendDistinct(expression, builder, context);

            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
