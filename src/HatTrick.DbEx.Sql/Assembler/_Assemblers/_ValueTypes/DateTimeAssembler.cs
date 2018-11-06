using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DateTimeAssembler : IDbExpressionAssemblyPartAssembler<DateTime>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((DateTime)expressionPart, builder, overrides);

        public string AssemblePart(DateTime expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart).ParameterName;
    }
}
