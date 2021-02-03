using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EntityExpression<T> : 
        EntityExpression, 
        Entity<T>
        where T : class, IDbEntity
    {
        #region constructors
        private EntityExpression() : base(typeof(T), null, null, null)
        { 
        
        }

        protected EntityExpression(string identifier, SchemaExpression schema, string alias)
            : base(typeof(T), identifier, schema, alias)
        {

        }
        #endregion

        #region interface
        SelectExpressionSet IEntityExpression<T>.BuildInclusiveSelectExpression()
            => GetInclusiveSelectExpression();        
        InsertExpressionSet<T> IEntityExpression<T>.BuildInclusiveInsertExpression(T entity)
            => GetInclusiveInsertExpression(entity);
        AssignmentExpressionSet IEntityExpression<T>.BuildAssignmentExpression(T target, T source)
            => GetAssignmentExpression(target, source);
        void IEntityExpression<T>.HydrateEntity(T entity, ISqlFieldReader reader)
            => HydrateEntity(entity, reader);
        #endregion

        #region methods
        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
        protected abstract InsertExpressionSet<T> GetInclusiveInsertExpression(T entity);
        protected abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to);
        protected abstract void HydrateEntity(T entity, ISqlFieldReader reader);
        #endregion
    }
}
