using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValueJoinBuilder<TValue> : SelectJoinExpressionBuilder<SelectValueContinuation<TValue>>,
        JoinOn<SelectValueContinuation<TValue>>,
        JoinOnWithAlias<SelectValueContinuation<TValue>>
    {
        #region internals
        private readonly SelectValueContinuation<TValue> caller;
        #endregion

        #region constructors
        public SelectValueJoinBuilder(SelectQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, SelectValueContinuation<TValue> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
        }
        #endregion

        #region methods
        JoinOn<SelectValueContinuation<TValue>> JoinOnWithAlias<SelectValueContinuation<TValue>>.As(string alias)
        {
            As(alias);
            return this;
        }

        SelectValueContinuation<TValue> JoinOn<SelectValueContinuation<TValue>>.On(AnyJoinOnClause joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
