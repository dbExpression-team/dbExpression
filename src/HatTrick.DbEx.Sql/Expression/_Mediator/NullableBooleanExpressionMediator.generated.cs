using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<bool?>(NullableBooleanExpressionMediator a) => new SelectExpression<bool?>(a.Expression);
        public static implicit operator OrderByExpression(NullableBooleanExpressionMediator a) => new OrderByExpression(a.Expression, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableBooleanExpressionMediator a) => new GroupByExpression(a.Expression);
        #endregion

        #region arithmetic operators 
        #region TValue
        #endregion

        #region mediator
        #endregion
        #endregion
    }
}
