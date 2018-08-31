﻿using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Assembler;
using System;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Extensions;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SelectAllMsSqlAssembler : SelectAllSqlStatementAssembler
    {
        protected override string Assemble(ExpressionSet expression, ISqlStatementBuilder builder, string select, string distinct, string fromEntity, string where, string joins, string groupBy, string having, string orderBys)
        {
            string before(string s) => s.SpaceBefore().NewLineBefore(DbExpressionConfiguration.Minify);
            string after(string s) => s.SpaceAfter().NewLineAfter(DbExpressionConfiguration.Minify);

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

            if (!expression.SkipValue.HasValue && !expression.LimitValue.HasValue) //no  paging, so no special handling required
                return $"SELECT{before(distinct)}{before(after(select))}FROM{before(after(fromEntity))}{after(joins)}{after(where)}{after(groupBy)}{after(having)}{orderBys};";

            if (!expression.Distinct) //no distinct, return standard CTE for page
                return $"SELECT * FROM {after("(")}{after("SELECT")}{after(select)},ROW_NUMBER() OVER ({orderBys}) AS {after("[RowIndex]")}{after("FROM")}{after(fromEntity)}{joins}{where}{groupBy}{having}) AS {after(expression.BaseEntity.ToString("[s.e]", true))}{after("WHERE")}[RowIndex] BETWEEN {(builder.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)} AND {(builder.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1))}{before(after("ORDER BY"))}[RowIndex];";

            //expression is marked as DISTINCT and uses paging, must perform a subselect with the distinct prior
            //to using ROW_NUMBER as inclusing of ROW_NUMBER with DISTINCT uses the generated index of the row
            //as part of the DISTINCT, effectively disabling the distinct
            var tableAlias = builder.GenerateAlias();
            var overrides = new AssemblerOverrides { EntityName = (expression.BaseEntity, tableAlias) };
            var aliasedSelectClause = builder.AssemblePart<SelectExpressionSet>(expression.Select, overrides);
            var aliasedOrderBys = builder.AssemblePart<OrderByExpressionSet>(expression.OrderBy, overrides);
            return $"SELECT {after(aliasedSelectClause)} FROM {after("(")}{after("SELECT")}{after(aliasedSelectClause)},ROW_NUMBER() OVER (ORDER BY {aliasedOrderBys}) AS {after("[RowIndex]")}{after("FROM ")}{after("(")}{after("SELECT DISTINCT")}{after(select)}{after("FROM")}{after(fromEntity)}{joins}{where}{groupBy}{having}) AS {tableAlias}) AS {after(tableAlias)}{after("WHERE")}{tableAlias}.[RowIndex] BETWEEN {(builder.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)} AND {(builder.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1))}{before(after("ORDER BY"))}{tableAlias}.[RowIndex]";
        }
    }
}
