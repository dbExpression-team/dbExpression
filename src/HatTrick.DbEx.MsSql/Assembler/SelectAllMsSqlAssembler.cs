using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class SelectAllMsSqlAssembler : SelectAllSqlStatementAssembler
    {
        public override void AppendPart(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (!expression.SkipValue.HasValue && !expression.LimitValue.HasValue)
            {
                //no  paging, so no special handling required
                AppendSelectClause(expression, builder, context);
                AppendFromClause(expression, builder, context);
                AppendJoinClauses(expression, builder, context);
                AppendWhereClause(expression, builder, context);
                AppendGroupByClause(expression, builder, context);
                AppendHavingClause(expression, builder, context);
                AppendOrderByClause(expression, builder, context);
                return;
            }

            if (!(expression.Select as IDbExpressionIsDistinctProvider).IsDistinct) //no distinct, return standard CTE for page
            {
                //start CTE
                builder.Appender.Indent().Write("SELECT").LineBreak()
                    .Indentation++
                    .Indent().Write("*").LineBreak()
                    .Indentation--
                    .Indent().Write("FROM (").LineBreak()
                    .Indentation++;

                AppendSelectClause(expression, builder, context);

                //add index column
                if (context.Configuration.PrependCommaOnSelectClauseParts)
                    builder.Appender.Write(",");
                builder.Appender.Indentation++.Indent().Write("ROW_NUMBER() OVER (");
                for (var i = 0; i < expression.OrderBy.Expressions.Count; i++)
                {
                    builder.Appender.Indent();
                    builder.AppendPart<OrderByExpression>(expression.OrderBy.Expressions[i], context);
                    if (i < expression.OrderBy.Expressions.Count - 1)
                        builder.Appender.Write(", ");
                }
                builder.Appender.Write(") AS [__index]").LineBreak();
                //end add index column

                AppendFromClause(expression, builder, context);
                AppendJoinClauses(expression, builder, context);
                AppendWhereClause(expression, builder, context);
                AppendGroupByClause(expression, builder, context);
                AppendHavingClause(expression, builder, context);

                //end CTE
                builder.Appender.Indent().Write("AS ").Write(expression.BaseEntity.ToString("[s.e]", true)).LineBreak()
                    .Indentation--.Indent().Write("WHERE").LineBreak()
                    .Indentation++
                        .Write("[__index] BETWEEN ")
                        .Write(builder.Parameters.Add<int>((expression.SkipValue ?? 0) + 1).ParameterName)
                        .Write(" AND ")
                        .Write(builder.Parameters.Add<int>((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1).ParameterName)
                        .LineBreak()
                    .Indentation--.Indent().Write("ORDER BY").LineBreak()
                    .Indentation++.Indent().Write("[__index]");

                return;
            }

            //expression is marked as DISTINCT and uses paging, must perform a subselect with the distinct prior
            //to using ROW_NUMBER as inclusion of ROW_NUMBER with DISTINCT uses the generated index of the row
            //as part of the DISTINCT, effectively disabling the distinct
            var innerTableAlias = builder.GenerateAlias();
            //context.EntityAliases.Current.SetAliasesForAllEntities(innerTableAlias);
            //var innerAliasedSelectClause = builder.AssemblePart<SelectExpressionSet>(expression.Select, context);

            //var aliasedOrderBys = builder.AssemblePart<OrderByExpressionSet>(expression.OrderBy, context);

            //var outerTableAlias = builder.GenerateAlias();
            //context.EntityAliases.SetAliasesForAllEntities(outerTableAlias);
            //var outerAliasedSelectClause = builder.AssemblePart<SelectExpressionSet>(expression.Select, context);

            //builder.Appender
            //    .Indent().Write("SELECT").LineBreak()
            //    .Indentation++.Indent().Write(outerAliasedSelectClause).LineBreak()
            //    .Indentation--.Indent().Write("FROM (").LineBreak()
            //    .Indentation++.Indent().Write("SELECT").LineBreak()
            //    .Indentation++.Indent().Write(innerAliasedSelectClause).LineBreak()
            //    .Indent().Write(", ROW_NUMBER() OVER (ORDER BY ")
            //        .Write(aliasedOrderBys)
            //        .Write(") AS [__index]").LineBreak()
            //    .Indentation--.Indent().Write("FROM (").LineBreak()
            //    .Indentation++.Indent().Write("SELECT DISTINCT").LineBreak()
            //    .Indentation++.Indent().Write(select).LineBreak()
            //    .Indentation--.Indent().Write("FROM").LineBreak()
            //    .Indentation++.Indent().Write(fromEntity).LineBreak()
            //    .Indent().Write(joins).LineBreak()
            //    .Indentation--
            //    .IfNotEmpty(groupBy,
            //        a => a.Indent().Write("GROUP BY").LineBreak()
            //            .Indentation++.Indent().Write(groupBy).LineBreak()
            //            .Indentation--
            //    )
            //    .IfNotEmpty(having,
            //        a => a.Indent().Write("HAVING").LineBreak()
            //            .Indentation++.Indent().Write(having).LineBreak()
            //            .Indentation--
            //    )
            //    .Indent().Write(") AS ").Write(innerTableAlias).LineBreak()
            //    .Indentation--.Indent().Write(") AS ").Write(outerTableAlias).LineBreak()
            //    .Indentation--.Indent().Write("WHERE").LineBreak()
            //    .Indentation++.Indent().Write(outerTableAlias)
            //        .Write(".[__index] BETWEEN ")
            //        .Write(builder.Parameters.Add((expression.SkipValue ?? 0) + 1).ParameterName)
            //        .Write(" AND ")
            //        .Write(builder.Parameters.Add((expression.SkipValue ?? 0 + expression.LimitValue ?? expression.SkipValue ?? -1) + 1).ParameterName)
            //        .LineBreak()
            //    .Indentation--.Indent().Write("ORDER BY").LineBreak()
            //    .Indentation++.Indent().Write(outerTableAlias).Write(".[__index]").LineBreak();

            //return builder.Appender.ToString();
        }
    }
}
