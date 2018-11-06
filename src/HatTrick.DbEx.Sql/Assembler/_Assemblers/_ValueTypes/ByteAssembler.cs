using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ByteAssembler : IDbExpressionAssemblyPartAssembler<byte>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((byte)expressionPart, builder, overrides);

        public string AssemblePart(byte expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart).ParameterName;
    }
}
