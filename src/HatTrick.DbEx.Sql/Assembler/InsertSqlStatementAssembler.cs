using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class InsertSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override SqlStatement Assemble(ExpressionSet expression, ISqlStatementBuilder builder)
        {
            string insert = Equals(expression.Insert, null) ? string.Empty : builder.AssemblePart<InsertExpressionSet>(expression.Insert);
            insert = Assemble(expression, expression.BaseEntity.ToString("[s].[e]"), insert);
            return new SqlStatement(insert, builder.Parameters.Parameters, DbCommandType.SqlText);
        }

        protected virtual string Assemble(ExpressionSet expression, string entity, string insert)
             => $"INSERT INTO {entity} {insert};";

        #endregion
    }
}