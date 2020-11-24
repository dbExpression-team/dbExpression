using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlSelectEntitiesSelectQueryExpressionBuilder<TEntity> : SelectEntitiesSelectQueryExpressionBuilder<TEntity>
        where TEntity : class, IDbEntity
    {
        public MsSqlSelectEntitiesSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) 
            : base(config, expression)
        {

        }
    }
}
