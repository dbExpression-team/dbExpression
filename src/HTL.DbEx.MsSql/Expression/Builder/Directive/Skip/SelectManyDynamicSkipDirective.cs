namespace HTL.DbEx.MsSql.Expression
{
    public class SelectManyDynamicDBSkipDirective<T>
    {
        #region internals
        private SelectManyDynamicMsSqlBuilder<T> _dbQuery;
        #endregion

        #region constructors
        public SelectManyDynamicDBSkipDirective(SelectManyDynamicMsSqlBuilder<T> dbQuery)
        {
            _dbQuery = dbQuery;
        }
        #endregion

        #region methods
        public SelectManyDynamicMsSqlBuilder<T> Limit(int count)
        {
            _dbQuery.LimitValue = count;
            return _dbQuery;
        }
        #endregion
    }
}
