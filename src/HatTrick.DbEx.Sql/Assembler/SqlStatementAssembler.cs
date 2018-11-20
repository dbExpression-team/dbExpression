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
        public abstract void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context);
        #endregion
    }
}
