using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SelectSqlStatementAssembler : SqlStatementAssembler
    {
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!(expression is SelectQueryExpression select))
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(SelectQueryExpression)}, but is actually type {expression.GetType()}");
            AssembleStatement(select, builder, context);
        }

        protected virtual void AssembleStatement(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
            AppendGroupByClause(expression, builder, context);
            AppendHavingClause(expression, builder, context);
            AppendOrderByClause(expression, builder, context);
        }

        protected virtual void AppendSelectClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Indent().Write("SELECT");

            if (expression.Select is IExpressionTopProvider t && t.Top.HasValue)
            {
                builder.Appender.Write(" TOP(").Write(t.Top.ToString()).Write(")");
            }

            if (expression.Select is IExpressionIsDistinctProvider d && d.IsDistinct)
            {
                builder.Appender.Write(" DISTINCT");
            }

            builder.Appender.LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Declaration);
            builder.AppendPart(expression.Select, context);
            context.PopAppendStyles();

            builder.Appender.Indentation--;
        }

        protected virtual void AppendFromClause(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
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

        protected virtual void AppendGroupByClause(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.GroupBy?.Expressions is null || !expression.GroupBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("GROUP BY").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            builder.AppendPart(expression.GroupBy, context);
            context.PopAppendStyles();

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendHavingClause(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Having?.Expression is null || expression.Having.Expression is null)
                return;

            builder.Appender.Indent().Write("HAVING").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            builder.AppendPart(expression.Having, context);
            context.PopAppendStyles();

            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendOrderByClause(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.OrderBy?.Expressions is null || !expression.OrderBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("ORDER BY").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            builder.AppendPart(expression.OrderBy, context);
            context.PopAppendStyles();

            builder.Appender
                .Indentation--;
        }
    }
}