using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class InsertSqlStatementAssembler : SqlStatementAssembler
    {
        #region methods
        public override void AssembleStatement(QueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context)
        {
            if (!(expression is InsertQueryExpression insert))
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(InsertQueryExpression)}, but is actually type {expression.GetType()}");

            AssembleStatement(insert, builder, context);
        }

        protected abstract void AssembleStatement(InsertQueryExpression expression, ISqlStatementBuilder builder, AssemblyContext context);
        #endregion
    }
}