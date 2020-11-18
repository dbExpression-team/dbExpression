using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class DeleteSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!(expression is DeleteQueryExpression delete))
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(DeleteQueryExpression)}, but is actually type {expression.GetType()}");

            AssembleStatement(delete, builder, context);
        }

        protected virtual void AssembleStatement(DeleteQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            builder.Appender.Write("DELETE").LineBreak();

            builder.Appender.Indentation++.Indent();
            builder.AppendElement(expression.BaseEntity, context);
            builder.Appender.LineBreak();

            builder.Appender.Indentation--.Indent().Write("FROM").LineBreak();

            builder.Appender.Indentation++.Indent();
            builder.AppendElement(expression.BaseEntity, context);
            builder.Appender.LineBreak();
            builder.Appender.Indentation--;

            AppendJoinClause(expression, builder, context);
            AppendWhereClause(expression, builder, context);
        }
        #endregion
    }
}