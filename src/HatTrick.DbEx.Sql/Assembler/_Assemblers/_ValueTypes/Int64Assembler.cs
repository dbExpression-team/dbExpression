using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Int64Assembler : IDbExpressionAssemblyPartAssembler<long>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((long)expressionPart, builder, overrides);

        public string AssemblePart(long expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart).ParameterName;
    }
}
