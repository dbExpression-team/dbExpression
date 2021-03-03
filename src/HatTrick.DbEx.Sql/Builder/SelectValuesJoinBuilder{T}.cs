using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValuesJoinBuilder<TValue> : SelectJoinExpressionBuilder<SelectValuesContinuation<TValue>>,
        JoinOn<SelectValuesContinuation<TValue>>,
        JoinOnWithAlias<SelectValuesContinuation<TValue>>
    {
        #region internals
        private readonly SelectValuesContinuation<TValue> caller;
        #endregion

        #region constructors
        public SelectValuesJoinBuilder(SelectQueryExpression expression, IExpressionElement joinTo, JoinOperationExpressionOperator joinType, SelectValuesContinuation<TValue> caller)
            : base(expression, joinTo, joinType)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
        }
        #endregion

        #region methods
        JoinOn<SelectValuesContinuation<TValue>> JoinOnWithAlias<SelectValuesContinuation<TValue>>.As(string alias)
        {
            As(alias);
            return this;
        }

        SelectValuesContinuation<TValue> JoinOn<SelectValuesContinuation<TValue>>.On(AnyJoinOnClause joinOn)
        {
            On(joinOn);
            return caller;
        }
        #endregion
    }
}
