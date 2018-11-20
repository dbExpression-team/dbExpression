using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions;
using HatTrick.DbEx.Sql.Extensions.Assembler;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectSqlStatementAssembler : 
        SqlStatementAssembler, 
        IAssemblyPartAppender<ExpressionSet>,
        IAssemblyPartAliasProvider<ExpressionSet>
    {
        public override void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            AppendPart(expression, builder, context);
        }

        public virtual void DiscoverAliases(object expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, AliasDiscovery> discoveredAliases)
            => DiscoverAliases(expression as ExpressionSet, builder, currentLevel, config, discoveredAliases);

        public virtual void DiscoverAliases(ExpressionSet expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, AliasDiscovery> discoveredAliases)
        {
            if (expression.Joins?.Expressions == null || !expression.Joins.Expressions.Any())
                return;

            foreach (var join in expression.Joins.Expressions)
                builder.DiscoverAliases(join, currentLevel, config, discoveredAliases);
        }

        public void AppendPart(object part, ISqlStatementBuilder builder, AssemblerContext context)
            => AppendPart(part as ExpressionSet, builder, context);

        public virtual void AppendPart(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClauses(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);
            AppendOrderByClause(expression, builder, context);
        }

        protected virtual void AppendSelectClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender
                .Indent().Write("SELECT");

            if (expression.Distinct)
                builder.Appender.Write(" DISTINCT");

            builder.Appender.LineBreak()
                .Indentation++;

            for (var i = 0; i < expression.Select.Expressions.Count; i++)
            {
                builder.Appender.Indent();
                if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                    builder.Appender.Write(",");

                builder.AppendPart<SelectExpression>(expression.Select.Expressions[i], context);

                if (!context.Configuration.PrependCommaOnSelectClauseParts && i < expression.Select.Expressions.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }

            builder.Appender.Indentation--;
        }

        protected virtual void AppendFromClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Indent().Write("FROM").LineBreak();

            builder.Appender
                .Indentation++
                .Indent();

            builder.AppendPart<EntityExpression>(expression.BaseEntity, context);

            var alias = context.ResolveEntityName(expression.BaseEntity, context.CurrentDepth + 1);
            if (!string.IsNullOrWhiteSpace(alias))
            {
                builder.Appender.Write(" AS ");
                builder.Appender.Write(alias);
            }

            builder.Appender
                .Indentation--
                .LineBreak();
        }

        protected virtual void AppendJoinClauses(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.Joins != null)
            {
                builder.Appender
                    .Indentation++;

                foreach (var join in expression.Joins.Expressions)
                {
                    builder.AppendPart<JoinExpression>(join, context);
                    builder.Appender.LineBreak();
                }

                builder.Appender
                    .Indentation--;
            }
        }

        protected virtual void AppendWhereClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.Where != null)
            {
                builder.Appender.Indent().Write("WHERE").LineBreak()
                    .Indentation++;

                builder.AppendPart<FilterExpressionSet>(expression.Where, context);
                
                builder.Appender.LineBreak()
                    .Indentation--;
            }
        }

        protected virtual void AppendGroupByClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.GroupBy != null)
            {
                builder.Appender.Indent().Write("GROUP BY").LineBreak()
                    .Indentation++;

                for (var i = 0; i < expression.GroupBy.Expressions.Count; i++)
                {
                    builder.Appender.Indent();

                    if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                        builder.Appender.Write(",");

                    builder.AppendPart<GroupByExpression>(expression.GroupBy.Expressions[i], context);

                    if (!context.Configuration.PrependCommaOnSelectClauseParts && i < expression.GroupBy.Expressions.Count - 1)
                        builder.Appender.Write(",");

                    builder.Appender.LineBreak();
                }

                builder.Appender
                    .Indentation--;
            }
        }

        protected virtual void AppendHavingClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.Having != null)
            {
                builder.Appender.Indent().Write("HAVING").LineBreak()
                    .Indentation++;

                builder.AppendPart<HavingExpression>(expression.Having, context);

                builder.Appender.LineBreak()
                    .Indentation--;
            }
        }

        protected virtual void AppendOrderByClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.OrderBy != null)
            {
                builder.Appender.Indent().Write("ORDER BY").LineBreak()
                    .Indentation++;

                for (var i = 0; i < expression.OrderBy.Expressions.Count; i++)
                {
                    builder.Appender.Indent();

                    if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                        builder.Appender.Write(",");

                    builder.AppendPart<OrderByExpression>(expression.OrderBy.Expressions[i], context);

                    if (!context.Configuration.PrependCommaOnSelectClauseParts && i < expression.OrderBy.Expressions.Count - 1)
                        builder.Appender.Write(",");

                    builder.Appender.LineBreak();
                }

                builder.Appender
                    .Indentation--;
            }
        }
    }
}