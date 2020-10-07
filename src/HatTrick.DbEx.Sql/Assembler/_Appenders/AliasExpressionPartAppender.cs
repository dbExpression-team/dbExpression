using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AliasExpressionPartAppender : PartAppender<AliasExpression>
    {
        public override void AppendPart(AliasExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write(context.Configuration.IdentifierDelimiter.Begin)
                .Write(expression.TableAlias)
                .Write(context.Configuration.IdentifierDelimiter.End)
                .Write(".")
                .Write(context.Configuration.IdentifierDelimiter.Begin)
                .Write(expression.FieldAlias)
                .Write(context.Configuration.IdentifierDelimiter.End);
        }
    }
}
