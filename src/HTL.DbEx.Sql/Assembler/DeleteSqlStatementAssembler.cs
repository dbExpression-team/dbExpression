﻿using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
{
    public class DeleteSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override (string, IList<DbParameter>) Assemble(DBExpressionSet expression, ISqlStatementBuilder builder)
        {
            string where = Equals(expression.Where, null) ? string.Empty : builder.AssemblePart<DBFilterExpressionSet>(expression.Where);
            string joins = Equals(expression.Joins, null) ? string.Empty : builder.AssemblePart<DBJoinExpressionSet>(expression.Joins);
            string ex = Assemble(expression, expression.BaseEntity.ToString("[s].[e]"), where, joins);
            return (ex, builder.Parameters.Parameters);
        }

        protected virtual string Assemble(DBExpressionSet expression, string fromEntity, string where, string joins)
        {
            string after(string s) => s.SpaceAfter().NewLineAfter(DBExpressionConfiguration.Minify);

            if (!string.IsNullOrWhiteSpace(where))
                where = after("WHERE") + after(where);

            if (!string.IsNullOrWhiteSpace(joins))
                joins = after(joins);

            return $"{after("DELETE")}{after(fromEntity)}{after("FROM")}{after(fromEntity)}{joins}{where};";
        }
        #endregion
    }
}