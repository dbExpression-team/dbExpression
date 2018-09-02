using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class GuidAssembler : IDbExpressionAssemblyPartAssembler<Guid>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => Assemble((Guid)expressionPart, builder, overrides);

        public string Assemble(Guid expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart, typeof(Guid)).ParameterName;
    }
}
