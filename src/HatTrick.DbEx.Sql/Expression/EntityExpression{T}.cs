using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Utility;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class EntityExpression<T> : 
        EntityExpression, 
        IDbExpressionEntity<T>
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

        #region IDbExpressionEntity implementation
        SelectExpressionSet IDbExpressionEntity<T>.BuildInclusiveSelectExpression()
            => GetInclusiveSelectExpression();
        InsertExpressionSet IDbExpressionEntity<T>.BuildInclusiveInsertExpression(T entity)
            => GetInclusiveInsertExpression(entity);
        AssignmentExpressionSet IDbExpressionEntity<T>.BuildAssignmentExpression(T from, T to)
            => GetAssignmentExpression(from, to);
        void IDbExpressionEntity<T>.HydrateEntity(T entity, IFieldReader reader, IValueMapper valueMapper)
            => HydrateEntity(entity, reader, valueMapper);
        #endregion

        #region get inclusive insert expression
        protected abstract InsertExpressionSet GetInclusiveInsertExpression(T entity);
        #endregion

        #region get inclusive assignment expression
        protected abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to);
        #endregion

        #region fill object
        protected abstract void HydrateEntity(T entity, IFieldReader reader, IValueMapper mapper);
        #endregion
    }
}
