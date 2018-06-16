namespace HTL.DbEx.MsSql.Expression
{
    public class SelectManyValueDBSkipDirective<T>
    {
        #region internals
        private SelectManyValueMsSqlBuilder<T> _dbQuery;
        #endregion

        #region constructors
        public SelectManyValueDBSkipDirective(SelectManyValueMsSqlBuilder<T> dbQuery)
        {
            _dbQuery = dbQuery;
        }
        #endregion

        #region methods
        public SelectManyValueMsSqlBuilder<T> Limit(int count)
        {
            _dbQuery.LimitValue = count;
            return _dbQuery;
        }
        #endregion
    }
}
