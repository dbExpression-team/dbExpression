using HatTrick.DbEx.Sql;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        public static DatabaseConfigurationBuilder<TDatabase> Configure<TDatabase>()
            where TDatabase : class, ISqlDatabaseRuntime
            => new();
    }
}
