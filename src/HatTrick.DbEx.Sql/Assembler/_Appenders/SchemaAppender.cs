using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SchemaAppender :
        IAssemblyPartAppender<SchemaExpression>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as SchemaExpression, builder, overrides);

        public string AssemblePart(SchemaExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => $"[{expressionPart.SchemaName}]";

        public void AppendPart(object expression, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(expression as SchemaExpression, builder, context);

        public void AppendPart(SchemaExpression expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Write("[");
            builder.Appender.Write(expression.SchemaName);
            builder.Appender.Write("]");
        }
    }
}
