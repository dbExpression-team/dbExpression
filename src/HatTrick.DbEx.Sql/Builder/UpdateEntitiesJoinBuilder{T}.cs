using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class UpdateEntitiesJoinBuilder<TEntity> : UpdateJoinExpressionBuilder<UpdateEntitiesContinuation<TEntity>>,
        JoinOn<UpdateEntitiesContinuation<TEntity>>,
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly UpdateEntitiesContinuation<TEntity> caller;
        #endregion

        #region constructors
        public UpdateEntitiesJoinBuilder(UpdateQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, UpdateEntitiesContinuation<TEntity> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
        }
        #endregion

        #region methods
        JoinOn<UpdateEntitiesContinuation<TEntity>> JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>>.As(string alias)
        {
            As(alias);
            return this;
        }

        UpdateEntitiesContinuation<TEntity> JoinOn<UpdateEntitiesContinuation<TEntity>>.On(AnyJoinOnClause joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
