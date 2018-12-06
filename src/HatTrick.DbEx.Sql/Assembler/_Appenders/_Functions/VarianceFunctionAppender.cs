using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class VarianceFunctionAppender :
        IAssemblyPartAppender<VarianceFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as VarianceFunctionExpression, builder, context);

        public void AppendPart(VarianceFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write("VAR(");
            if (expression.IsDistinct)
                builder.Appender.Write("DISTINCT ");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
