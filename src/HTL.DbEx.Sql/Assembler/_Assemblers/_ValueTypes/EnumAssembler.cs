using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class EnumAssembler : ISqlPartAssembler<Enum>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble((Enum)expressionPart, builder, overrides);

        public string Assemble(Enum expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(Convert.ToInt32(expressionPart), typeof(int)).ParameterName;
    }
}
