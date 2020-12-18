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

            if (expression.Top.HasValue)
            {
                builder.Appender.Write(" TOP(").Write(expression.Top.ToString()).Write(")");
            }

            if (expression.Distinct == true)
            {
                builder.Appender.Write(" DISTINCT");
            }

            builder.Appender.LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Declaration);
            try
            {
                builder.AppendElement(expression.Select, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.Indentation--;
        }

        protected virtual void AppendFromClause(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Indent().Write("FROM").LineBreak();

            builder.Appender
                .Indentation++
                .Indent();

            context.PushEntityAppendStyle(EntityExpressionAppendStyle.Declaration);
            try
            {
                builder.AppendElement(expression.BaseEntity, context);
            }
            finally
            {
                context.PopEntityAppendStyle();
            }

            builder.Appender
                .Indentation--
                .LineBreak();
        }

        protected virtual void AppendJoinClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions is null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            builder.AppendElement(expression.Joins, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendWhereClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Where?.LeftArg is null && expression.Where?.RightArg is null)
                return;

            builder.Appender.Indent().Write("WHERE")
                .Indentation++;

            builder.Appender.LineBreak().Indent();

            builder.AppendElement(expression.Where, context);

            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendGroupByClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.GroupBy?.Expressions is null || !expression.GroupBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("GROUP BY").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            try
            {
                builder.AppendElement(expression.GroupBy, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendHavingClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Having?.Expression is null || expression.Having.Expression is null)
                return;

            builder.Appender.Indent().Write("HAVING").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            try
            {
                builder.AppendElement(expression.Having, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender.LineBreak()
                .Indentation--;
        }

        protected virtual void AppendOrderByClause(SelectQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.OrderBy?.Expressions is null || !expression.OrderBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("ORDER BY").LineBreak()
                .Indentation++;

            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);
            try
            {
                builder.AppendElement(expression.OrderBy, context);
            }
            finally
            {
                context.PopAppendStyles();
            }

            builder.Appender
                .Indentation--;
        }
    }
}