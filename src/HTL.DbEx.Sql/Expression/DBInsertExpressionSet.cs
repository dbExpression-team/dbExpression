using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBInsertExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private readonly List<DBInsertExpression> _insertExpressions = new List<DBInsertExpression>();
        #endregion

        #region constructors
        public DBInsertExpressionSet()
        {
        }

        public DBInsertExpressionSet(DBInsertExpression a)
        {
            _insertExpressions.Add(a);
        }

        public DBInsertExpressionSet(DBInsertExpression a, DBInsertExpression b)
        {
            _insertExpressions.Add(a);
            _insertExpressions.Add(b);
        }
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService)
        {
            string[] cols = new string[_insertExpressions.Count];
            string[] parms = new string[_insertExpressions.Count];
            for (int i = 0; i < _insertExpressions.Count; i++)
            {
                cols[i] = _insertExpressions[i]._field.ToString();
                parms[i] = "@I" + (i + 1);

                parameters.Add(dbService.GetDbParameter(parms[i], _insertExpressions[i]._value, _insertExpressions[i]._type, _insertExpressions[i]._field.Size));
            }

            string expr = $"({string.Join(", ", cols)}) VALUES ({string.Join(", ", parms)})";
            return expr;
        }
        #endregion

        #region logical & operator
        public static DBInsertExpressionSet operator &(DBInsertExpressionSet aSet, DBInsertExpression b)
        {
            if (aSet == null)
            {
                aSet = new DBInsertExpressionSet(b);
            }
            else
            {
                aSet._insertExpressions.Add(b);
            }
            return aSet;
        }

        public static DBInsertExpressionSet operator &(DBInsertExpressionSet aSet, DBInsertExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new DBInsertExpressionSet();
            }
            aSet._insertExpressions.AddRange(bSet._insertExpressions);
            return aSet;
        }
        #endregion
    }

}
