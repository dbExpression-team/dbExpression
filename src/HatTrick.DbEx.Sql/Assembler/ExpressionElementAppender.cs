using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class ExpressionElementAppender : 
        IExpressionElementAppender
    {
        public abstract void AppendElement(IExpressionElement expression, ISqlStatementBuilder builder, AssemblyContext context);

        protected static void AppendDistinct(IExpressionIsDistinctProvider distinct, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (distinct.IsDistinct)
                builder.Appender.Write("DISTINCT ");
        }

        protected virtual void AppendAlias(IExpressionAliasProvider aliasable, ISqlStatementBuilder builder, AssemblyContext context)
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
