using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class FieldAssembler :
        ISqlPartAssembler<DBExpressionField>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBExpressionField, builder);

        public string Assemble(DBExpressionField expressionPart, ISqlStatementBuilder builder)
            => $"[{expressionPart.ParentEntity.Schema}].[{expressionPart.ParentEntity.EntityName}].[{expressionPart.Name}]";
    }
}
