using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class OrderByExpression : 
        IDbExpression, 
        IAssemblyPart
    {
        #region interface
        public ExpressionContainer Expression { get; private set; }
        public OrderExpressionDirection Direction { get; private set; }
        #endregion

        #region constructors
        public OrderByExpression(ExpressionContainer orderByContainer, OrderExpressionDirection direction)
        {
            Expression = orderByContainer ?? throw new ArgumentNullException($"{nameof(orderByContainer)} is required.");
            Direction = direction;
        }
        #endregion

        #region to string
        public override string ToString() => $"{Expression.Object} {Direction}";
        #endregion

        #region conditional & operator
        public static OrderByExpressionSet operator &(OrderByExpression a, OrderByExpression b) => new OrderByExpressionSet(a, b);
        #endregion

        #region implicit order by expression set operator
        public static implicit operator OrderByExpressionSet(OrderByExpression a) => new OrderByExpressionSet(a);
        #endregion
    }
    
}
