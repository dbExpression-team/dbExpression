using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class StringAssembler : ISqlPartAssembler<string>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble(expressionPart as string, builder, overrides);

        public string Assemble(string expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            var @fixed = builder.FormatValueType<string>(expressionPart);
            return builder.Parameters.Add(@fixed, typeof(string), @fixed.Length).ParameterName;
        }
    }
}
