using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DateTimeAssembler : IDbExpressionAssemblyPartAssembler<DateTime>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble((DateTime)expressionPart, builder, overrides);

        public string Assemble(DateTime expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart, typeof(DateTime)).ParameterName;
    }
}
