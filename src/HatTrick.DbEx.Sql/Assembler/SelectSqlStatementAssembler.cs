using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions;
using HatTrick.DbEx.Sql.Extensions.Assembler;
using System;
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

        public virtual void DiscoverAliases(object expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, EntityAliasDiscovery> discoveredAliases)
            => DiscoverAliases(expression as ExpressionSet, builder, currentLevel, config, discoveredAliases);

        public virtual void DiscoverAliases(ExpressionSet expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, EntityAliasDiscovery> discoveredAliases)
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

            if ((expression.Select as IDbExpressionIsDistinctProvider).IsDistinct)
                builder.Appender.Write(" DISTINCT");

            builder.Appender.LineBreak()
                .Indentation++;

            AppendSelectList(expression.Select.Expressions, builder, context);

            builder.Appender.Indentation--;
        }

        protected virtual void AppendSelectList(IList<(Type, object)> expressions, ISqlStatementBuilder builder, AssemblerContext context)
        {
            for (var i = 0; i < expressions.Count; i++)
            {
                builder.Appender.Indent();
                if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                    builder.Appender.Write(",");

                builder.AppendPart(expressions[i], context);

                if (!context.Configuration.PrependCommaOnSelectClauseParts && i < expressions.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }
        }

        protected virtual void AppendFromClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            builder.Appender.Indent().Write("FROM").LineBreak();

            builder.Appender
                .Indentation++
                .Indent();

            builder.AppendPart<EntityExpression>(expression.BaseEntity, context);

            var alias = context.ResolveEntityAlias(expression.BaseEntity, context.CurrentDepth + 1);
            if (!string.IsNullOrWhiteSpace(alias))
            {
                builder.Appender.Write(" AS ")
                    .Write(context.Configuration.IdentifierDelimiter.Begin)
                    .Write(alias)
                    .Write(context.Configuration.IdentifierDelimiter.End);
            }

            builder.Appender
                .Indentation--
                .LineBreak();
        }

        protected virtual void AppendJoinClauses(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.Joins?.Expressions == null || !expression.Joins.Expressions.Any())
                return;

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

        protected virtual void AppendWhereClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.Where?.Expression == null || expression.Where.Expression == default)
                return;

            builder.Appender.Indent().Write("WHERE").LineBreak()
                .Indentation++;

            builder.AppendPart<FilterExpressionSet>(expression.Where, context);
                
            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendGroupByClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.GroupBy?.Expressions == null || !expression.GroupBy.Expressions.Any())
                return;

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

        protected virtual void AppendHavingClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.Having?.Expression == null || expression.Having.Expression == default)
                return;

            builder.Appender.Indent().Write("HAVING").LineBreak()
                .Indentation++;

            builder.AppendPart<HavingExpression>(expression.Having, context);

            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendOrderByClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblerContext context)
        {
            if (expression.OrderBy?.Expressions == null || !expression.OrderBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("ORDER BY").LineBreak()
                .Indentation++;

            AppendOrderByList(expression.OrderBy.Expressions, builder, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendOrderByList(IList<OrderByExpression> expressions, ISqlStatementBuilder builder, AssemblerContext context)
        {
            for (var i = 0; i < expressions.Count; i++)
            {
                builder.Appender.Indent();

                if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                    builder.Appender.Write(",");

                builder.AppendPart<OrderByExpression>(expressions[i], context);

                if (!context.Configuration.PrependCommaOnSelectClauseParts && i < expressions.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }
        }
    }
}