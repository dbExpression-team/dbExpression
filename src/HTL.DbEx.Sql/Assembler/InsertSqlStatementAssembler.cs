using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
{
    public class InsertSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override (string, IList<DbParameter>) Assemble(DBExpressionSet expression, ISqlStatementBuilder builder)
        {
            string insert = Equals(expression.Insert, null) ? string.Empty : builder.AssemblePart<DBInsertExpressionSet>(expression.Insert);
            insert = Assemble(expression, expression.BaseEntity.ToString("[s].[e]"), insert);
            return (insert, builder.Parameters.Parameters);
        }

        protected virtual string Assemble(DBExpressionSet expression, string entity, string insert)
             => $"INSERT INTO {entity} {insert};";

        #endregion
    }
}