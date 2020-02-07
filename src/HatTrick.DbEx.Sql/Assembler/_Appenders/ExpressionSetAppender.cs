using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ExpressionSetAppender :
        IAssemblyPartAppender<ExpressionSet>
    {
        public void AppendPart(object part, ISqlStatementBuilder builder, AssemblyContext context)
            => AppendPart(part as ExpressionSet, builder, context);

        public virtual void AppendPart(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClauses(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);
            AppendOrderByClause(expression, builder, context);
        }

        protected virtual void AppendSelectClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Indent().Write("SELECT");

            if (expression.Select is IDbExpressionIsTopProvider t && t.Top.HasValue)
            {
                builder.Appender.Write(" TOP(").Write(t.Top.ToString()).Write(")");
            }

            if (expression.Select is IDbExpressionIsDistinctProvider d && d.IsDistinct)
                builder.Appender.Write(" DISTINCT");

            builder.Appender.LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Declaration);
            AppendSelectList(expression.Select.Expressions, builder, context);
            context.PopAppendStyles();

            builder.Appender.Indentation--;
        }

        protected virtual void AppendSelectList(IList<(Type, object)> expressions, ISqlStatementBuilder builder, AssemblyContext context)
        {
            for (var i = 0; i < expressions.Count; i++)
            {
                builder.Appender.Indent();
                if (context.Configuration.PrependCommaOnSelectClauseParts && i > 0)
                    builder.Appender.Write(",");

                //if the expression is a "child" of an entity and the entity is aliased, the expression will be have a declaration somewhere else, override and tell the appender to use an alias append style 
                if (!string.IsNullOrWhiteSpace(((expressions[i].Item2 as IDbExpressionProvider<EntityExpression>)?.Expression as IDbExpressionAliasProvider)?.Alias))
                {
                    context.PushAppendStyle(FieldExpressionAppendStyle.Alias);
                    builder.AppendPart(expressions[i], context);
                    context.PopAppendStyles();
                }
                else
                {
                    builder.AppendPart(expressions[i], context);
                }

                if (!context.Configuration.PrependCommaOnSelectClauseParts && i < expressions.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }
        }

        protected virtual void AppendFromClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent().Write("FROM").LineBreak();

            builder.Appender
                .Indentation++
                .Indent();

            context.PushAppendStyle(EntityExpressionAppendStyle.Declaration);
            builder.AppendPart(expression.BaseEntity, context);
            context.PopAppendStyles();

            builder.Appender
                .Indentation--
                .LineBreak();
        }

        protected virtual void AppendJoinClauses(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions == null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            foreach (var join in expression.Joins.Expressions)
            {
                builder.AppendPart(join, context);
                builder.Appender.LineBreak();
            }

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendWhereClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Where?.Expression == null || expression.Where.Expression == default)
                return;

            builder.Appender.Indent().Write("WHERE").LineBreak()
                .Indentation++;

            builder.AppendPart(expression.Where, context);

            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendGroupByClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
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

                builder.AppendPart(expression.GroupBy.Expressions[i], context);

                if (!context.Configuration.PrependCommaOnSelectClauseParts && i < expression.GroupBy.Expressions.Count - 1)
                    builder.Appender.Write(",");

                builder.Appender.LineBreak();
            }

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendHavingClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Having?.Expression == null || expression.Having.Expression == default)
                return;

            builder.Appender.Indent().Write("HAVING").LineBreak()
                .Indentation++;

            builder.AppendPart(expression.Having, context);

            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendOrderByClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.OrderBy?.Expressions == null || !expression.OrderBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("ORDER BY").LineBreak()
                .Indentation++;

            AppendOrderByList(expression.OrderBy.Expressions, builder, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendOrderByList(IList<OrderByExpression> expressions, ISqlStatementBuilder builder, AssemblyContext context)
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
    }
}