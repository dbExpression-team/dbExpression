using HatTrick.DbEx.Sql.Configuration.Syntax;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseMetadataConfigurationBuilder : IRuntimeSqlDatabaseMetadataConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public RuntimeSqlDatabaseMetadataConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public void UseThisToGetSqlDatabaseMetadata(ISqlDatabaseMetadataProvider meta)
        {
            configuration.MetadataProvider = meta;
        }

        public void UseThisToGetSqlDatabaseMetadata<T>()
            where T : class, ISqlDatabaseMetadataProvider, new()
        {
            configuration.MetadataProvider = new T();
        }
        #endregion
    }
}
