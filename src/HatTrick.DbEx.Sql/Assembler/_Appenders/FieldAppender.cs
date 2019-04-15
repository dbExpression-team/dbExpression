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

            var entityAlias = context.ResolveEntityAlias(entityProvider.Expression);
            if (!string.IsNullOrWhiteSpace(entityAlias))
            {
                builder.Appender
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write(entityAlias)
                    .Write(context.Configuration.IdentifierDelimiter.End);
            }
            else
            {
                builder.AppendPart<EntityExpression>(entityProvider.Expression, context);
            }
            builder.Appender.Write(".");

            //TODO: JRod, the following logic does not account for field level alias
            builder.Appender
                .Write(context.Configuration.IdentifierDelimiter.Begin)
                .Write(!string.IsNullOrWhiteSpace(context.CurrentField?.NameOverride) ? context.CurrentField.NameOverride : metadataProvider.Metadata.Name)
                .Write(context.Configuration.IdentifierDelimiter.End);

            if (context.EmitAlias && expression is IDbExpressionAliasProvider aliasable && !string.IsNullOrWhiteSpace(aliasable.Alias))
            {
                builder.Appender.Write(" AS ")
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write(aliasable.Alias)
                    .Write(context.Configuration.IdentifierDelimiter.End);
            }
        }
    }
}
