using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlDeleteEntitiesDeleteQueryExpressionBuilder<TEntity> : DeleteEntitiesDeleteQueryExpressionBuilder<TEntity>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public MsSqlDeleteEntitiesDeleteQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<TEntity> entity)
            : base(configuration, expression, entity)
        {

        }
        #endregion

        #region methods
        protected override DeleteEntitiesContinuation<U> CreateTypedBuilder<U>(RuntimeSqlDatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<U> entity)
            => new MsSqlDeleteEntitiesDeleteQueryExpressionBuilder<U>(configuration, expression, entity);
        #endregion
    }
}
