using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class DBSelectDirective
    {
        #region internals
        private DBExpressionEntity _entity;
        #endregion

        #region constructors
        public DBSelectDirective(params DBExpressionField[] fields)
        {
        }

        public DBSelectDirective(DBSelectExpression select)
        {
        }
        #endregion

        #region into
        public DBSelectDirective<T> From(DBExpressionEntity<T> entity)
        {
            _entity = entity;
            return this;
        }
        #endregion
    }

    public class DBSelectDirective<T>
    {
        #region internals
        private DBExpressionEntity<T> _entity;
        #endregion

        #region constructors
        public DBSelectDirective(params DBExpressionField[] fields)
        {
        }

        public DBSelectDirective(DBSelectExpression select)
        {
        }
        #endregion

        #region into
        public DBSelectDirective<T> From(DBExpressionEntity<T> entity)
        {
            _entity = entity;
            return this;
        }
        #endregion
    }
}
