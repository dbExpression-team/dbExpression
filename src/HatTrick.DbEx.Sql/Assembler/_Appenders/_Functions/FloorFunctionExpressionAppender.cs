using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FloorFunctionExpressionAppender : ExpressionElementAppender<FloorFunctionExpression>
    {
        #region methods
        public override void AppendElement(FloorFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("FLOOR(");
            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
