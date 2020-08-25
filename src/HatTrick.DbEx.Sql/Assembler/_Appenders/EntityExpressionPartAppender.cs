using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityExpressionPartAppender : PartAppender<EntityExpression>
    {
        public override void AppendPart(EntityExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (context.EntityExpressionAppendStyle == EntityExpressionAppendStyle.Alias)
            {
                var alias = (expression as IExpressionAliasProvider).Alias;
                if (!string.IsNullOrWhiteSpace(alias))
                {
                    builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
                    builder.Appender.Write(alias);
                    builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
                    return;
                }
            }

            if (context.Configuration.IncludeSchemaName)
            {
                builder.AppendPart((expression as IExpressionProvider<SchemaExpression>).Expression, context);
                builder.Appender.Write(".");
            }
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
            builder.Appender.Write(builder.FindMetadata(expression).Name);
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);

            if (context.EntityExpressionAppendStyle == EntityExpressionAppendStyle.Declaration)
            {
                AppendAlias(expression, builder, context);
            }
        }
    }
}
