using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GuidAssembler : IDbExpressionAssemblyPartAssembler<Guid>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((Guid)expressionPart, builder, overrides);

        public string AssemblePart(Guid expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart).ParameterName;
    }
}
