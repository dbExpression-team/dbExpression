using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EntityExpression<T> : 
        EntityExpression, 
        IDbExpressionEntity<T>
        where T : class, IDbEntity
    {
        #region constructors
        protected EntityExpression(object identifier, SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias)
            : base(identifier, schema, metadata, alias)
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
        void IDbExpressionEntity<T>.HydrateEntity(T entity, ISqlFieldReader reader, IValueMapper valueMapper)
            => HydrateEntity(entity, reader, valueMapper);
        #endregion

        #region get inclusive insert expression
        protected abstract InsertExpressionSet GetInclusiveInsertExpression(T entity);
        #endregion

        #region get inclusive assignment expression
        protected abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to);
        #endregion

        #region fill object
        protected abstract void HydrateEntity(T entity, ISqlFieldReader reader, IValueMapper mapper);

        protected abstract void HydrateField(T entity, FieldExpression field, object value, IValueMapper mapper);

        protected override void HydrateField(IDbEntity entity, FieldExpression field, object value, IValueMapper mapper)
            => HydrateField(entity as T, field, value, mapper);

        #endregion
    }
}
