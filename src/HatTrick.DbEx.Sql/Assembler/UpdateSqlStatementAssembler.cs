using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class UpdateSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!(expression is UpdateQueryExpression update))
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(UpdateQueryExpression)}, but is actually type {expression.GetType()}");

            AssembleStatement(update, builder, context);
        }
        
        protected virtual void AssembleStatement(UpdateQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender
                .Indent().Write("UPDATE");

            if (expression.Top.HasValue)
            {
                builder.Appender.Write(" TOP(").Write(expression.Top.ToString()).Write(")");
            }

            builder.Appender.LineBreak()
                .Indentation++.Indent();

            context.PushAppendStyle(EntityExpressionAppendStyle.None);
            builder.AppendElement(expression.BaseEntity, context);
            context.PopAppendStyles();

            builder.Appender
                .Indentation--.LineBreak()
                .Indent().Write("SET").LineBreak()
                .Indentation++;

            builder.AppendElement(expression.Assign, context);

            builder.Appender.LineBreak()
                .Indentation--.Indent().Write("FROM").LineBreak()
                .Indentation++.Indent();

            context.PushAppendStyle(EntityExpressionAppendStyle.Declaration);
            builder.AppendElement(expression.BaseEntity, context);
            context.PopAppendStyles();

            builder.Appender.LineBreak()
                .Indentation--;
            
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
        }

        protected virtual void AppendJoinClause(UpdateQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (expression.Joins?.Expressions is null || !expression.Joins.Expressions.Any())
                return;

            builder.Appender
                .Indentation++;

            builder.AppendElement(expression.Joins, context);

            builder.Appender
                .Indentation--;
        }

        protected virtual void AppendWhereClause(UpdateQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
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
        #endregion
    }
}