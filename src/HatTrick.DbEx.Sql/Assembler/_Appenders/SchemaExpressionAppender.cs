using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SchemaExpressionAppender : ExpressionElementAppender<SchemaExpression>
    {
        public override void AppendElement(SchemaExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
            builder.Appender.Write(builder.FindMetadata(expression).Name);
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
