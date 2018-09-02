using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SchemaAssembler :
        IDbExpressionAssemblyPartAssembler<SchemaExpression>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as SchemaExpression, builder, overrides);

        public string Assemble(SchemaExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => $"[{expressionPart.SchemaName}]";
    }
}
