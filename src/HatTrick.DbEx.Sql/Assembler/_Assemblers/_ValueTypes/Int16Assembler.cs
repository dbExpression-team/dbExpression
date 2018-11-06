using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Int16Assembler : IDbExpressionAssemblyPartAssembler<short>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((short)expressionPart, builder, overrides);

        public string AssemblePart(short expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart).ParameterName;
    }
}
