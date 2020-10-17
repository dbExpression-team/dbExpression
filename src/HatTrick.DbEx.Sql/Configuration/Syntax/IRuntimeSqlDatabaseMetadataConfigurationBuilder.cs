namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IRuntimeSqlDatabaseMetadataConfigurationBuilder
    {
        void UseThisToGetSqlDatabaseMetadata(ISqlDatabaseMetadataProvider meta);

        void UseThisToGetSqlDatabaseMetadata<T>()
            where T : class, ISqlDatabaseMetadataProvider, new();
    }
}
