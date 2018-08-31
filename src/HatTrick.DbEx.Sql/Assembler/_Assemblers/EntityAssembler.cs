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
            if (overrides != null && !overrides.EntityName.Equals(default) && overrides.EntityName.Item1 == expressionPart)
            {
                return overrides.EntityName.Item2;
            }

            if (expressionPart.IsAliased)
                return expressionPart.AliasName;

            var schema = builder.AssemblePart<SchemaExpression>(expressionPart.Schema, overrides);
            return $"{schema}.[{expressionPart.EntityName}]";
        }
    }
}
