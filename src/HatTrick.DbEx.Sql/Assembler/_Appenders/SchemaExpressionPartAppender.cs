using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SchemaExpressionPartAppender : PartAppender<SchemaExpression>
    {
        public override void AppendPart(SchemaExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
            builder.Appender.Write((expression as ISqlMetadataProvider<ISqlSchemaMetadata>).Metadata.Name);
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
