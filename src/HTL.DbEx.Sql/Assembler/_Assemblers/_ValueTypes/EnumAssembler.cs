using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class EnumAssembler : ISqlPartAssembler<Enum>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble((Enum)expressionPart, builder);

        public string Assemble(Enum expressionPart, ISqlStatementBuilder builder)
            => builder.Parameters.Add(Convert.ToInt32(expressionPart), typeof(int)).ParameterName;
    }
}
