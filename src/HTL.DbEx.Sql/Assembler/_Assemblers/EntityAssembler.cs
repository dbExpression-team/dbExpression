using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class EntityAssembler :
        ISqlPartAssembler<DBExpressionEntity>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBExpressionEntity, builder);

        public string Assemble(DBExpressionEntity expressionPart, ISqlStatementBuilder builder)
        {
            if (expressionPart.IsAliased)
                return expressionPart.AliasName;

            var schema = builder.AssemblePart<DBExpressionSchema>(expressionPart.Schema);
            return $"{schema}.[{expressionPart.EntityName}]";
        }
    }
}
