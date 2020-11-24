using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public interface ITerminationExpressionBuilder :
        IExpressionBuilder,
        IQueryExpressionProvider,
        IRuntimeSqlDatabaseConfigurationProvider
    {
    }
}
