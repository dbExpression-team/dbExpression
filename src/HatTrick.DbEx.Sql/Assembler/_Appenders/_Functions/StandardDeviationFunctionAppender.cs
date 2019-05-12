using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class StandardDeviationFunctionAppender :
        FunctionAppender,
        IAssemblyPartAppender<StandardDeviationFunctionExpression>
    {
        #region methods
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as StandardDeviationFunctionExpression, builder, context);

        public void AppendPart(StandardDeviationFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("STDEV(");

            AppendDistinct(expression, builder, context);

            builder.AppendPart(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
