using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class EntityExpression<T> : EntityExpression, IDbExpressionEntity<T>
    {
        #region interface
        #endregion

        #region constructors
        protected EntityExpression(EntityExpressionMetadata metadata) : base(metadata)
        {

        }

        public EntityExpression(SchemaExpression schema, string name) : this(schema, name, null)
        {
        }

        public EntityExpression(SchemaExpression schema, string name, string alias) : base(schema, name, alias)
        {
        }
        #endregion

        #region correlate
        public EntityExpression<T> Correlate(string name)
        {
            var clone = CloneUtility.DeepCopy(this);
            //TODO: do we need to support correlate?
            //clone.AliasName = name;
            clone.IsCorrelated = true;
            return clone;
        }
        #endregion

        #region get inclusive select expression
        //public abstract DBSelectExpressionSet GetInclusiveSelectExpression();
        #endregion

        #region get inclusive insert expression
        public abstract InsertExpressionSet GetInclusiveInsertExpression(T entity);
        #endregion

        #region get inclusive assignment expression
        public abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to);
        #endregion

        #region fill object
        public abstract void FillObject(SqlStatementExecutionResultSet.Row data, T entity, IValueMapper mapper);
        #endregion
    }
}
