namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinDirective<T,Y> where Y : class, new()
    {
        #region internals
        private readonly SqlExpressionBuilder<T,Y> _dbQuery;
        private readonly DBExpressionEntity<T> _joinEntity;
        private readonly DBExpressionJoinType _joinType;
        #endregion

        #region constructors
        public DBJoinDirective(SqlExpressionBuilder<T,Y> dbQuery, DBExpressionEntity<T> joinEntity, DBExpressionJoinType joinType)
        {
            _dbQuery = dbQuery;
            _joinEntity = joinEntity;
            _joinType = joinType;
        }
        #endregion

        #region methods
        public SqlExpressionBuilder<T,Y> On(DBFilterExpression filter)
        {
            _dbQuery.Expression &= _joinEntity.Join(_joinType, filter);
            return _dbQuery;
        }
        #endregion
    }
}
