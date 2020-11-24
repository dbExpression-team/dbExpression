using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class InsertQueryExpressionBuilder<TEntity> : QueryExpressionBuilder,
        InsertEntity<TEntity>,
        InsertEntities<TEntity>,
        InsertEntityTermination<TEntity>,
        InsertEntitiesTermination<TEntity>
        where TEntity : class, IDbEntity
    {
        #region internals
        private readonly InsertQueryExpression expression;
        private readonly IEnumerable<TEntity> instances;
        #endregion

        #region constructors
        protected InsertQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<TEntity> instances, InsertQueryExpression expression) : base(configuration, expression)
        {
            this.expression = expression;
            this.instances = instances;
        }
        #endregion

        #region methods
        InsertEntityTermination<TEntity> InsertEntity<TEntity>.Into<U>(U entity)
        {
            Into(entity);
            return this;
        }

        InsertEntitiesTermination<TEntity> InsertEntities<TEntity>.Into<U>(U entity)
        {
            Into(entity);
            return this;
        }

        private void Into(EntityExpression<TEntity> entity)
        {
            var i = 0;
            var insertEntity = entity as IExpressionEntity<TEntity> ?? throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression<TEntity>)}.");
            expression.BaseEntity = entity;
            expression.Inserts = instances.ToDictionary(x => i++, x => new InsertExpressionSet(x, insertEntity.BuildInclusiveInsertExpression(x).Expressions));
        }
        #endregion
    }
}
