using HatTrick.DbEx.Sql.Expression;
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
            var entity = builder.AssemblePart<EntityExpression>(expressionPart.ParentEntity, overrides);
            return $"{entity}.[{expressionPart.Name}]";
        }
    }
}
