using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SumFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<SumFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as SumFunctionExpression, builder, context);

        public void AppendPart(SumFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write("SUM(");

            AppendDistinct(expression, builder, context);

            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
