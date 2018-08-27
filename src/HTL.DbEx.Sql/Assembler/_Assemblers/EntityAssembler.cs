using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class EntityAssembler :
        ISqlPartAssembler<DBExpressionEntity>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBExpressionEntity, builder, overrides);

        public string Assemble(DBExpressionEntity expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (!string.IsNullOrWhiteSpace(overrides?.EntityName))
                return overrides.EntityName;

            if (expressionPart.IsAliased)
                return expressionPart.AliasName;

            var schema = builder.AssemblePart<DBExpressionSchema>(expressionPart.Schema, overrides);
            return $"{schema}.[{expressionPart.EntityName}]";
        }
    }
}
