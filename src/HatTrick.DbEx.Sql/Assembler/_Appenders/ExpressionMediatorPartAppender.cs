using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ExpressionMediatorPartAppender : PartAppender<ExpressionMediator>
    {
        #region methods
        public override void AppendPart(ExpressionMediator expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendPart(expression.Expression, context);

            AppendAlias(expression, builder, context);
        }
        #endregion
    }
}
