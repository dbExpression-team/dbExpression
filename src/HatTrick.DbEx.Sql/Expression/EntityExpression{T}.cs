using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EntityExpression<T> : 
        EntityExpression, 
        IExpressionEntity<T>
        where T : class, IDbEntity
    {
        #region constructors
        protected EntityExpression(string identifier, SchemaExpression schema, string alias)
            : base(identifier, schema, alias)
        {

        }
        #endregion

        #region IExpressionEntity implementation
        SelectExpressionSet IExpressionEntity.BuildInclusiveSelectExpression()
            => GetInclusiveSelectExpression();
        InsertExpressionSet<T> IExpressionEntity<T>.BuildInclusiveInsertExpression(T entity)
            => GetInclusiveInsertExpression(entity);
        AssignmentExpressionSet IExpressionEntity<T>.BuildAssignmentExpression(T from, T to)
            => GetAssignmentExpression(from, to);
        void IExpressionEntity<T>.HydrateEntity(T entity, ISqlFieldReader reader)
            => HydrateEntity(entity, reader);
        #endregion

        #region get inclusive insert expression
        protected abstract InsertExpressionSet<T> GetInclusiveInsertExpression(T entity);
        #endregion

        #region get inclusive assignment expression
        protected abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to);
        #endregion

        #region fill object
        protected abstract void HydrateEntity(T entity, ISqlFieldReader reader);
        #endregion
    }
}
