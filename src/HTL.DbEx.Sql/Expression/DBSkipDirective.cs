namespace HTL.DbEx.Sql.Expression
{
    public class DBSkipDirective<T,Y> where Y : class, new()
    {
        #region internals
        private SqlExpressionBuilder<T,Y> _dbQuery;
        #endregion

        #region constructors
        public DBSkipDirective(SqlExpressionBuilder<T,Y> dbQuery)
        {
            _dbQuery = dbQuery;
        }
        #endregion

        #region methods
        public SqlExpressionBuilder<T,Y> Limit(int count)
        {
            _dbQuery.LimitValue = count;
            return _dbQuery;
        }
        #endregion
    }
}
