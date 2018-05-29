using HTL.DbEx.Sql;

namespace HTL.DbEx.MsSql.Expression
{
    public class SelectEntityDBSkipDirective<T> where T : class, IDBEntity, new()
    {
        #region internals
        private SelectEntityMsSqlBuilder<T> _dbQuery;
        #endregion

        #region constructors
        public SelectEntityDBSkipDirective(SelectEntityMsSqlBuilder<T> dbQuery)
        {
            _dbQuery = dbQuery;
        }
        #endregion

        #region methods
        public SelectEntityMsSqlBuilder<T> Limit(int count)
        {
            _dbQuery.LimitValue = count;
            return _dbQuery;
        }
        #endregion
    }
}
