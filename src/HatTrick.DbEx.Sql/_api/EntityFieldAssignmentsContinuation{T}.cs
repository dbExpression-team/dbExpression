using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
 #pragma warning disable IDE1006 // Naming Styles
    public interface EntityFieldAssignmentsContinuation<TEntity>
           where TEntity : class, IDbEntity
 #pragma warning restore IDE1006 // Naming Styles   
    {
        /// <summary>
        /// Continue constructing a list of <see cref="EntityFieldAssignment"/>s.
        /// </summary>
        /// <param name="oldStateOfEntity">The source entity to use for property comparison to develop the list of <see cref="EntityFieldAssignment"/>s.  This is the entity that will be "overwritten".  
        /// </param>
        /// <returns><see cref="EntityFieldAssignmentsContinuation{TEntity}"/>, a fluent builder for constructing a sql UPDATE statement, with a list of "<see cref="HEntityFieldAssignment"/>" constructed from the comparison of the two entity params.</returns>
        EntityFieldAssignmentsContinuation<TEntity> From(TEntity oldStateOfEntity);
        /// <summary>
        /// Complete constructing a list of <see cref="EntityFieldAssignment"/>s.
        /// </summary>
        /// <param name="newStateOfEntity">If a property value differs from the property value in the entity provided in <see cref="EntityFieldAssignmentsContinuation{TEntity}.From(TEntity)"/>, an <see cref="EntityFieldAssignment"/> will be generated with the value set to the property value from <paramref name="newStateOfEntity"/>.
        /// </param>
        /// <returns><see cref="IEnumerable{EntityFieldAssignmentBuilder}"/>, the list of <see cref="EntityFieldAssignment"/>s constructed from the comparison of two entities.</returns>
        IEnumerable<EntityFieldAssignment> To(TEntity newStateOfEntity);
    }
}
