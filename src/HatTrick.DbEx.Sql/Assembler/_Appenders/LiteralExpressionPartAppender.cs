using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class LiteralExpressionPartAppender : PartAppender<LiteralExpression>
    {
        public override void AppendPart(LiteralExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.AppendPart(expression.Expression, context);
    }
}
