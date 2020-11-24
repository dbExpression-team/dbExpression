using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlSelectValueSelectQueryExpressionBuilder<TValue> : SelectValueSelectQueryExpressionBuilder<TValue>
    {
        public MsSqlSelectValueSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) 
            : base(config, expression)
        {

        }
    }
}
