using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinExpressionSet : DBExpression, IDBExpression
    {
        #region internals
        private readonly List<DBJoinExpression> _joins = new List<DBJoinExpression>();
        #endregion

        #region constructors
        public DBJoinExpressionSet(DBJoinExpression a)
        {
            _joins.Add(a);
        }

        public DBJoinExpressionSet(DBJoinExpression a, DBJoinExpression b)
        {
            _joins.Add(a);
            _joins.Add(b);
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(Environment.NewLine, _joins.ConvertAll(j => j.ToString()));
        #endregion

        #region to parameterized string
        public string ToParameterizedString(IList<DbParameter> parameters, SqlConnection dbService) => string.Join(Environment.NewLine, _joins.ConvertAll<string>(j => j.ToParameterizedString(parameters, dbService)));
        #endregion

        #region logical & operator
        public static DBJoinExpressionSet operator &(DBJoinExpressionSet aSet, DBJoinExpression b)
        {
            aSet._joins.Add(b);
            return aSet;
        }

        public static DBJoinExpressionSet operator &(DBJoinExpressionSet aSet, DBJoinExpressionSet bSet)
        {
            aSet._joins.AddRange(bSet._joins);
            return aSet;
        }
        #endregion
    }
    
}
