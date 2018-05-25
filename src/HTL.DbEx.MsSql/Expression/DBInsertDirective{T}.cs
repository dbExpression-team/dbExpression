using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class DBInsertDirective<T>
    {
        #region internals
        private T _recrod;
        private DBExpressionEntity<T> _entity;
        #endregion

        #region constructors
        public DBInsertDirective(T record)
        {
        }
        #endregion

        #region into
        public DBInsertDirective<T> Into(DBExpressionEntity<T> entity)
        {
            _entity = entity;
            return this;
        }
        #endregion
    }
}
