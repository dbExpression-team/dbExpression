using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class SchemaAssembler :
        ISqlPartAssembler<DBExpressionSchema>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBExpressionSchema, builder, overrides);

        public string Assemble(DBExpressionSchema expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => $"[{expressionPart.SchemaName}]";
    }
}
