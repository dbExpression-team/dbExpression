using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FieldAppender :
        IAssemblyPartAppender<FieldExpression>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as FieldExpression, builder, context);

        public void AppendPart(FieldExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            var metadataProvider = expression as IDbExpressionMetadataProvider<ISqlFieldMetadata>;
            var entityProvider = expression as IDbExpressionProvider<EntityExpression>;

            var alias = context.ResolveEntityAlias(entityProvider.Expression);
            if (!string.IsNullOrWhiteSpace(alias))
            {
                builder.Appender
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write(alias)
                    .Write(context.Configuration.IdentifierDelimiter.End);
            }
            else
            {
                builder.AppendPart<EntityExpression>(entityProvider.Expression, context);
            }

            builder.Appender
                .Write(".")
                .Write(context.Configuration.IdentifierDelimiter.Begin)
                .Write(!string.IsNullOrWhiteSpace(context.CurrentField?.NameOverride) ? context.CurrentField.NameOverride : metadataProvider.Metadata.Name)
                .Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
