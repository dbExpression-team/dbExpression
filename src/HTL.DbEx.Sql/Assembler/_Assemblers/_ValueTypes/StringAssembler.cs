using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class StringAssembler : ISqlPartAssembler<string>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble(expressionPart as string, builder);

        public string Assemble(string expressionPart, ISqlStatementBuilder builder)
        {
            var @fixed = builder.FormatValueType<string>(expressionPart);
            return builder.Parameters.Add(@fixed, typeof(string), @fixed.Length).ParameterName;
        }
    }
}
