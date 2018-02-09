using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBSelectExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private readonly List<DBSelectExpression> _selectExpressions = new List<DBSelectExpression>();
        #endregion

        #region constructor
        internal DBSelectExpressionSet()
        {
        }

        internal DBSelectExpressionSet(DBSelectExpression a)
        {
            _selectExpressions.Add(a);
        }

        internal DBSelectExpressionSet(DBSelectExpression a, DBSelectExpression b)
        {
            _selectExpressions.Add(a);
            _selectExpressions.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", _selectExpressions.ConvertAll(s => s.ToString()));
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService) => string.Join(", ", _selectExpressions.ConvertAll(s => s.ToParameterizedString(parameters, dbService)));
        #endregion

        #region logical & operator
        public static DBSelectExpressionSet operator &(DBSelectExpressionSet aSet, DBSelectExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBSelectExpressionSet(b);
            }
            else
            {
                aSet._selectExpressions.Add(b);
            }
            return aSet;
        }

        public static DBSelectExpressionSet operator &(DBSelectExpressionSet aSet, DBSelectExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBSelectExpressionSet();
            }
            aSet._selectExpressions.AddRange(bSet._selectExpressions);
            return aSet;
        }
        #endregion
    }
    
}
