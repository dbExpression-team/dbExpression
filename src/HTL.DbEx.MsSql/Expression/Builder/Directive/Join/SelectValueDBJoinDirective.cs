using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class SelectValueDBJoinDirective<T>
    {
        #region internals
        private readonly SelectValueMsSqlBuilder<T> _dbQuery;
        private readonly DBExpressionEntity _joinEntity;
        private readonly DBExpressionJoinType _joinType;
        #endregion

        #region constructors
        public SelectValueDBJoinDirective(SelectValueMsSqlBuilder<T> dbQuery, DBExpressionEntity joinEntity, DBExpressionJoinType joinType)
        {
            _dbQuery = dbQuery;
            _joinEntity = joinEntity;
            _joinType = joinType;
        }
        #endregion

        #region methods
        public SelectValueMsSqlBuilder<T> On(DBFilterExpression filter)
        {
            _dbQuery.Expression &= _joinEntity.Join(_joinType, filter);
            return _dbQuery;
        }
        #endregion
    }
}