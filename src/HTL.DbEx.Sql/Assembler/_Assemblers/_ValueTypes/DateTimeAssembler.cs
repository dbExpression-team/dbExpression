using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class DateTimeAssembler : ISqlPartAssembler<DateTime>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble((DateTime)expressionPart, builder);

        public string Assemble(DateTime expressionPart, ISqlStatementBuilder builder)
            => builder.Parameters.Add(expressionPart, typeof(DateTime)).ParameterName;
    }
}
