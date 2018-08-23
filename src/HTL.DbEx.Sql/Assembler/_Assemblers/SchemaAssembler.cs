using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class SchemaAssembler :
        ISqlPartAssembler<DBExpressionSchema>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBExpressionSchema, builder);

        public string Assemble(DBExpressionSchema expressionPart, ISqlStatementBuilder builder)
            => $"[{expressionPart.SchemaName}]";
    }
}
