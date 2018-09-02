using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementAssembler : ISqlStatementAssembler
    {
        #region methods
        public abstract SqlStatement Assemble(ExpressionSet expression, ISqlStatementBuilder builder);
        #endregion
    }
}
