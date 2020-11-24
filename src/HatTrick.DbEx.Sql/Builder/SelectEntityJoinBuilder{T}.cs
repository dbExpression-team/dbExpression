using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectEntityJoinBuilder<TEntity> : SelectJoinExpressionBuilder<SelectEntityContinuation<TEntity>>,
        JoinOn<SelectEntityContinuation<TEntity>>,
        JoinOnWithAlias<SelectEntityContinuation<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly SelectEntityContinuation<TEntity> caller;
        #endregion

        #region constructors
        public SelectEntityJoinBuilder(SelectQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, SelectEntityContinuation<TEntity> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
        }
        #endregion

        #region methods
        JoinOn<SelectEntityContinuation<TEntity>> JoinOnWithAlias<SelectEntityContinuation<TEntity>>.As(string alias)
        {
            As(alias);
            return this;
        }

        SelectEntityContinuation<TEntity> JoinOn<SelectEntityContinuation<TEntity>>.On(AnyJoinOnClause joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
