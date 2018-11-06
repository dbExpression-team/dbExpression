using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class HavingExpression : DbExpression, IDbExpressionAssemblyPart
    {
        #region interface
        public (Type,object) Expression { get; private set; }
        #endregion

        #region constructors
        internal HavingExpression(FilterExpression havingCondition)
        {
            Expression = (typeof(FilterExpression), havingCondition);
        }

        public HavingExpression(FilterExpressionSet havingCondition)
        {
            Expression = (typeof(FilterExpressionSet), havingCondition);
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Item2.ToString();
        #endregion

        #region conditional & operator
        public static HavingExpression operator &(HavingExpression a, HavingExpression b)
        {
            if (a?.Expression == default)
            {
                b.Expression = (typeof(FilterExpression), b.Expression.Item2);
                return b;
            }
            if (a.Expression.Item1 == typeof(FilterExpression) && b.Expression.Item1 == typeof(FilterExpression))
            {
                var c = a.Expression.Item2 as FilterExpression;
                c.RightPart = (typeof(FilterExpression),b);
            }
            return a;
        }
        #endregion
    }
    
}
