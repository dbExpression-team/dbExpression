using HTL.DbEx.Sql;

namespace HTL.DbEx.MsSql.Expression
{
    public class SelectManyEntityDBSkipDirective<T> where T : class, IDBEntity, new()
    {
        #region internals
        private SelectManyEntityMsSqlBuilder<T> _dbQuery;
        #endregion

        #region constructors
        public SelectManyEntityDBSkipDirective(SelectManyEntityMsSqlBuilder<T> dbQuery)
        {
            _dbQuery = dbQuery;
        }
        #endregion

        #region methods
        public SelectManyEntityMsSqlBuilder<T> Limit(int count)
        {
            _dbQuery.LimitValue = count;
            return _dbQuery;
        }
        #endregion
    }
}
