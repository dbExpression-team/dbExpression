using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler.v2012
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

                //add windowing function
                if (context.Configuration.PrependCommaOnSelectClauseParts)
                    builder.Appender.Write(", ");
                builder.Appender.Indentation++.Indent().Write("ROW_NUMBER() OVER (");
                for (var i = 0; i < expression.OrderBy.Expressions.Count; i++)
                {
                    builder.Appender.Indent();
                    builder.AppendPart<OrderByExpression>(expression.OrderBy.Expressions[i], context);
                    if (i < expression.OrderBy.Expressions.Count - 1)
                        builder.Appender.Write(", ");
                }
                builder.Appender.Write(") AS [__index]").LineBreak();

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

            //original expression set will be "wrapped" twice to ensure distinct works with ROWNUMBER(), generate and set as "ghost" aliases with levels "out-dented" from original current depth
            var innerTableAlias = builder.GenerateAlias();
            context.EntityAliases.SetAlias(context.CurrentDepth - 1, new EntityAlias(expression.BaseEntity, innerTableAlias));
            var outerTableAlias = builder.GenerateAlias();
            context.EntityAliases.SetAlias(context.CurrentDepth - 2, new EntityAlias(expression.BaseEntity, outerTableAlias));

            builder.Appender.Write("SELECT ").LineBreak()
                .Indentation++;

            //decrease current depth by 2 to emit the "outer" "outer"
            context.CurrentDepth-=2;

            //append the select list, which is the "final" select from the CTE
            AppendSelectList(expression.Select.Expressions, builder, context);

            builder.Appender
                .Indentation--
                .Indent().Write("FROM (").LineBreak();

            //append select for "inner" which has the ROW_NUMBER() function for paging
            builder.Appender
                .Indentation++
                .Indent()
                .Write("SELECT ").LineBreak()
                .Indentation++;

            //increase current depth by 1 to emit the "outer"
            context.CurrentDepth++;

            //append the select list
            AppendSelectList(expression.Select.Expressions, builder, context);

            //append the function providing the windowed index
            builder.Appender
                .Indent().Write(", ROW_NUMBER() OVER (ORDER BY").LineBreak()
                .Indentation++;

            AppendOrderByList(expression.OrderBy.Expressions, builder, context);

            builder.Appender
                .Indentation--.Indent().Write(") AS [__index]").LineBreak()
                .Indentation--.Indent().Write("FROM (").LineBreak();

            builder.Appender
                .Indentation++;

            //return to the original current depth
            context.CurrentDepth++;

            //now append the "original" select statement
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClauses(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);

            builder.Appender
                .Indentation--
                .Indent().Write(") AS ").Write(innerTableAlias).LineBreak();

            builder.Appender
                .Indentation--.Indent().Write(") AS ").Write(outerTableAlias).LineBreak()
                .Indentation--.Indent().Write("WHERE").LineBreak()
                .Indentation++.Indent().Write(outerTableAlias)
                    .Write(".[__index] BETWEEN ")
                    .Write(builder.Parameters.Add<int>((expression.SkipValue ?? 0) + 1).ParameterName);

            if (expression.LimitValue.HasValue)
            {
                builder.Appender
                    .Write(" AND ")
                    .Write(builder.Parameters.Add<int>((expression.SkipValue ?? 0) + expression.LimitValue + 1).ParameterName)
                    .LineBreak();
            }
            builder.Appender
                .Indentation--.Indent().Write("ORDER BY").LineBreak()
                .Indentation++.Indent().Write(outerTableAlias).Write(".[__index]").LineBreak();
        }
    }
}
