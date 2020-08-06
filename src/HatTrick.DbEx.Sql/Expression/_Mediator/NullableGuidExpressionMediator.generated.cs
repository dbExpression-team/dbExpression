using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableGuidExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid?>(NullableGuidExpressionMediator a) => new SelectExpression<Guid?>(a);
        public static implicit operator OrderByExpression(NullableGuidExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableGuidExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators 
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion
    }
}
