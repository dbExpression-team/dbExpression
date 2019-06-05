﻿using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace HatTrick.DbEx.MsSql.Extensions.Configuration
{
    public static class DbExpressionConfigurationExtensions
    {
        private static DatabaseConfigurationBuilder CreateDatabaseConfigurationBuilder(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider metaProvider, Func<ConnectionStringSettings> connectionStringSettingsFactory, string logicalName)
        {
            if (connectionStringSettingsFactory == null)
                throw new DbExpressionConfigurationException($"{nameof(connectionStringSettingsFactory)} cannot be null");

            var connectionString = connectionStringSettingsFactory()?.ConnectionString;
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new DbExpressionConfigurationException($"The connection string settings factory did not provide a value for a connection string");

            SqlConnectionStringBuilder connBuilder;
            try
            {
                connBuilder = new SqlConnectionStringBuilder(connectionString);
            }
            catch (FormatException e)
            {
                throw new DbExpressionConfigurationException($"The connection string is not in a valid format", e);
            }
            catch (ArgumentException e)
            {
                throw new DbExpressionConfigurationException($"The connection string appears to have an issue", e);
            }

            var database = new DatabaseConfiguration(metaProvider);
            database.Metadata.Name = logicalName ?? connBuilder.InitialCatalog;            
            builder.AddDatabase(logicalName ?? database.Metadata.Name, database, connectionStringSettingsFactory);

            database.ExecutionPipelineFactory = new ExecutionPipelineFactory(builder.Configuration, database);

            return new DatabaseConfigurationBuilder(database);
        }

        //TO_DISCUSS: Should metadata include server info so we can infer compatibility version, or specifically specify based on method name (i.e. AddMsSql2014Database)
        #pragma warning disable IDE0060
        private static void ConfigureMsSqlCommon(this DbExpressionConfigurationBuilder builder, DatabaseConfigurationBuilder config)
        {
            config.UseDefaultAppenderFactory();
            config.UseDefaultEntityFactory();
            config.UseDefaultMapperFactory();

            //configure sql statement executor factory
            var executor = new MsSqlExecutorFactory();
            executor.RegisterDefaultExecutors();
            config.UseExecutorFactory(executor);

            //configure the parameter builder factory
            config.UseParameterBuilderFactory<MsSqlParameterBuilderFactory>();

            //configure the connection factory
            config.UseConnectionFactory<MsSqlConnectionFactory>();

            //use identity insert strategy for MsSql
            config.UseIdentityInsertStrategy();
        }

        #region 2014
        public static void AddMsSql2014Database<T>(this DbExpressionConfigurationBuilder builder, ConnectionStringSettings connectionStringSettings, Action<DatabaseConfigurationBuilder> configure = null)
            where T : class, IDatabaseMetadataProvider, new()
            => builder.ConfigureMsSql2014(new T(), () => connectionStringSettings, null, configure);

        public static void AddMsSql2014Database<T>(this DbExpressionConfigurationBuilder builder, ConnectionStringSettings connectionStringSettings, string logicalName, Action<DatabaseConfigurationBuilder> configure = null)
            where T : class, IDatabaseMetadataProvider, new()
            => builder.ConfigureMsSql2014(new T(), () => connectionStringSettings, logicalName, configure);

        public static void AddMsSql2014Database(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider databaseMetadataProvider, ConnectionStringSettings connectionStringSettings, string logicalName = null, Action<DatabaseConfigurationBuilder> configure = null)
            => builder.ConfigureMsSql2014(databaseMetadataProvider, () => connectionStringSettings, logicalName, configure);

        public static void AddMsSql2014Database(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider databaseMetadataProvider, Func<ConnectionStringSettings> connectionStringSettingsFactory, string logicalName = null, Action<DatabaseConfigurationBuilder> configure = null)
            => builder.ConfigureMsSql2014(databaseMetadataProvider, connectionStringSettingsFactory, logicalName, configure);

        public static void AddMsSql2014Database(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider databaseMetadataProvider, ConnectionStringSettings connectionStringSettings, Action<DatabaseConfigurationBuilder> configure = null)
            => builder.ConfigureMsSql2014(databaseMetadataProvider, () => connectionStringSettings, null, configure);

        public static void AddMsSql2014Database(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider databaseMetadataProvider, Func<ConnectionStringSettings> connectionStringSettingsFactory, Action<DatabaseConfigurationBuilder> configure = null)
            => builder.ConfigureMsSql2014(databaseMetadataProvider, connectionStringSettingsFactory, null, configure);

        private static void ConfigureMsSql2014(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider metaProvider, Func<ConnectionStringSettings> connectionStringSettingsFactory, string logicalName = null, Action<DatabaseConfigurationBuilder> configure = null)
        {
            var config = builder.CreateDatabaseConfigurationBuilder(metaProvider, connectionStringSettingsFactory, logicalName);
            builder.ConfigureMsSqlCommon(config);

            //configure sql statement builder factory
            var factory = new Assembler.v2014.MsSqlStatementBuilderFactory();
            factory.RegisterDefaultAssemblers();
            factory.RegisterDefaultPartAppenders();
            factory.RegisterDefaultValueFormatters();
            config.UseStatementBuilderFactory(factory);

            configure?.Invoke(config);
        }
        #endregion

        #region 2012
        public static void AddMsSql2012Database<T>(this DbExpressionConfigurationBuilder builder, ConnectionStringSettings connectionStringSettings, Action<DatabaseConfigurationBuilder> configure = null)
            where T : class, IDatabaseMetadataProvider, new()
            => builder.ConfigureMsSql2012(new T(), () => connectionStringSettings, null, configure);

        public static void AddMsSql2012Database<T>(this DbExpressionConfigurationBuilder builder, ConnectionStringSettings connectionStringSettings, string logicalName, Action<DatabaseConfigurationBuilder> configure = null)
            where T : class, IDatabaseMetadataProvider, new()
            => builder.ConfigureMsSql2012(new T(), () => connectionStringSettings, logicalName, configure);

        public static void AddMsSql2012Database(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider databaseMetadataProvider, ConnectionStringSettings connectionStringSettings, string logicalName = null, Action<DatabaseConfigurationBuilder> configure = null)
            => builder.ConfigureMsSql2012(databaseMetadataProvider, () => connectionStringSettings, logicalName, configure);

        public static void AddMsSql2012Database(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider databaseMetadataProvider, Func<ConnectionStringSettings> connectionStringSettingsFactory, string logicalName = null, Action<DatabaseConfigurationBuilder> configure = null)
            => builder.ConfigureMsSql2012(databaseMetadataProvider, connectionStringSettingsFactory, logicalName, configure);

        public static void AddMsSql2012Database(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider databaseMetadataProvider, ConnectionStringSettings connectionStringSettings, Action<DatabaseConfigurationBuilder> configure = null)
            => builder.ConfigureMsSql2012(databaseMetadataProvider, () => connectionStringSettings, null, configure);

        public static void AddMsSql2012Database(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider databaseMetadataProvider, Func<ConnectionStringSettings> connectionStringSettingsFactory, Action<DatabaseConfigurationBuilder> configure = null)
            => builder.ConfigureMsSql2012(databaseMetadataProvider, connectionStringSettingsFactory, null, configure);

        private static void ConfigureMsSql2012(this DbExpressionConfigurationBuilder builder, IDatabaseMetadataProvider metaProvider, Func<ConnectionStringSettings> connectionStringSettingsFactory, string logicalName = null, Action<DatabaseConfigurationBuilder> configure = null)
        {
            var config = builder.CreateDatabaseConfigurationBuilder(metaProvider, connectionStringSettingsFactory, logicalName);
            builder.ConfigureMsSqlCommon(config);

            //configure sql statement builder factory
            var factory = new Assembler.v2012.MsSqlStatementBuilderFactory();
            factory.RegisterDefaultAssemblers();
            factory.RegisterDefaultPartAppenders();
            factory.RegisterDefaultValueFormatters();
            config.UseStatementBuilderFactory(factory);

            configure?.Invoke(config);
        }
        #endregion
    }
}
