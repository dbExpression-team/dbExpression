using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class PartAppender : IAssemblyPartAppender
    {
        public abstract void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context);

        protected static void AppendDistinct(IDbExpressionIsDistinctProvider distinct, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (distinct.IsDistinct)
                builder.Appender.Write("DISTINCT ");
        }

        protected static void AppendAlias(IDbExpressionAliasProvider aliasable, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (string.IsNullOrWhiteSpace(aliasable.Alias))
                return;

            if (context.FieldExpressionAppendStyle == FieldExpressionAppendStyle.None)
                return;

            builder.Appender.Write(" AS ")
                .Write(context.Configuration.IdentifierDelimiter.Begin)
                .Write(aliasable.Alias)
                .Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
