using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FieldExpressionAppender : ExpressionElementAppender<FieldExpression>
    {
        public override void AppendElement(FieldExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            context.PushField(expression);
            try
            {
                if (context.EntityExpressionAppendStyle != EntityExpressionAppendStyle.None)
                {
                    builder.AppendElement((expression as IExpressionProvider<EntityExpression>).Expression, context);
                    builder.Appender.Write(".");
                }

                if (context.FieldExpressionAppendStyle == FieldExpressionAppendStyle.Alias)
                {
                    var alias = (expression as IExpressionAliasProvider).Alias;
                    if (!string.IsNullOrWhiteSpace(alias))
                    {
                        builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin)
                            .Write(alias)
                            .Write(context.Configuration.IdentifierDelimiter.End);
                        return;
                    }
                }

                builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
                builder.Appender.Write(builder.FindMetadata(expression).Name);
                builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);

                if (context.FieldExpressionAppendStyle == FieldExpressionAppendStyle.Declaration)
                {
                    AppendAlias(expression, builder, context);
                }
            }
            finally
            {
                context.PopField();
            }
        }
    }
}
