using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class HavingExpression :
        IDbExpression
    {
        #region interface
        public ExpressionContainer Expression { get; private set; }
        #endregion

        #region constructors
        internal HavingExpression()
        { 
        
        }

        public HavingExpression(FilterExpression havingCondition)
        {
            Expression = new ExpressionContainer(havingCondition ?? throw new ArgumentNullException($"{nameof(havingCondition)} is required."));
        }

        public HavingExpression(FilterExpressionSet havingCondition)
        {
            Expression = new ExpressionContainer(havingCondition ?? throw new ArgumentNullException($"{nameof(havingCondition)} is required."));
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Object.ToString();
        #endregion

        #region conditional & operator
        public static HavingExpression operator &(HavingExpression a, HavingExpression b)
        {
            if (a?.Expression == default)
            {
                b.Expression = new ExpressionContainer(b.Expression.Object, typeof(FilterExpression));
                return b;
            }
            a.Expression = new ExpressionContainer(new ExpressionContainerPair(a.Expression, b.Expression));
            return a;
        }
        #endregion
    }
    
}
