using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class PopulationVarianceFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<PopulationVarianceFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as PopulationVarianceFunctionExpression, builder, context);

        public void AppendPart(PopulationVarianceFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
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
