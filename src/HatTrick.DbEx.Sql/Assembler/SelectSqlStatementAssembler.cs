using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SelectSqlStatementAssembler : SqlStatementAssembler
    {
        public override void AssembleStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            AssembleSelectStatement(expression, builder, context);
        }

        protected virtual void AssembleSelectStatement(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            AppendSelectClause(expression, builder, context);
            AppendFromClause(expression, builder, context);
            AppendJoinClause(expression, builder, context);
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

        protected virtual void AppendGroupByClause(ExpressionSet expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.GroupBy?.Expressions == null || !expression.GroupBy.Expressions.Any())
                return;

            builder.Appender.Indent().Write("GROUP BY").LineBreak()
                .Indentation++;

            builder.AppendPart(expression.GroupBy, context);

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

            builder.AppendPart(expression.OrderBy, context);

            builder.Appender
                .Indentation--;
        }
    }
}