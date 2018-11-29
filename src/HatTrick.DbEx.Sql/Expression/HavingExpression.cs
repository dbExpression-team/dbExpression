using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class HavingExpression : DbExpression, IAssemblyPart
    {
        #region interface
        public (Type,object) Expression { get; private set; }
        #endregion

        #region constructors
        internal HavingExpression()
        {
        }

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
            a.Expression = (typeof(DbExpressionPair), new DbExpressionPair(a.Expression, (typeof(FilterExpression),b)));
            return a;
        }
        #endregion
    }
    
}
