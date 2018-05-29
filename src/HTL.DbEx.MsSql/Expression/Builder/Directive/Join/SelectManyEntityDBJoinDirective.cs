using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class SelectManyEntityDBJoinDirective<T> where T : class, IDBEntity, new()
    {
        #region internals
        private readonly SelectManyEntityMsSqlBuilder<T> _dbQuery;
        private readonly DBExpressionEntity _joinEntity;
        private readonly DBExpressionJoinType _joinType;
        #endregion

        #region constructors
        public SelectManyEntityDBJoinDirective(SelectManyEntityMsSqlBuilder<T> dbQuery, DBExpressionEntity joinEntity, DBExpressionJoinType joinType)
        {
            _dbQuery = dbQuery;
            _joinEntity = joinEntity;
            _joinType = joinType;
        }
        #endregion

        #region methods
        public SelectManyEntityMsSqlBuilder<T> On(DBFilterExpression filter)
        {
            _dbQuery.Expression &= _joinEntity.Join(_joinType, filter);
            return _dbQuery;
        }
        #endregion
    }
}