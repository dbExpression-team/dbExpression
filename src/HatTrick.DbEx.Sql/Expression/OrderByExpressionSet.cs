using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class OrderByExpressionSet :
        AnyOrderByClause, 
        IExpressionSet<AnyOrderByClause>
    {
        #region interface
        public IEnumerable<AnyOrderByClause> Expressions { get; private set; }  = new List<AnyOrderByClause>();
        #endregion

        #region constructors
        internal OrderByExpressionSet()
        { 
        
        }

        public OrderByExpressionSet(AnyOrderByClause orderByExpression)
        {
            Expressions = Expressions.Concat(new AnyOrderByClause[1] { orderByExpression ?? throw new ArgumentNullException($"{nameof(orderByExpression)} is required.") });
        }

        public OrderByExpressionSet(AnyOrderByClause aOrderByExpression, AnyOrderByClause bOrderByExpression)
        {
            Expressions = new List<AnyOrderByClause>
            {
                aOrderByExpression ?? throw new ArgumentNullException($"{nameof(aOrderByExpression)} is required."),
                bOrderByExpression ?? throw new ArgumentNullException($"{nameof(bOrderByExpression)} is required.")
            };
        }

        public OrderByExpressionSet(IEnumerable<AnyOrderByClause> orderByExpression)
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
                aSet.Expressions = aSet.Expressions.Concat(new AnyOrderByClause[1] { b });
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
