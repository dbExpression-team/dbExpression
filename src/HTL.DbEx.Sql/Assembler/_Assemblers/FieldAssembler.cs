using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class FieldAssembler :
        ISqlPartAssembler<DBExpressionField>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBExpressionField, builder, overrides);

        public string Assemble(DBExpressionField expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            var entity = builder.AssemblePart<DBExpressionEntity>(expressionPart.ParentEntity, overrides);
            return $"{entity}.[{expressionPart.Name}]";
        }
    }
}
