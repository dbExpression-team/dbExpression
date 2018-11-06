using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Int32Assembler : IDbExpressionAssemblyPartAssembler<int>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((int)expressionPart, builder, overrides);

        public string AssemblePart(int expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart).ParameterName;
    }
}
