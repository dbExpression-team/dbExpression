using HatTrick.DbEx.Sql.Expression;

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
                .Indent().Write("UPDATE").LineBreak()
                .Indentation++.Indent();

            context.PushAppendStyle(EntityExpressionAppendStyle.None);
            builder.AppendPart(expression.BaseEntity, context);
            context.PopAppendStyles();

            builder.Appender
                .Indentation--.LineBreak()
                .Indent().Write("SET").LineBreak()
                .Indentation++;

            builder.AppendPart(expression.Assign, context);

            builder.Appender.LineBreak()
                .Indentation--.Indent().Write("FROM").LineBreak()
                .Indentation++.Indent();

            context.PushAppendStyle(EntityExpressionAppendStyle.Declaration);
            builder.AppendPart(expression.BaseEntity, context);
            context.PopAppendStyles();

            builder.Appender.Indentation--;
            
            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
        }
        #endregion
    }
}