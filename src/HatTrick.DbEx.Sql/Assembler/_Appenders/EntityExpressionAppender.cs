using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityExpressionAppender : ExpressionElementAppender<EntityExpression>
    {
        public override void AppendElement(EntityExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
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
                builder.AppendElement((expression as IExpressionProvider<SchemaExpression>).Expression, context);
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
