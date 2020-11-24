using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class DeleteEntitiesJoinExpressionBuilder<TEntity> : DeleteJoinExpressionBuilder<DeleteEntitiesContinuation<TEntity>>,
        JoinOn<DeleteEntitiesContinuation<TEntity>>,
        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly DeleteEntitiesContinuation<TEntity> caller;
        #endregion

        #region constructors
        public DeleteEntitiesJoinExpressionBuilder(DeleteQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, DeleteEntitiesContinuation<TEntity> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
        }
        #endregion

        #region methods
        JoinOn<DeleteEntitiesContinuation<TEntity>> JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>>.As(string alias)
        {
            As(alias);
            return this;
        }

        DeleteEntitiesContinuation<TEntity> JoinOn<DeleteEntitiesContinuation<TEntity>>.On(AnyJoinOnClause joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
