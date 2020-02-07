using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SchemaAppender :
        ExpressionAppender,
        IAssemblyPartAppender<SchemaExpression>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as SchemaExpression, builder, context);

        public void AppendPart(SchemaExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
            builder.Appender.Write((expression as IDbExpressionMetadataProvider<ISqlSchemaMetadata>).Metadata.Name);
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
