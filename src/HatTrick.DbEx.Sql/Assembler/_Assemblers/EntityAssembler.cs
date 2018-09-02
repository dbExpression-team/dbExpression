using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityAssembler :
        IDbExpressionAssemblyPartAssembler<EntityExpression>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as EntityExpression, builder, overrides);

        public string Assemble(EntityExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (!string.IsNullOrWhiteSpace(overrides?.EntityName))
                return overrides.EntityName;

            if (expressionPart.IsAliased)
                return expressionPart.AliasName;

            var schema = builder.AssemblePart<SchemaExpression>(expressionPart.Schema, overrides);
            return $"{schema}.[{expressionPart.EntityName}]";
        }
    }
}
