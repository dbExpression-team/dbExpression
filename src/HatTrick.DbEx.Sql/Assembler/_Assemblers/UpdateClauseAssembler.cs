using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class UpdateClauseAssembler : 
        IDbExpressionAssemblyPartAssembler<AssignmentExpressionSet>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as AssignmentExpressionSet, builder, overrides);

        public string AssemblePart(AssignmentExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }

            var assignments = expressionPart.Expressions;
            var assignmentParts = new List<(string, string)>();

            for (int i = 0; i < assignments.Count; i++)
            {
                var partPair = (DbExpressionPair)assignments[i].Expression.Item2;
                assignmentParts.Add((builder.AssemblePart(partPair.LeftPart, overrides), builder.Parameters.Add(partPair.RightPart.Item2, partPair.RightPart.Item1).ParameterName));
            }

            return AssemblePart(expressionPart, assignmentParts);
        }

        protected virtual string AssemblePart(AssignmentExpressionSet expressionPart, IList<(string, string)> values)
            => string.Join(", ", values.Select(v => $"{v.Item1} = {v.Item2}"));
    }
}
