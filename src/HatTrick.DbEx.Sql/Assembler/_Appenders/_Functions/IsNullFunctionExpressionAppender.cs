using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class IsNullFunctionExpressionAppender : ExpressionElementAppender<IsNullFunctionExpression>
    {
        #region methods
        public override void AppendElement(IsNullFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("ISNULL(");
            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(", ");
            builder.AppendElement(expression.Value, context);
            builder.Appender.Write(")");

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
