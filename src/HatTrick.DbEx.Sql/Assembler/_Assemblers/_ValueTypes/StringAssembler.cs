using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class StringAssembler : IDbExpressionAssemblyPartAssembler<string>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart(expressionPart as string, builder, overrides);

        public string AssemblePart(string expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
        {
            var @fixed = builder.FormatValueType<string>(expressionPart);
            return builder.Parameters.Add(@fixed, typeof(string), @fixed.Length).ParameterName;
        }
    }
}
