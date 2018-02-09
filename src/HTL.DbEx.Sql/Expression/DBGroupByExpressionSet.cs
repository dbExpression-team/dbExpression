using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBGroupByExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private readonly List<DBGroupByExpression> _groupings = new List<DBGroupByExpression>();
        #endregion

        #region constructors
        internal DBGroupByExpressionSet(DBGroupByExpression a)
        {
            _groupings.Add(a);
        }

        internal DBGroupByExpressionSet(DBGroupByExpression a, DBGroupByExpression b)
        {
            _groupings.Add(a);
            _groupings.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", _groupings.ConvertAll(g => g.ToString()));
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService) => string.Join(", ", _groupings.ConvertAll(g => g.ToParameterizedString(parameters, dbService)));
        #endregion

        #region conditional & operator
        public static DBGroupByExpressionSet operator &(DBGroupByExpressionSet aSet, DBGroupByExpression b)
        {
            aSet._groupings.Add(b);
            return aSet;
        }

        public static DBGroupByExpressionSet operator &(DBGroupByExpressionSet aSet, DBGroupByExpressionSet bSet)
        {
            aSet._groupings.AddRange(bSet._groupings);
            return aSet;
        }
        #endregion
    }
    
}
