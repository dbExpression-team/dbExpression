using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
{
    public class SelectSqlStatementAssembler : SqlStatementAssembler
    {
        public override (string, IList<DbParameter>) Assemble(DBExpressionSet expression, ISqlStatementBuilder builder)
        {
            string select = Equals(expression.Select, null) ? string.Empty : builder.AssemblePart<DBSelectExpressionSet>(expression.Select);
            string where = Equals(expression.Where, null) ? string.Empty : builder.AssemblePart<DBFilterExpressionSet>(expression.Where);
            string joins = Equals(expression.Joins, null) ? string.Empty : builder.AssemblePart<DBJoinExpressionSet>(expression.Joins);
            string groupBy = Equals(expression.GroupBy, null) ? string.Empty : builder.AssemblePart<DBJoinExpressionSet>(expression.GroupBy);
            string having = Equals(expression.Having, null) ? string.Empty : builder.AssemblePart<DBHavingExpression>(expression.Having);
            string orderBy = Equals(expression.OrderBy, null) ? string.Empty : builder.AssemblePart<DBOrderByExpressionSet>(expression.OrderBy);

            string sql = Assemble(
                expression,
                builder,
                select,
                expression.Distinct ? "DISTINCT " : string.Empty,
                expression.BaseEntity.ToString("[s].[e]"),
                where,
                joins,
                groupBy,
                having,
                orderBy
            );

            return (sql, builder.Parameters.Parameters);
        }

        protected virtual string Assemble(DBExpressionSet expression, ISqlStatementBuilder builder, string select, string distinct, string fromEntity, string where, string joins, string groupBy, string having, string orderBy)
        {
            string after(string s) => s.SpaceAfter().NewLineAfter(DBExpressionConfiguration.Minify);

            if (!string.IsNullOrWhiteSpace(distinct))
                distinct = after(distinct);

            if (!string.IsNullOrWhiteSpace(where))
                where = after("WHERE") + after(where);

            if (!string.IsNullOrWhiteSpace(joins))
                joins = after(joins);

            if (!string.IsNullOrWhiteSpace(groupBy))
                groupBy = after("GROUP BY") + after(groupBy);

            if (!string.IsNullOrWhiteSpace(having))
                having = after("HAVING") + after(having);

            if (!string.IsNullOrWhiteSpace(orderBy))
                orderBy = after("ORDER BY") + orderBy;

            return $"{after("SELECT")}{distinct}{after(select)}{after("FROM")}{after(fromEntity)}{joins}{where}{groupBy}{having}{orderBy};";
        }
    }
}