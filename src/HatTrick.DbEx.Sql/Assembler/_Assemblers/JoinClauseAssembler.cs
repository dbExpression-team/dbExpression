using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Assembler;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class JoinClauseAssembler : 
        IDbExpressionAssemblyPartAssembler<JoinExpressionSet>,
        IDbExpressionAssemblyPartAssembler<JoinExpression>
    {
        public string AssemblePart(JoinExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => expressionPart == null ? string.Empty : string.Join(", ", expressionPart.Expressions.Select(j => AssemblePart(j, builder, overrides)));

        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as JoinExpressionSet, builder, overrides);

        public string AssemblePart(JoinExpression expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart.JoinToo.Item1 == typeof(ExpressionSet))
            {
                var joinExpression = expressionPart.JoinToo.Item2 as ExpressionSet;
                string subselect = builder.AssemblePart<ExpressionSet>(joinExpression, overrides);

                //get the base entity of the subselect and set an alias to build the ON condition (x.field == t1.field)
                string subselectAlias = builder.GenerateAlias();
                overrides.EntityAliases.SetAliasForEntity(subselectAlias, (expressionPart.JoinToo.Item2 as ExpressionSet).BaseEntity);
                string joinSubselect = builder.AssemblePart<JoinOnExpression>(expressionPart.JoinOnExpression, overrides);

                string exp = $"{expressionPart.JoinType} JOIN ({subselect}) AS {subselectAlias} ON {joinSubselect}";

                //set aliases for all entities effected (x.field -> t1.field)
                overrides.EntityAliases.SetAliasesForEntities(subselectAlias, joinExpression.Select);
                return exp;
            }
            if (expressionPart.JoinType == JoinOperationExpressionOperator.CROSS)
            {
                return $"CROSS JOIN {builder.AssemblePart(expressionPart.JoinToo, overrides)}";
            }

            string joinToo = builder.AssemblePart(expressionPart.JoinToo, overrides);
            string joinEntity = builder.AssemblePart<JoinOnExpression>(expressionPart.JoinOnExpression, overrides);
            return $"{expressionPart.JoinType} JOIN {joinToo} ON {joinEntity}";
        }
    }
}
