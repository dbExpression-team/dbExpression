using System;

namespace HTL.DbEx.Sql.Assembler
{
    public class GuidAssembler : ISqlPartAssembler<Guid>
    {
        public string Assemble(object expressionPart, ISqlStatementBuilder builder)
            => Assemble((Guid)expressionPart, builder);

        public string Assemble(Guid expressionPart, ISqlStatementBuilder builder)
            => builder.Parameters.Add(expressionPart, typeof(Guid)).ParameterName;
    }
}
