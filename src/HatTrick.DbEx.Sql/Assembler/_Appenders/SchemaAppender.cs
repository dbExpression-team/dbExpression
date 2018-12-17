using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SchemaAppender :
        IAssemblyPartAppender<SchemaExpression>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as SchemaExpression, builder, context);

        public void AppendPart(SchemaExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
            builder.Appender.Write(expression.SchemaName);
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
