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
            var provider = expression as IDbExpressionMetadataProvider<ISqlEntityMetadata>;
            if (context.Configuration.IncludeSchemaName)
            {
                builder.AppendPart<SchemaExpression>((expression as IDbExpressionProvider<SchemaExpression>).Expression, context);
                builder.Appender.Write(".");
            }
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
            builder.Appender.Write(provider.Metadata.Name);
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
