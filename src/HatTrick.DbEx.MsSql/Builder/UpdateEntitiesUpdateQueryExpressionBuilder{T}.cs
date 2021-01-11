using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class UpdateEntitiesUpdateQueryExpressionBuilder<TEntity> : Sql.Builder.UpdateEntitiesUpdateQueryExpressionBuilder<TEntity>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public UpdateEntitiesUpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<TEntity> entity)
            : base(configuration, expression, entity)
        {

        }
        #endregion

        #region methods
        protected override UpdateEntitiesContinuation<U> CreateTypedBuilder<U>(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<U> entity)
            => new UpdateEntitiesUpdateQueryExpressionBuilder<U>(configuration, expression, entity);
        #endregion
    }
}
