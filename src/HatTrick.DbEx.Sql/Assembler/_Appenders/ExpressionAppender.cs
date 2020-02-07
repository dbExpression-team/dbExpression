using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ExpressionAppender
    {
        public void AppendDistinct(IDbExpressionIsDistinctProvider distinct, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (distinct.IsDistinct)
                builder.Appender.Write("DISTINCT ");
        }

        public void AppendAlias(IDbExpressionAliasProvider aliasable, ISqlStatementBuilder builder, AssemblyContext context)
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
