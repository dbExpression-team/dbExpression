using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class FunctionAppender
    {
        public void AppendDistinct(IDbExpressionIsDistinctProvider distinct, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (distinct.IsDistinct)
                builder.Appender.Write("DISTINCT ");
        }

        public void AppendAlias(IDbExpressionAliasProvider aliasable, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (string.IsNullOrWhiteSpace(aliasable.Alias))
                return;

            builder.Appender.Write(" AS ")
                .Write(context.Configuration.IdentifierDelimiter.Begin)
                .Write(aliasable.Alias)
                .Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
