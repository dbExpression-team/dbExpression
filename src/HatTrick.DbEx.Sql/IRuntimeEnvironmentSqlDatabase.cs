namespace HatTrick.DbEx.Sql
{
    public interface IRuntimeEnvironmentSqlDatabase
    {
        IRuntimeSqlDatabase Database { get; }
        ISqlDatabaseMetadataProvider Metadata { get; }
    }
}
