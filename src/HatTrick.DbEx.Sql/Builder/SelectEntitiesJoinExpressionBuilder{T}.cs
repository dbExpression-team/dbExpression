using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectEntitiesJoinExpressionBuilder<TEntity> : SelectJoinExpressionBuilder<SelectEntitiesContinuation<TEntity>>,
        JoinOn<SelectEntitiesContinuation<TEntity>>,
        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly SelectEntitiesContinuation<TEntity> caller;
        #endregion

        #region constructors
        public SelectEntitiesJoinExpressionBuilder(SelectQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, SelectEntitiesContinuation<TEntity> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
        }
        #endregion

        #region methods
        JoinOn<SelectEntitiesContinuation<TEntity>> JoinOnWithAlias<SelectEntitiesContinuation<TEntity>>.As(string alias)
        {
            As(alias);
            return this;
        }

        SelectEntitiesContinuation<TEntity> JoinOn<SelectEntitiesContinuation<TEntity>>.On(AnyJoinOnClause joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
