using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBAssignmentExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private readonly List<DBAssignmentExpression> _assignments = new List<DBAssignmentExpression>();
        #endregion

        #region constructors
        internal DBAssignmentExpressionSet()
        {
        }

        internal DBAssignmentExpressionSet(DBAssignmentExpression a1)
        {
            _assignments.Add(a1);
        }

        internal DBAssignmentExpressionSet(DBAssignmentExpression a1, DBAssignmentExpression a2)
        {
            _assignments.Add(a1);
            _assignments.Add(a2);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", _assignments.ConvertAll(a => a.ToString()));
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService) => string.Join(", ", _assignments.ConvertAll(a => a.ToParameterizedString(parameters, dbService)));
        #endregion

        #region logical & operator
        public static DBAssignmentExpressionSet operator &(DBAssignmentExpressionSet aSet, DBAssignmentExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBAssignmentExpressionSet(b);
            }
            else
            {
                aSet._assignments.Add(b);
            }
            return aSet;
        }

        public static DBAssignmentExpressionSet operator &(DBAssignmentExpressionSet aSet, DBAssignmentExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBAssignmentExpressionSet();
            }
            aSet._assignments.AddRange(bSet._assignments);
            return aSet;
        }
        #endregion
    }
    
}
