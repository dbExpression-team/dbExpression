using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class CeilingFunctionExpressionAppender : ExpressionElementAppender<CeilingFunctionExpression>
    {
        #region methods
        public override void AppendElement(CeilingFunctionExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("CEILING(");
            builder.AppendElement(expression.Expression, context);
            builder.Appender.Write(")");
        }
        #endregion
    }
}
