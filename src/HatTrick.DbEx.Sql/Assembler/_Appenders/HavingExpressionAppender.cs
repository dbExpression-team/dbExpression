using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class HavingExpressionAppender : ExpressionElementAppender<HavingExpression>
    {
        public override void AppendElement(HavingExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent();
            builder.AppendElement(expression.Expression, context);
        }
    }
}
