using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class FieldAssembler :
        IDbExpressionAssemblyPartAssembler<FieldExpression>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as FieldExpression, builder, overrides);

        public string AssemblePart(FieldExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (overrides != null && overrides.EntityAliases.Contains(expressionPart.ParentEntity))
                return $"{overrides.EntityAliases.ResolveEntityName(expressionPart.ParentEntity)}.[{expressionPart.Name}]";

            return $"{builder.AssemblePart<EntityExpression>(expressionPart.ParentEntity, overrides)}.[{expressionPart.Name}]";
        }
    }
}
