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
        private EntityExpression() : base(null, null, typeof(T), null, null)
        { 
        
        }

        protected EntityExpression(string identifier, string name, SchemaExpression schema, string alias)
            : base(identifier, name, typeof(T), schema, alias)
        {

        }
        #endregion

        #region interface
        SelectExpressionSet IEntityExpression<T>.BuildInclusiveSelectExpression()
            => GetInclusiveSelectExpression();
        SelectExpressionSet IEntityExpression<T>.BuildInclusiveSelectExpression(Func<string, string> alias)
            => GetInclusiveSelectExpression(alias);
        InsertExpressionSet<T> IEntityExpression<T>.BuildInclusiveInsertExpression(T entity)
            => GetInclusiveInsertExpression(entity);
        AssignmentExpressionSet IEntityExpression<T>.BuildAssignmentExpression(T target, T source)
            => GetAssignmentExpression(target, source);
        void IEntityExpression<T>.HydrateEntity(ISqlFieldReader reader, T entity)
            => HydrateEntity(reader, entity);
        #endregion

        #region methods
        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
        protected abstract SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias);
        protected abstract InsertExpressionSet<T> GetInclusiveInsertExpression(T entity);
        protected abstract AssignmentExpressionSet GetAssignmentExpression(T from, T to);
        protected abstract void HydrateEntity(ISqlFieldReader reader, T entity);
        #endregion
    }
}
