using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class EntityComparisonAssignmentBuilder<TEntity> : EntityFieldAssignmentsContinuation<TEntity>
            where TEntity : class, IDbEntity
    {
        #region internals
        private readonly Entity<TEntity> entity;
        private TEntity oldStateOfEntity;
        #endregion

        #region constructors
        public EntityComparisonAssignmentBuilder(Entity<TEntity> entity)
        {
            this.entity = entity ?? throw new ArgumentNullException($"{nameof(entity)} is required.");
        }
        #endregion

        #region methods
        ///<inheritdoc/>
        EntityFieldAssignmentsContinuation<TEntity> EntityFieldAssignmentsContinuation<TEntity>.From(TEntity oldStateOfEntity)
        {
            this.oldStateOfEntity = oldStateOfEntity ?? throw new ArgumentNullException($"{nameof(oldStateOfEntity)} is required.");
            return this;
        }

        ///<inheritdoc/>
        IEnumerable<EntityFieldAssignment> EntityFieldAssignmentsContinuation<TEntity>.To(TEntity newStateOfEntity)
            => entity.BuildAssignmentExpression(oldStateOfEntity, newStateOfEntity ?? throw new ArgumentNullException($"{nameof(newStateOfEntity)} is required.")).Expressions.Cast<EntityFieldAssignment>();
        #endregion
    }
}
