using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectExpressionPartAppender : PartAppender<SelectExpression>
    {
        #region methods
        public override void AppendPart(SelectExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.AppendPart(expression.Expression, context);
        #endregion
    }
}
