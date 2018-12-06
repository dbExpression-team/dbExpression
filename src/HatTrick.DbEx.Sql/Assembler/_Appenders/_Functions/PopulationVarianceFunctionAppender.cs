using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class PopulationVarianceFunctionAppender :
        IAssemblyPartAppender<PopulationVarianceFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as PopulationVarianceFunctionExpression, builder, context);

        public void AppendPart(PopulationVarianceFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write("VARP(");
            if (expression.IsDistinct)
                builder.Appender.Write("DISTINCT ");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
