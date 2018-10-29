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
                    .Indentation--.Indent().Write("FROM").LineBreak()
                    .Indentation++.Indent().Write(fromEntity).LineBreak()
                    .Indent().Write(joins).LineBreak()
                    .Indentation--
                    .IfNotEmpty(where,
                        a => a.Indent().Write("WHERE").LineBreak()
                            .Indentation++.Indent().Write(where).LineBreak()
                            .Indentation--
                    )
                    .IfNotEmpty(groupBy,
                        a => a.Indent().Write("GROUP BY").LineBreak()
                            .Indentation++.Indent().Write(groupBy).LineBreak()
                            .Indentation--
                    )
                    .IfNotEmpty(having,
                        a => a.Indent().Write("HAVING").LineBreak()
                            .Indentation++.Indent().Write(having).LineBreak()
                            .Indentation--
                    )
                    .IfNotEmpty(orderBys,
                        a => a.Indent().Write("ORDER BY").LineBreak()
                            .Indentation++.Indent().Write(orderBys).LineBreak()
                            .Indentation--
                    );

                return appender.ToString();
            }

            if (!expression.Distinct) //no distinct, return standard CTE for page
            {
                appender.Indent().Write("SELECT").LineBreak()
                    .Indentation++.Indent().Write("*").LineBreak()
                    .Indentation--.Indent().Write("FROM (").LineBreak()
                    .Indentation++.Indent().Write(select).LineBreak()
                        .Write(",ROW_NUMBER() OVER (")
                        .Write(orderBys)
                        .Write(") AS [__index]").LineBreak()
                    .Indentation--.Indent().Write("FROM").LineBreak()
                    .Indentation++.Append(fromEntity).LineBreak()
                    .Write(joins).LineBreak()
                    .Indentation--
                    .IfNotEmpty(where,
                        a => a.Indent().Write("WHERE").LineBreak()
                            .Indentation++.Indent().Write(where).LineBreak()
                    )
                    .IfNotEmpty(groupBy,
                        a => a.Indent().Write("GROUP BY").LineBreak()
                            .Indentation++.Indent().Write(groupBy).LineBreak()
                            .Indentation--
                    )
                    .IfNotEmpty(having,
                        a => a.Indent().Write("HAVING").LineBreak()
                            .Indentation++.Indent().Write(having).LineBreak()
                            .Indentation--
                    )
                    .Indent().Write("AS ").Write(expression.BaseEntity.ToString("[s.e]", true)).LineBreak()
                    .Indentation--.Indent().Write("WHERE").LineBreak()
                    .Indentation++
                        .Append("[__index] BETWEEN ")
                        .Write(builder.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)
                        .Write(" AND ")
                        .Write(builder.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1).ParameterName)
                        .LineBreak()
                    .Indentation--.Indent().Write("ORDER BY").LineBreak()
                    .Indentation++.Indent().Write("[__index]");

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
                .Indentation++.Indent().Write(outerAliasedSelectClause).LineBreak()
                .Indentation--.Indent().Write("FROM (").LineBreak()
                .Indentation++.Indent().Write("SELECT").LineBreak()
                .Indentation++.Indent().Write(innerAliasedSelectClause).LineBreak()
                .Indent().Write(", ROW_NUMBER() OVER (ORDER BY ")
                    .Write(aliasedOrderBys)
                    .Write(") AS [__index]").LineBreak()
                .Indentation--.Indent().Write("FROM (").LineBreak()
                .Indentation++.Indent().Write("SELECT DISTINCT").LineBreak()
                .Indentation++.Indent().Write(select).LineBreak()
                .Indentation--.Indent().Write("FROM").LineBreak()
                .Indentation++.Indent().Write(fromEntity).LineBreak()
                .Indent().Write(joins).LineBreak()
                .Indentation--
                .IfNotEmpty(groupBy,
                    a => a.Indent().Write("GROUP BY").LineBreak()
                        .Indentation++.Indent().Write(groupBy).LineBreak()
                        .Indentation--
                )
                .IfNotEmpty(having,
                    a => a.Indent().Write("HAVING").LineBreak()
                        .Indentation++.Indent().Write(having).LineBreak()
                        .Indentation--
                )
                .Indent().Write(") AS ").Write(innerTableAlias).LineBreak()
                .Indentation--.Indent().Write(") AS ").Write(outerTableAlias).LineBreak()
                .Indentation--.Indent().Write("WHERE").LineBreak()
                .Indentation++.Indent().Write(outerTableAlias)
                    .Write(".[__index] BETWEEN ")
                    .Write(builder.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)
                    .Write(" AND ")
                    .Write(builder.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1).ParameterName)
                    .LineBreak()
                .Indentation--.Indent().Write("ORDER BY").LineBreak()
                .Indentation++.Indent().Write(outerTableAlias).Write(".[__index]").LineBreak();

            return appender.ToString();
        }
    }
}
