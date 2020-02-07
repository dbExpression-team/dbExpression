using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FieldAppender :
        ExpressionAppender,
        IAssemblyPartAppender<FieldExpression>
    {
        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(expression as FieldExpression, builder, context);

        public void AppendPart(FieldExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context.EntityExpressionAppendStyle != EntityExpressionAppendStyle.None)
            {
                builder.AppendPart((expression as IDbExpressionProvider<EntityExpression>).Expression, context);
                builder.Appender.Write(".");
            }

            if (context.FieldExpressionAppendStyle == FieldExpressionAppendStyle.Alias)
            {
                var alias = (expression as IDbExpressionAliasProvider).Alias;
                if (!string.IsNullOrWhiteSpace(alias))
                {
                    builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin)
                        .Write(alias)
                        .Write(context.Configuration.IdentifierDelimiter.End);
                    return;
                }
            }

            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
            builder.Appender.Write((expression as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata.Name);
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);

            if (context.FieldExpressionAppendStyle == FieldExpressionAppendStyle.Declaration)
            {
                AppendAlias(expression, builder, context);
            }
        }
    }
}
