using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class RawExpressionPartAppender : PartAppender<RawExpression>
    {
        public override void AppendPart(RawExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
            => builder.Appender.Write(expression.Expression);
    }
}
