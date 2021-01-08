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
        private OrderByExpressionSet()
        { 
        
        }

        public OrderByExpressionSet(AnyOrderByClause orderBy)
        {
            Expressions = Expressions.Concat(new AnyOrderByClause[1] { (orderBy ?? throw new ArgumentNullException($"{nameof(orderBy)} is required.")) is OrderByExpression ? orderBy : new OrderByExpression(orderBy, OrderExpressionDirection.ASC) });
        }

        public OrderByExpressionSet(OrderByExpression aOrderBy, OrderByExpression bOrderBy)
        {
            Expressions = new List<AnyOrderByClause>
            {
                aOrderBy ?? throw new ArgumentNullException($"{nameof(aOrderBy)} is required."),
                bOrderBy ?? throw new ArgumentNullException($"{nameof(bOrderBy)} is required.")
            };
        }

        public OrderByExpressionSet(IEnumerable<AnyOrderByClause> orderBys)
        {
            Expressions = (orderBys ?? throw new ArgumentNullException($"{nameof(orderBys)} is required.")).Select(x => x is OrderByExpression ? x : new OrderByExpression(x, OrderExpressionDirection.ASC));
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
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
