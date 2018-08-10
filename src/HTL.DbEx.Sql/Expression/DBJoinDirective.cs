using HTL.DbEx.Sql.Builder;

namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinDirective
    {
        #region internals
        private readonly SqlExpressionBuilder _dbQuery;
        private readonly DBExpressionEntity _joinEntity;
        private readonly DBExpressionJoinType _joinType;
        #endregion

        #region constructors
        public DBJoinDirective(SqlExpressionBuilder dbQuery, DBExpressionEntity joinEntity, DBExpressionJoinType joinType)
        {
            _dbQuery = dbQuery;
            _joinEntity = joinEntity;
            _joinType = joinType;
        }
        #endregion

        #region methods
        public SqlExpressionBuilder On(DBFilterExpression filter)
        {
            _dbQuery.Expression &= _joinEntity.Join(_joinType, filter);
            return _dbQuery;
        }
        #endregion
    }
}
