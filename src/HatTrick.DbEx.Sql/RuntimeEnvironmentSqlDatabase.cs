namespace HatTrick.DbEx.Sql
{
    public abstract class RuntimeEnvironmentSqlDatabase : IRuntimeEnvironmentSqlDatabase
    {
        public IRuntimeSqlDatabase Database { get; private set; }
        public ISqlDatabaseMetadataProvider Metadata { get; private set; }

        protected RuntimeEnvironmentSqlDatabase(IRuntimeSqlDatabase database, ISqlDatabaseMetadataProvider metadata)
        {
            Database = database;
            Metadata = metadata;
        }
    }
}
