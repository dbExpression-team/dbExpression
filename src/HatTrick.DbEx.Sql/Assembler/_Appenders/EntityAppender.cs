using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityAppender :
        IAssemblyPartAppender<EntityExpression>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as EntityExpression, builder, context);

        public void AppendPart(EntityExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            var provider = expression as IExpressionMetadataProvider<EntityExpressionMetadata>;
            if (context.Configuration.IncludeSchemaName)
            {
                builder.AppendPart<SchemaExpression>(provider.Metadata.Schema, context);
                builder.Appender.Write(".");
            }
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
            builder.Appender.Write(provider.Metadata.EntityName);
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
