using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
{
    public abstract class SqlStatementAssembler : ISqlStatementAssembler
    {
        #region methods
        public abstract (string, IList<DbParameter>) Assemble(DBExpressionSet expression, ISqlStatementBuilder builder);
        #endregion
    }
}
