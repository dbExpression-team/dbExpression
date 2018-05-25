namespace HTL.DbEx.Sql.Expression
{
    public class DBSkipDirective
    {
        #region internals
        private SqlExpressionBuilder _dbQuery;
        #endregion

        #region constructors
        public DBSkipDirective(SqlExpressionBuilder dbQuery)
        {
            _dbQuery = dbQuery;
        }
        #endregion

        #region methods
        public SqlExpressionBuilder Limit(int count)
        {
            _dbQuery.LimitValue = count;
            return _dbQuery;
        }
        #endregion
    }
}
