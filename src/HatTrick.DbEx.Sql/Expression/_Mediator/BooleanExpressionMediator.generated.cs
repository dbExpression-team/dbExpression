using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class BooleanExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<bool>(BooleanExpressionMediator a) => new SelectExpression<bool>(a);
        public static implicit operator OrderByExpression(BooleanExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(BooleanExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion
    }
}
