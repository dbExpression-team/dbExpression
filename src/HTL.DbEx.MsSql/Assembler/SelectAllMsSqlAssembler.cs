using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Assembler;
using System;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Extensions;

namespace HTL.DbEx.MsSql.Assembler
{
    public class SelectAllMsSqlAssembler : SelectAllSqlStatementAssembler
    {
        protected override string Assemble(DBExpressionSet expression, ISqlStatementBuilder assemblerContext, string select, string distinct, string fromEntity, string where, string joins, string groupBy, string having, string orderBys)
        {
            string before(string s) => s.SpaceBefore().NewLineBefore(DBExpressionConfiguration.Minify);
            string after(string s) => s.SpaceAfter().NewLineAfter(DBExpressionConfiguration.Minify);

            if (string.IsNullOrWhiteSpace(distinct))
                distinct = after(distinct);

            if (!string.IsNullOrWhiteSpace(where))
                where = after("WHERE") + after(where);

            if (!string.IsNullOrWhiteSpace(groupBy))
                groupBy = after("GROUP BY") + after(groupBy);

            if (!string.IsNullOrWhiteSpace(having))
                having = after("HAVING") + after(having);

            if (!string.IsNullOrWhiteSpace(orderBys))
                orderBys = after("ORDER BY") + after(orderBys);

            if (!string.IsNullOrWhiteSpace(joins))
                joins = after(joins);

            string sql = null;
            if (expression.SkipValue.HasValue || expression.LimitValue.HasValue)
            {
                sql = $"SELECT * FROM {after("(")}{after("SELECT")}{distinct}{after(select)},ROW_NUMBER() OVER ({orderBys}) AS {after("[RowIndex]")}{after("FROM")}{after(fromEntity)}{joins}{where}{groupBy}{having}) AS {after(expression.BaseEntity.ToString("[s.e]"))}{after("WHERE")}[RowIndex] BETWEEN {(assemblerContext.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)} AND {(assemblerContext.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1))}{before(after("ORDER BY"))}[RowIndex];";
            }
            else
            {
                sql = $"SELECT{before(distinct)}{before(after(select))}FROM{before(after(fromEntity))}{after(joins)}{after(where)}{after(groupBy)}{after(having)}{orderBys};";
            }

            return sql;
        }
    }
}
