using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlUpdateQueryExpressionBuilder : UpdateQueryExpressionBuilder
    {
        #region constructors
        public MsSqlUpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression)
            : base(configuration, expression)
        {

        }
        #endregion

        #region methods
        protected override UpdateEntitiesContinuation<TEntity> CreateTypedBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<TEntity> entity)
            => new UpdateEntitiesUpdateQueryExpressionBuilder<TEntity>(configuration, expression, entity);
        #endregion
    }
}