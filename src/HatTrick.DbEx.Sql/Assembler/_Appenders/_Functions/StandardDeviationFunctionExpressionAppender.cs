using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class StandardDeviationFunctionExpressionAppender : ExpressionElementAppender<StandardDeviationFunctionExpression>
    {
        #region methods
        public override void AppendElement(StandardDeviationFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("STDEV(");

            AppendDistinct(expression, builder, context);

            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
