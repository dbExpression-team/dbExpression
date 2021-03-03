using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlDatabaseMetadataProviderConfigurationBuilder : ISqlDatabaseMetadataProviderConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public SqlDatabaseMetadataProviderConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public void Use(ISqlDatabaseMetadataProvider provider)
            => configuration.MetadataProvider = provider ?? throw new ArgumentNullException(nameof(provider));

        public void Use<TSqlDatabaseMetadataProvider>()
            where TSqlDatabaseMetadataProvider : class, ISqlDatabaseMetadataProvider, new()
            => Use<TSqlDatabaseMetadataProvider>(null);

        public void Use<TSqlDatabaseMetadataProvider>(Action<TSqlDatabaseMetadataProvider> configureProvider)
            where TSqlDatabaseMetadataProvider : class, ISqlDatabaseMetadataProvider, new()
        {
            if (!(configuration.MetadataProvider is TSqlDatabaseMetadataProvider))
                configuration.MetadataProvider = new TSqlDatabaseMetadataProvider();
            configureProvider?.Invoke(configuration.MetadataProvider as TSqlDatabaseMetadataProvider);
        }
        #endregion
    }
}
