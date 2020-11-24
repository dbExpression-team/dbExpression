using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlSelectEntityQueryExpressionBuilder<TEntity> : SelectEntityQueryExpressionBuilder<TEntity>
        where TEntity : class, IDbEntity
    {
        public MsSqlSelectEntityQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) 
            : base(config, expression)
        {

        }
    }
}
