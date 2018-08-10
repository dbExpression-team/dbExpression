using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class UpdateClauseAssembler : 
        ISqlPartAssembler<DBAssignmentExpressionSet>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as DBAssignmentExpressionSet, builder);

        public string Assemble(DBAssignmentExpressionSet expressionPart, ISqlStatementBuilder builder)
        {
            if (expressionPart is null)
            {
                return null;
            }

            var assignments = expressionPart.Expressions;
            var assignmentParts = new List<(string, string)>();

            for (int i = 0; i < assignments.Count; i++)
            {
                var partPair = (DBExpressionPartPair)assignments[i].Expression.Item2;
                assignmentParts.Add((builder.AssemblePart(partPair.LeftPart), builder.Parameters.Add(partPair.RightPart.Item2, partPair.RightPart.Item1).ParameterName));
            }

            return Assemble(expressionPart, assignmentParts);
        }

        protected virtual string Assemble(DBAssignmentExpressionSet expressionPart, IList<(string, string)> values)
            => string.Join(", ", values.Select(v => $"{v.Item1} = {v.Item2}"));
    }
}
