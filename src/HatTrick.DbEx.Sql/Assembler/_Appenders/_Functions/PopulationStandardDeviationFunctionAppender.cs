using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class PopulationStandardDeviationFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<PopulationStandardDeviationFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as PopulationStandardDeviationFunctionExpression, builder, context);

        public void AppendPart(PopulationStandardDeviationFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
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
