using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class MaximumFunctionAppender :
        IAssemblyPartAppender<MaximumFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as MaximumFunctionExpression, builder, context);

        public void AppendPart(MaximumFunctionExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write("MAX(");
            if (expression.IsDistinct)
                builder.Appender.Write("DISTINCT ");
            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
