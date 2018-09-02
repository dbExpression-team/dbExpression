using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DeleteSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override SqlStatement Assemble(ExpressionSet expression, ISqlStatementBuilder builder)
        {
            string where = Equals(expression.Where, null) ? string.Empty : builder.AssemblePart<FilterExpressionSet>(expression.Where);
            string joins = Equals(expression.Joins, null) ? string.Empty : builder.AssemblePart<JoinExpressionSet>(expression.Joins);
            string ex = Assemble(expression, expression.BaseEntity.ToString("[s].[e]"), where, joins);
            return new SqlStatement(ex, builder.Parameters.Parameters, DbCommandType.SqlText);
        }

        protected virtual string Assemble(ExpressionSet expression, string fromEntity, string where, string joins)
        {
            string after(string s) => s.SpaceAfter().NewLineAfter(DbExpressionConfiguration.Minify);

            if (!string.IsNullOrWhiteSpace(where))
                where = after("WHERE") + after(where);

            if (!string.IsNullOrWhiteSpace(joins))
                joins = after(joins);

            return $"{after("DELETE")}{after(fromEntity)}{after("FROM")}{after(fromEntity)}{joins}{where};";
        }
        #endregion
    }
}