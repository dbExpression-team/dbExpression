using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SelectAllMsSqlAssembler : SelectAllSqlStatementAssembler
    {
        protected override string Assemble(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerOverrides overrides, string select, string distinct, string fromEntity, string where, string joins, string groupBy, string having, string orderBys)
        {
            var appender = builder.CreateAppender();

            if (!expression.SkipValue.HasValue && !expression.LimitValue.HasValue) //no  paging, so no special handling required
            {
                appender
                    .Indent().Write("SELECT").LineBreak()
                    .IfNotEmpty(distinct, a => a.Indent().Write(distinct).LineBreak())
                    .Indent().Write(select).LineBreak()
                    .IndentLevel--.Indent().Write("FROM").LineBreak()
                    .IndentLevel++.Indent().Write(fromEntity).LineBreak()
                    .Indent().Write(joins).LineBreak()
                    .IndentLevel--
                    .IfNotEmpty(where,
                        a => a.Indent().Write("WHERE").LineBreak()
                            .IndentLevel++.Indent().Write(where).LineBreak()
                            .IndentLevel--
                    )
                    .IfNotEmpty(groupBy,
                        a => a.Indent().Write("GROUP BY").LineBreak()
                            .IndentLevel++.Indent().Write(groupBy).LineBreak()
                            .IndentLevel--
                    )
                    .IfNotEmpty(having,
                        a => a.Indent().Write("HAVING").LineBreak()
                            .IndentLevel++.Indent().Write(having).LineBreak()
                            .IndentLevel--
                    )
                    .IfNotEmpty(orderBys,
                        a => a.Indent().Write("ORDER BY").LineBreak()
                            .IndentLevel++.Indent().Write(orderBys).LineBreak()
                            .IndentLevel--
                    );

                return appender.ToString();
            }

            if (!expression.Distinct) //no distinct, return standard CTE for page
            {
                appender.Indent().Write("SELECT").LineBreak()
                    .IndentLevel++.Indent().Write("*").LineBreak()
                    .IndentLevel--.Indent().Write("FROM (").LineBreak()
                    .IndentLevel++.Indent().Write(select).LineBreak()
                        .Write(",ROW_NUMBER() OVER (")
                        .Write(orderBys)
                        .Write(") AS [__index]").LineBreak()
                    .IndentLevel--.Indent().Write("FROM").LineBreak()
                    .IndentLevel++.Append(fromEntity).LineBreak()
                    .Write(joins).LineBreak()
                    .IndentLevel--
                    .IfNotEmpty(where,
                        a => a.Indent().Write("WHERE").LineBreak()
                            .IndentLevel++.Indent().Write(where).LineBreak()
                    )
                    .IfNotEmpty(groupBy,
                        a => a.Indent().Write("GROUP BY").LineBreak()
                            .IndentLevel++.Indent().Write(groupBy).LineBreak()
                            .IndentLevel--
                    )
                    .IfNotEmpty(having,
                        a => a.Indent().Write("HAVING").LineBreak()
                            .IndentLevel++.Indent().Write(having).LineBreak()
                            .IndentLevel--
                    )
                    .Indent().Write("AS ").Write(expression.BaseEntity.ToString("[s.e]", true)).LineBreak()
                    .IndentLevel--.Indent().Write("WHERE").LineBreak()
                    .IndentLevel++
                        .Append("[__index] BETWEEN ")
                        .Write(builder.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)
                        .Write(" AND ")
                        .Write(builder.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1).ParameterName)
                        .LineBreak()
                    .IndentLevel--.Indent().Write("ORDER BY").LineBreak()
                    .IndentLevel++.Indent().Write("[__index]");

                return appender.ToString();
                //return $"SELECT * FROM {after("(")}{after("SELECT")}{after(select)},ROW_NUMBER() OVER ({orderBys}) AS {after("[RowIndex]")}{after("FROM")}{after(fromEntity)}{joins}{where}{groupBy}{having}) AS {after(expression.BaseEntity.ToString("[s.e]", true))}{after("WHERE")}[RowIndex] BETWEEN {(builder.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)} AND {(builder.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1))}{before(after("ORDER BY"))}[RowIndex];";
            }

            //expression is marked as DISTINCT and uses paging, must perform a subselect with the distinct prior
            //to using ROW_NUMBER as inclusion of ROW_NUMBER with DISTINCT uses the generated index of the row
            //as part of the DISTINCT, effectively disabling the distinct
            var innerTableAlias = builder.GenerateAlias();
            overrides.EntityAliases.SetAliasesForAllEntities(innerTableAlias);
            var innerAliasedSelectClause = builder.AssemblePart<SelectExpressionSet>(expression.Select, overrides);

            var aliasedOrderBys = builder.AssemblePart<OrderByExpressionSet>(expression.OrderBy, overrides);

            var outerTableAlias = builder.GenerateAlias();
            overrides.EntityAliases.SetAliasesForAllEntities(outerTableAlias);
            var outerAliasedSelectClause = builder.AssemblePart<SelectExpressionSet>(expression.Select, overrides);

            appender
                .Indent().Write("SELECT").LineBreak()
                .IndentLevel++.Indent().Write(outerAliasedSelectClause).LineBreak()
                .IndentLevel--.Indent().Write("FROM (").LineBreak()
                .IndentLevel++.Indent().Write("SELECT").LineBreak()
                .IndentLevel++.Indent().Write(innerAliasedSelectClause).LineBreak()
                .Indent().Write(", ROW_NUMBER() OVER (ORDER BY ")
                    .Write(aliasedOrderBys)
                    .Write(") AS [__index]").LineBreak()
                .IndentLevel--.Indent().Write("FROM (").LineBreak()
                .IndentLevel++.Indent().Write("SELECT DISTINCT").LineBreak()
                .IndentLevel++.Indent().Write(select).LineBreak()
                .IndentLevel--.Indent().Write("FROM").LineBreak()
                .IndentLevel++.Indent().Write(fromEntity).LineBreak()
                .Indent().Write(joins).LineBreak()
                .IndentLevel--
                .IfNotEmpty(groupBy,
                    a => a.Indent().Write("GROUP BY").LineBreak()
                        .IndentLevel++.Indent().Write(groupBy).LineBreak()
                        .IndentLevel--
                )
                .IfNotEmpty(having,
                    a => a.Indent().Write("HAVING").LineBreak()
                        .IndentLevel++.Indent().Write(having).LineBreak()
                        .IndentLevel--
                )
                .Indent().Write(") AS ").Write(innerTableAlias).LineBreak()
                .IndentLevel--.Indent().Write(") AS ").Write(outerTableAlias).LineBreak()
                .IndentLevel--.Indent().Write("WHERE").LineBreak()
                .IndentLevel++.Indent().Write(outerTableAlias)
                    .Write(".[__index] BETWEEN ")
                    .Write(builder.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)
                    .Write(" AND ")
                    .Write(builder.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1).ParameterName)
                    .LineBreak()
                .IndentLevel--.Indent().Write("ORDER BY").LineBreak()
                .IndentLevel++.Indent().Write(outerTableAlias).Write(".[__index]").LineBreak();

            return appender.ToString();
        }
    }
}
