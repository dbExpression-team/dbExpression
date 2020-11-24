using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlDeleteEntitiesBuilder : DeleteQueryExpressionBuilder
    {
        #region constructors
        public MsSqlDeleteEntitiesBuilder(RuntimeSqlDatabaseConfiguration configuration, DeleteQueryExpression expression)
            : base(configuration, expression)
        {

        }
        #endregion

        #region methods
        protected override DeleteEntitiesContinuation<TEntity> CreateTypedBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<TEntity> entity)
            => new MsSqlDeleteEntitiesDeleteQueryExpressionBuilder<TEntity>(configuration, expression, entity);
        #endregion
    }
}