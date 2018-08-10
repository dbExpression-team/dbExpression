using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
{
    public class UpdateSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override (string, IList<DbParameter>) Assemble(DBExpressionSet expression, ISqlStatementBuilder builder)
        {
            string update = Equals(expression.Assign, null) ? string.Empty : builder.AssemblePart<DBAssignmentExpressionSet>(expression.Assign);
            string where = Equals(expression.Where, null) ? string.Empty : builder.AssemblePart<DBFilterExpressionSet>(expression.Where);
            string joins = Equals(expression.Joins, null) ? string.Empty : builder.AssemblePart<DBJoinExpressionSet>(expression.Joins);
            string ex = Assemble(expression, update, expression.BaseEntity.ToString("[s].[e]"), where, joins);
            return (ex, builder.Parameters.Parameters);
        }

        protected virtual string Assemble(DBExpressionSet expression, string update, string fromEntity, string where, string joins)
        {
            string after(string s) => s.SpaceAfter().NewLineAfter(DBExpressionConfiguration.Minify);

            if (!string.IsNullOrWhiteSpace(where))
                where = after("WHERE") + after(where);

            if (!string.IsNullOrWhiteSpace(joins))
                joins = after(joins);

            return $"{after("UPDATE")}{after(fromEntity)}{after("SET")}{after(update)}{after("FROM")}{after(fromEntity)}{joins}{where};";
        }
        #endregion
    }
}