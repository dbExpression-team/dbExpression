using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBHavingExpression : DBExpression, IDBExpression
    {
        #region internals
        private DBFilterExpressionSet HavingCondition { get; set; }
        #endregion

        #region constructors
        internal DBHavingExpression(DBFilterExpression havingCondition)
        {
            HavingCondition = new DBFilterExpressionSet(havingCondition);
        }

        public DBHavingExpression(DBFilterExpressionSet havingCondition)
        {
            HavingCondition = havingCondition;
        }
        #endregion

        #region to string
        public override string ToString() => HavingCondition.ToString();
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService) => HavingCondition.ToParameterizedString(parameters, dbService);
        #endregion

        #region conditional & operator
        public static DBHavingExpression operator &(DBHavingExpression a, DBHavingExpression b)
        {
            a.HavingCondition &= b.HavingCondition;
            return a;
        }
        #endregion
    }
    
}
