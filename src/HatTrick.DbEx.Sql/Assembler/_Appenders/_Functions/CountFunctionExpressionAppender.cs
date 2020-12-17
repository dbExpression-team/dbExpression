using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CountFunctionExpressionAppender : ExpressionElementAppender<CountFunctionExpression>
    {
        #region methods
        public override void AppendElement(CountFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("COUNT(");

            AppendDistinct(expression, builder, context);

            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
