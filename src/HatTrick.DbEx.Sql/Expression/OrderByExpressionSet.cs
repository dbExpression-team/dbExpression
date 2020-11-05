using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class OrderByExpressionSet : 
        IExpression, 
        IExpressionSet<OrderByExpression>
    {
        #region interface
        public IEnumerable<OrderByExpression> Expressions { get; private set; }  = new List<OrderByExpression>();
        #endregion

        #region constructors
        internal OrderByExpressionSet()
        { 
        
        }

        public OrderByExpressionSet(OrderByExpression orderByExpression)
        {
            Expressions = Expressions.Concat(new OrderByExpression[1] { orderByExpression ?? throw new ArgumentNullException($"{nameof(orderByExpression)} is required.") });
        }

        public OrderByExpressionSet(OrderByExpression aOrderByExpression, OrderByExpression bOrderByExpression)
        {
            Expressions = new List<OrderByExpression>
            {
                aOrderByExpression ?? throw new ArgumentNullException($"{nameof(aOrderByExpression)} is required."),
                bOrderByExpression ?? throw new ArgumentNullException($"{nameof(bOrderByExpression)} is required.")
            };
        }

        public OrderByExpressionSet(IEnumerable<OrderByExpression> orderByExpression)
        {
            Expressions = orderByExpression ?? throw new ArgumentNullException($"{nameof(orderByExpression)} is required.");
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(o => o.ToString()));
        #endregion

        #region condition & operators
        public static OrderByExpressionSet operator &(OrderByExpressionSet aSet, OrderByExpression b)
        {
            if (aSet is null)
            {
                aSet = b;
            }
            else
            {
                aSet.Expressions = aSet.Expressions.Concat(new OrderByExpression[1] { b });
            }
            return aSet;
        }

        public static OrderByExpressionSet operator &(OrderByExpressionSet aSet, OrderByExpressionSet bSet)
        {
            if (aSet is null)
                return bSet;

            aSet.Expressions = aSet.Expressions.Concat(bSet?.Expressions);
            return aSet;
        }
        #endregion
    }
    
}
