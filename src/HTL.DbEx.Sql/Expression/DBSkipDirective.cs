using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.Sql.Expression
{
    public class DBSkipDirective<T> where T : new()
    {
        #region internals
        private SqlExpressionBuilder<T> _dbQuery;
        #endregion

        #region constructors
        public DBSkipDirective(SqlExpressionBuilder<T> dbQuery)
        {
            _dbQuery = dbQuery;
        }
        #endregion

        #region methods
        public SqlExpressionBuilder<T> Limit(int count)
        {
            _dbQuery.Limit = count;
            return _dbQuery;
        }
        #endregion
    }
}
