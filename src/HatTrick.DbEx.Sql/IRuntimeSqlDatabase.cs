using HatTrick.DbEx.Sql.Configuration;

namespace HatTrick.DbEx.Sql
{
    public interface IRuntimeSqlDatabase
    {
        void UseConfiguration(RuntimeSqlDatabaseConfiguration configuration);
    }
}
