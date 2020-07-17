using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class OrderByExpressionSet : 
        IDbExpression, 
        IDbExpressionSet<OrderByExpression>
    {
        #region interface
        public IList<OrderByExpression> Expressions { get; }  = new List<OrderByExpression>();
        #endregion

        #region constructors
        internal OrderByExpressionSet()
        { 
        
        }

        public OrderByExpressionSet(OrderByExpression orderByExpression)
        {
            Expressions.Add(orderByExpression ?? throw new ArgumentNullException($"{nameof(orderByExpression)} is required."));
        }

        public OrderByExpressionSet(OrderByExpression aOrderByExpression, OrderByExpression bOrderByExpression)
        {
            Expressions.Add(aOrderByExpression ?? throw new ArgumentNullException($"{nameof(aOrderByExpression)} is required."));
            Expressions.Add(bOrderByExpression ?? throw new ArgumentNullException($"{nameof(bOrderByExpression)} is required."));
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
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static OrderByExpressionSet operator &(OrderByExpressionSet aSet, OrderByExpressionSet bSet)
        {
            foreach (var b in bSet.Expressions)
            {
                if (aSet is null)
                {
                    aSet = b;
                }
                else
                {
                    aSet.Expressions.Add(b);
                }
            }
            return aSet;
        }
        #endregion
    }
    
}
