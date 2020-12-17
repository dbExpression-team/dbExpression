using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ExpressionMediatorAppender : ExpressionElementAppender<ExpressionMediator>
    {
        #region methods
        public override void AppendElement(ExpressionMediator expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendElement(expression.Expression, context);
        }
        #endregion
    }
}
