using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAssemblyPartAppender
    {
        void AppendPart(object part, ISqlStatementBuilder builder, AssemblyContext context);
    }
}
