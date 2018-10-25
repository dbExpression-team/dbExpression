using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityAssembler :
        IDbExpressionAssemblyPartAssembler<EntityExpression>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as EntityExpression, builder, overrides);

        public string AssemblePart(EntityExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            var schema = builder.AssemblePart<SchemaExpression>(expressionPart.Schema, overrides);
            return $"{schema}.[{expressionPart.EntityName}]";
        }
    }
}
