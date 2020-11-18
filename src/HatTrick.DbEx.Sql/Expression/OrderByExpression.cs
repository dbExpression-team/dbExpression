using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class OrderByExpression : 
        IExpressionElement
    {
        #region interface
        public IExpressionElement Expression { get; private set; }
        public OrderExpressionDirection Direction { get; private set; }
        #endregion

        #region constructors
        public OrderByExpression(IExpressionElement orderBy, OrderExpressionDirection direction)
        {
            Expression = orderBy ?? throw new ArgumentNullException($"{nameof(orderBy)} is required.");
            Direction = direction;
        }
        #endregion

        #region to string
        public override string ToString() => $"{Expression} {Direction}";
        #endregion

        #region conditional & operator
        public static OrderByExpressionSet operator &(OrderByExpression a, OrderByExpression b) => new OrderByExpressionSet(a, b);
        #endregion

        #region implicit order by expression set operator
        public static implicit operator OrderByExpressionSet(OrderByExpression a) => new OrderByExpressionSet(a);
        #endregion
    }
    
}
