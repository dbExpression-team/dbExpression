using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class RawExpressionAppender : ExpressionElementAppender<RawExpression>
    {
        public override void AppendElement(RawExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.Appender.Write(expression.Expression);
    }
}
