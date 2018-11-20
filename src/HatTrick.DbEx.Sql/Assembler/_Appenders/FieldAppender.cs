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
            var provider = expression as IExpressionMetadataProvider<FieldExpressionMetadata>;
            var alias = context.ResolveEntityName(provider.Metadata.ParentEntity);
            if (!string.IsNullOrWhiteSpace(alias))
            {
                builder.Appender.Write(alias);
            }
            else
            {
                builder.AppendPart<EntityExpression>(provider.Metadata.ParentEntity, context);
            }
            builder.Appender.Write(".[");
            builder.Appender.Write(provider.Metadata.Name);
            builder.Appender.Write("]");
        }
    }
}
