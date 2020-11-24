using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class HavingExpression :
        AnyHavingClause,
        IFilterExpressionElement
    {
        #region interface
        public FilterExpressionSet Expression { get; private set; }
        #endregion

        #region constructors
        private HavingExpression()
        { 
        
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
            if (a?.Expression is null)
                return b;

            if (b?.Expression is null)
                return a;

            a.Expression &= new FilterExpressionSet(a.Expression, b.Expression, ConditionalExpressionOperator.And);
            return a;
        }
        #endregion
    }
    
}
