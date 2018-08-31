using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SchemaAssembler :
        IDbExpressionAssemblyPartAssembler<SchemaExpression>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as SchemaExpression, builder, overrides);

        public string AssemblePart(SchemaExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => $"[{expressionPart.SchemaName}]";
    }
}
