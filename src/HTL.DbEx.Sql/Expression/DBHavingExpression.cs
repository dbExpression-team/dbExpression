using HTL.DbEx.Sql.Assembler;
using System;

namespace HTL.DbEx.Sql.Expression
{
    public class DBHavingExpression : DBExpression, ISqlAssemblyPart
    {
        #region interface
        public (Type,object) Expression { get; private set; }
        #endregion

        #region constructors
        internal DBHavingExpression(DBFilterExpression havingCondition)
        {
            Expression = (typeof(DBFilterExpression), havingCondition);
        }

        public DBHavingExpression(DBFilterExpressionSet havingCondition)
        {
            Expression = (typeof(DBFilterExpressionSet), havingCondition);
        }
        #endregion

        #region to string
        public override string ToString() => Expression.Item2.ToString();
        #endregion

        #region conditional & operator
        public static DBHavingExpression operator &(DBHavingExpression a, DBHavingExpression b)
        {
            if (a.Expression.Item1 == typeof(DBFilterExpression) && b.Expression.Item1 == typeof(DBFilterExpression))
            {
                var c = a.Expression.Item2 as DBFilterExpression;
                c.RightPart = (typeof(DBFilterExpression),b);
            }
            return a;
        }
        #endregion
    }
    
}
