using HatTrick.DbEx.Sql.Configuration;

namespace HatTrick.DbEx.Sql
{
    public interface IRuntimeSqlDatabase
    {
        DatabaseConfiguration Configuration { get; }
        ISqlDatabaseMetadata Metadata { get; }
        void UseConfiguration(DatabaseConfiguration configuration);
    }
}
