using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTL.DbEx.Sql.Assembler
{
    public class InsertClauseAssembler : 
        ISqlPartAssembler<DBInsertExpressionSet>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as DBInsertExpressionSet, builder, overrides);

        public string Assemble(DBInsertExpressionSet expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
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

            return Assemble(expressionPart, insertParts, overrides);
        }

        protected virtual string Assemble(DBInsertExpressionSet expressionPart, IList<(string, string)> values, AssemblerOverrides overrides)
            => Assemble(expressionPart, string.Join(", ", values.Select(v => v.Item1)), string.Join(", ", values.Select(v => v.Item2)), overrides);

        protected virtual string Assemble(DBInsertExpressionSet expressionPart, string columns, string values, AssemblerOverrides overrides)
            => $"({columns}) VALUES ({values})";
    }
}
