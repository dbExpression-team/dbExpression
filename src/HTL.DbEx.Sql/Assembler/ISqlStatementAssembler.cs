using HTL.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
{
    public interface ISqlStatementAssembler
    {
        (string, IList<DbParameter>) Assemble(DBExpressionSet expression, ISqlStatementBuilder builder);
    }
}
