using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<Guid>(GuidExpressionMediator a) => new SelectExpression<Guid>(a.Expression);
        public static implicit operator OrderByExpression(GuidExpressionMediator a) => new OrderByExpression(a.Expression, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(GuidExpressionMediator a) => new GroupByExpression(a.Expression);
        #endregion

        #region arithmetic operators
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion
    }
}
