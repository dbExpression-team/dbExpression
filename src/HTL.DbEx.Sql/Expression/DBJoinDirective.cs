using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.Sql.Expression
{
    public class DBJoinDirective<T> where T : new()
    {
        #region internals
        private SqlExpressionBuilder<T> _dbQuery;
        private DBExpressionEntity _joinEntity;
        private DBExpressionJoinType _joinType;
        #endregion

        #region constructors
        public DBJoinDirective(SqlExpressionBuilder<T> dbQuery, DBExpressionEntity joinEntity, DBExpressionJoinType joinType)
        {
            _dbQuery = dbQuery;
            _joinEntity = joinEntity;
            _joinType = joinType;
        }
        #endregion

        #region methods
        public SqlExpressionBuilder<T> On(DBFilterExpression filter)
        {
            _dbQuery.Expression &= _joinEntity.Join(_joinType, filter);
            return _dbQuery;
        }
        #endregion
    }
}
