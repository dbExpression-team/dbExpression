using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DecimalAssembler : IDbExpressionAssemblyPartAssembler<decimal>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((decimal)expressionPart, builder, overrides);

        public string AssemblePart(decimal expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart).ParameterName;
    }
}
