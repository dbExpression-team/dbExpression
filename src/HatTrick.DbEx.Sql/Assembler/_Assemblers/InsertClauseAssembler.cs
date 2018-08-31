using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class InsertClauseAssembler : 
        IDbExpressionAssemblyPartAssembler<InsertExpressionSet>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as InsertExpressionSet, builder, overrides);

        public string AssemblePart(InsertExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            if (expressionPart is null)
            {
                return null;
            }

            var insertParts = new List<(string, string)>();

            for (int i = 0; i < expressionPart.Expressions.Count; i++)
            {
                insertParts.Add((builder.AssemblePart(expressionPart.Expressions[i].Part, overrides), builder.Parameters.Add(expressionPart.Expressions[i].PartValue.Item2, expressionPart.Expressions[i].PartValue.Item1).ParameterName));
            }

            return AssemblePart(expressionPart, insertParts, overrides);
        }

        protected virtual string AssemblePart(InsertExpressionSet expressionPart, IList<(string, string)> values, AssemblerOverrides overrides)
            => AssemblePart(expressionPart, string.Join(", ", values.Select(v => v.Item1)), string.Join(", ", values.Select(v => v.Item2)), overrides);

        protected virtual string AssemblePart(InsertExpressionSet expressionPart, string columns, string values, AssemblerOverrides overrides)
            => $"({columns}) VALUES ({values})";
    }
}
