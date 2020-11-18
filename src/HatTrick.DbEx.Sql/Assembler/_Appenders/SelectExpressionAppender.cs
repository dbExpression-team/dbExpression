using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectExpressionAppender : ExpressionElementAppender<SelectExpression>
    {
        #region methods
        public override void AppendElement(SelectExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendElement(expression.Expression, context);
            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
