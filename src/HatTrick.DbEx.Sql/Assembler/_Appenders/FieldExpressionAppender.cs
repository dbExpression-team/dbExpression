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
                    return;
                }

                builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin);
                builder.Appender.Write(builder.FindMetadata(expression).Name);
                builder.Appender.Write(context.Configuration.IdentifierDelimiter.End);
            }
            finally
            {
                context.PopField();
            }
        }
    }
}
