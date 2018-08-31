using HatTrick.DbEx.Sql.Expression;
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

                //get the base entity of the subselect
                var subselectBaseEntity = (expressionPart.JoinToo.Item2 as ExpressionSet).BaseEntity;

                //get the left or right side of join on condition that matches the base entity
                //var currentAlias = overrides.EntityName;
                var newAlias = builder.GenerateAlias();
                overrides.EntityName = (subselectBaseEntity, newAlias);
                string joinSubselect = builder.AssemblePart<JoinOnExpression>(expressionPart.JoinOnExpression, overrides);
                //overrides.EntityName = currentAlias;

                return $"{expressionPart.JoinType} JOIN ({subselect}) AS {newAlias} ON {joinSubselect}";
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
