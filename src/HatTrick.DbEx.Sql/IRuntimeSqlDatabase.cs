using HatTrick.DbEx.Sql.Configuration;

namespace HatTrick.DbEx.Sql
{
    public interface IRuntimeSqlDatabase
    {
        RuntimeSqlDatabaseConfiguration Configuration { get; }
    }
}
