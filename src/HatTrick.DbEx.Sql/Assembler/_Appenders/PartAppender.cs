using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class PartAppender : IAssemblyPartAppender, IAssemblyPartAppender<IExpression>
    {
        public abstract void AppendPart(IExpression expression, ISqlStatementBuilder builder, AssemblyContext context);

        protected static void AppendDistinct(IExpressionIsDistinctProvider distinct, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (distinct.IsDistinct)
                builder.Appender.Write("DISTINCT ");
        }

        protected static void AppendAlias(IExpressionAliasProvider aliasable, ISqlStatementBuilder builder, AssemblyContext context)
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
