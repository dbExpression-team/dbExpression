using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBGroupByExpression : DBExpression, IDBExpression
    {
        #region internals
        private readonly DBExpression _groupingExpression;
        #endregion

        #region constructors
        internal DBGroupByExpression(DBExpressionField field)
        {
            _groupingExpression = field;
        }

        internal DBGroupByExpression(DBSelectExpression expression)
        {
            _groupingExpression = expression;
        }
        #endregion

        #region to string
        public override string ToString() => _groupingExpression.ToString();
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService)
        {
            var asDbExpression = _groupingExpression as IDBExpression;
            return asDbExpression == null ? _groupingExpression.ToString() : asDbExpression.ToParameterizedString(parameters, dbService);
        }
        #endregion

        #region conditional & operator
        public static DBGroupByExpressionSet operator &(DBGroupByExpression a, DBGroupByExpression b) => new DBGroupByExpressionSet(a, b);
        #endregion

        #region implicit group by expression set operator
        public static implicit operator DBGroupByExpressionSet(DBGroupByExpression a) => new DBGroupByExpressionSet(a);
        #endregion
    }
    
}
