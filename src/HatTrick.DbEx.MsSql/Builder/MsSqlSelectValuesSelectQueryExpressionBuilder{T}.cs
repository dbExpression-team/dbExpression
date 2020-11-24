using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlSelectValuesSelectQueryExpressionBuilder<TValue> : SelectValuesSelectQueryExpressionBuilder<TValue>
    {
        public MsSqlSelectValuesSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) 
            : base(config, expression)
        {

        }
    }
}
