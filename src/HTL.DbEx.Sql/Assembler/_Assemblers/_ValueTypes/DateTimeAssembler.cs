using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class DateTimeAssembler : ISqlPartAssembler<DateTime>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble((DateTime)expressionPart, builder, overrides);

        public string Assemble(DateTime expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart, typeof(DateTime)).ParameterName;
    }
}
