using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class HavingExpression :
        IExpressionElement
    {
        #region interface
        public IExpressionElement Expression { get; private set; }
        #endregion

        #region constructors
        internal HavingExpression()
        { 
        
        }

        public HavingExpression(FilterExpression havingCondition)
        {
            Expression = havingCondition ?? throw new ArgumentNullException($"{nameof(havingCondition)} is required.");
        }

        public HavingExpression(FilterExpressionSet havingCondition)
        {
            Expression = havingCondition ?? throw new ArgumentNullException($"{nameof(havingCondition)} is required.");
        }
        #endregion

        #region to string
        public override string ToString() => Expression.ToString();
        #endregion

        #region conditional & operator
        public static HavingExpression operator &(HavingExpression a, HavingExpression b)
        {
            if (a?.Expression == default)
            {
                a.Expression = b.Expression;
                return a;
            }
            a.Expression = new ExpressionPair(a.Expression, b.Expression);
            return a;
        }
        #endregion
    }
    
}
