using HTL.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class OrderByClauseAssembler :
        ISqlPartAssembler<DBOrderByExpressionSet>
    {
        public string Assemble(DBOrderByExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides) 
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Where(o => !(o is null)).Select(o => Assemble(o, builder, overrides)));

        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBOrderByExpressionSet, builder, overrides);

        public string Assemble(DBOrderByExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }
            return $"{builder.AssemblePart(expressionPart.Expression, overrides)} {expressionPart.Direction}";
        }
    }
}
