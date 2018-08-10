using HTL.DbEx.Sql.Executor;
using HTL.DbEx.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTL.DbEx.Sql.Expression
{
    public abstract class DBExpressionEntity<T> : DBExpressionEntity, IDbExpressionEntity<T>
    {
        #region interface
        #endregion

        #region constructors
        public DBExpressionEntity(string connectionName, string schema, string name) : base(connectionName, schema, name)
        {
        }
        #endregion

        #region as
        public DBExpressionEntity<T> As(string alias)
        {
            var clone = CloneUtility.DeepCopy(this);
            clone.AliasName = alias;
            return clone;
        }
        #endregion

        #region correlate
        public DBExpressionEntity<T> Correlate(string name)
        {
            var clone = CloneUtility.DeepCopy(this);
            clone.AliasName = name;
            clone.IsCorrelated = true;
            return clone;
        }
        #endregion

        #region get inclusive select expression
        //public abstract DBSelectExpressionSet GetInclusiveSelectExpression();
        #endregion

        #region get inclusive insert expression
        public abstract DBInsertExpressionSet GetInclusiveInsertExpression(T entity);
        #endregion

        #region fill object
        public abstract void FillObject(T entity, ResultSet.Row values);
        #endregion
    }
}
