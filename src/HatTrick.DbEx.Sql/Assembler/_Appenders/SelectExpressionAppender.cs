using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectExpressionAppender : ExpressionElementAppender<SelectExpression>
    {
        #region methods
        public override void AppendElement(SelectExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.AppendElement(expression.Expression, context);
            AppendAlias(expression, builder, context);
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
        #endregion
    }
}
