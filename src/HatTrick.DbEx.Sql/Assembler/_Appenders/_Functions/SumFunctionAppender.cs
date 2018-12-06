using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SumFunctionAppender :
        IAssemblyPartAppender<SumFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as SumFunctionExpression, builder, context);

        public void AppendPart(SumFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write("SUM(");
            if (expression.IsDistinct)
                builder.Appender.Write("DISTINCT ");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
