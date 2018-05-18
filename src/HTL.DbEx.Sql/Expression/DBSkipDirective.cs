namespace HTL.DbEx.Sql.Expression
{
    public class DBSkipDirective<T> where T : class, new()
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
            _dbQuery.LimitValue = count;
            return _dbQuery;
        }
        #endregion
    }
}
