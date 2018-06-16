using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class UpdateDBJoinDirective<T>
    {
        #region internals
        private readonly UpdateMsSqlBuilder<T> _dbQuery;
        private readonly DBExpressionEntity _joinEntity;
        private readonly DBExpressionJoinType _joinType;
        #endregion

        #region constructors
        public UpdateDBJoinDirective(UpdateMsSqlBuilder<T> dbQuery, DBExpressionEntity joinEntity, DBExpressionJoinType joinType)
        {
            _dbQuery = dbQuery;
            _joinEntity = joinEntity;
            _joinType = joinType;
        }
        #endregion

        #region methods
        public UpdateMsSqlBuilder<T> On(DBFilterExpression filter)
        {
            _dbQuery.Expression &= _joinEntity.Join(_joinType, filter);
            return _dbQuery;
        }
        #endregion
    }
}
