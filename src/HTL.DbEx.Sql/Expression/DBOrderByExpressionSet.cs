using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBOrderByExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private readonly List<DBOrderByExpression> _orderBys = new List<DBOrderByExpression>();
        #endregion

        #region constructors
        internal DBOrderByExpressionSet(DBOrderByExpression a)
        {
            _orderBys.Add(a);
        }

        internal DBOrderByExpressionSet(DBOrderByExpression a, DBOrderByExpression b)
        {
            _orderBys.Add(a);
            _orderBys.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", _orderBys.ConvertAll<string>(o => o.ToString()));
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService) => string.Join(", ", _orderBys.ConvertAll(o => o.ToParameterizedString(parameters, dbService)));
        #endregion

        #region condition & operators
        public static DBOrderByExpressionSet operator &(DBOrderByExpressionSet aSet, DBOrderByExpression b)
        {
            aSet._orderBys.Add(b);
            return aSet;
        }

        public static DBOrderByExpressionSet operator &(DBOrderByExpressionSet aSet, DBOrderByExpressionSet bSet)
        {
            aSet._orderBys.AddRange(bSet._orderBys);
            return aSet;
        }
        #endregion
    }
    
}
