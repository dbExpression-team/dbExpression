using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HatTrick.DbEx.Sql.Assembler
{

    public abstract class SqlStatementAssembler : ISqlStatementAssembler
    {
        #region methods
        public abstract SqlStatement AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides);
        #endregion
    }
}
