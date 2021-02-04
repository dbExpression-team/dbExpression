using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlDatabaseMetadataProviderConfigurationBuilder
    {
        /// <summary>
        /// Use a custom metadata provider to provide information about the target database, specifically column data types, lengths, etc.
        /// </summary>
        void Use(ISqlDatabaseMetadataProvider provider);

        /// <summary>
        /// Use a custom metadata provider to provide information about the target database, specifically column data types, lengths, etc.
        /// </summary>
        void Use<TSqlDatabaseMetadataProvider>()
            where TSqlDatabaseMetadataProvider : class, ISqlDatabaseMetadataProvider, new();

        /// <summary>
        /// Use a custom metadata provider to provide information about the target database, specifically column data types, lengths, etc.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TSqlDatabaseMetadataProvider"/>.</param>
        void Use<TSqlDatabaseMetadataProvider>(Action<TSqlDatabaseMetadataProvider> configureProvider)
            where TSqlDatabaseMetadataProvider : class, ISqlDatabaseMetadataProvider, new();
    }
}
