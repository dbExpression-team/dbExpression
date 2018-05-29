namespace HTL.DbEx.MsSql.Expression
{
    public class SelectValueDBSkipDirective<T>
    {
        #region internals
        private SelectValueMsSqlBuilder<T> _dbQuery;
        #endregion

        #region constructors
        public SelectValueDBSkipDirective(SelectValueMsSqlBuilder<T> dbQuery)
        {
            _dbQuery = dbQuery;
        }
        #endregion

        #region methods
        public SelectValueMsSqlBuilder<T> Limit(int count)
        {
            _dbQuery.LimitValue = count;
            return _dbQuery;
        }
        #endregion
    }
}
