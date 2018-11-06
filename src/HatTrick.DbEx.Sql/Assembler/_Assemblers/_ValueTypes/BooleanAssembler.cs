using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class BooleanAssembler : IDbExpressionAssemblyPartAssembler<bool>
    {
        public string AssemblePart(object expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => AssemblePart((bool)expressionPart, builder, overrides);

        public string AssemblePart(bool expressionPart, ISqlStatementBuilder builder, AssemblerOverrides overrides)
            => builder.Parameters.Add(expressionPart ? 1 : 0, typeof(bool)).ParameterName;
    }
}
