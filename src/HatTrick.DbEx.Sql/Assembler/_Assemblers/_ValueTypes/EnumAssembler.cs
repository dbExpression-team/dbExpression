using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EnumAssembler : IDbExpressionAssemblyPartAssembler<Enum>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((Enum)expressionPart, builder, overrides);

        public string AssemblePart(Enum expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(Convert.ToInt32(expressionPart)).ParameterName;
    }
}
