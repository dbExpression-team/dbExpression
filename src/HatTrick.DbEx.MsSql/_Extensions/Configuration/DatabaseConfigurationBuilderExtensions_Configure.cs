using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Data.SqlClient;

namespace HatTrick.DbEx.MsSql.Configuration
{
    public static partial class DatabaseConfigurationBuilderExtensions
    {
        private static void EnsureValidConnectionString(Func<string> connectionStringFactory)
        {
            if (connectionStringFactory is null)
                throw new DbExpressionConfigurationException($"{nameof(connectionStringFactory)} cannot be null");

            var connectionString = connectionStringFactory();
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
        }

        #pragma warning disable IDE0060
        private static void ConfigureMsSqlCommon(this IRuntimeSqlDatabaseConfigurationBuilder builder, ISqlDatabaseMetadataProvider metadata, Func<string> connectionStringFactory)
        {
            var config = (builder as IRuntimeSqlDatabaseConfigurationProvider).Configuration;

            builder.ForSqlSchemaMetadata
                .UseThisToGetSqlDatabaseMetadata(metadata);

            builder.WhenExecutingSqlStatements
                .UseThisToCreateNewSqlConnections(new MsSqlConnectionFactory(connectionStringFactory));

            builder.WhenCreatingQueryExpressions
                .UseThisToCreateNewQueryExpressions<QueryExpressionFactory>();

            builder.ForCreatingEntities
                .UseThisToInstantiateNewEntities<EntityFactory>();

            builder.WhenMappingData
                .UseThisToCreateNewValueConverters<ValueConverterFactory>()
                .UseThisToCreateNewEntityAndDynamicMappers<MapperFactory>();

            builder.WhenAssemblingSqlStatements
                .UseThisToCreateAppendersForWritingSqlStatements<MsSqlExpressionElementAppenderFactory>()
                .UseThisToCreateWritersForCreatingSqlStatements<AppenderFactory>()
                .UseThisToCreateSqlParameters(new MsSqlParameterBuilderFactory(new MsSqlTypeMapFactory(), () => config.ValueConverterFactory));

            builder.WhenExecutingSqlStatements
                .UseThisToCreateNewSqlStatementExecutors<SqlStatementExecutorFactory>()
                .UseThisToCreateNewExecutionPipelines<ExecutionPipelineFactory>();
        }

        #region 2005
        public static void AddMsSql2005Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2005<T>(() => connectionString, null, runtimeConfiguration);

        public static void AddMsSql2005Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2005<T>(connectionStringFactory, null, runtimeConfiguration);

        private static void ConfigureMsSql2005<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                init.WhenAssemblingSqlStatements
                    .UseThisToCreateNewSqlStatementBuilders<Assembler.v2005.MsSqlStatementBuilderFactory>();

                runtimeConfiguration?.Invoke(init);
            });
        }
        #endregion

        #region 2008
        public static void AddMsSql2008Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2008<T>(() => connectionString, null, runtimeConfiguration);

        public static void AddMsSql2008Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2008<T>(connectionStringFactory, null, runtimeConfiguration);

        private static void ConfigureMsSql2008<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                init.WhenAssemblingSqlStatements
                    .UseThisToCreateNewSqlStatementBuilders<Assembler.v2008.MsSqlStatementBuilderFactory>();

                runtimeConfiguration?.Invoke(init);
            });
        }
        #endregion

        #region 2012
        public static void AddMsSql2012Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2012<T>(() => connectionString, null, runtimeConfiguration);

        public static void AddMsSql2012Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2012<T>(connectionStringFactory, null, runtimeConfiguration);

        private static void ConfigureMsSql2012<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                init.WhenAssemblingSqlStatements
                    .UseThisToCreateNewSqlStatementBuilders<Assembler.v2012.MsSqlStatementBuilderFactory>();

                runtimeConfiguration?.Invoke(init);
            });
        }
        #endregion

        #region 2014
        public static void AddMsSql2014Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2014<T>(() => connectionString, null, runtimeConfiguration);

        public static void AddMsSql2014Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2014<T>(connectionStringFactory, null, runtimeConfiguration);

        private static void ConfigureMsSql2014<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                init.WhenAssemblingSqlStatements
                    .UseThisToCreateNewSqlStatementBuilders<Assembler.v2014.MsSqlStatementBuilderFactory>();

                runtimeConfiguration?.Invoke(init);
            });
        }
        #endregion

        #region 2016
        public static void AddMsSql2016Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2016<T>(() => connectionString, null, runtimeConfiguration);

        public static void AddMsSql2016Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2016<T>(connectionStringFactory, null, runtimeConfiguration);

        private static void ConfigureMsSql2016<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                init.WhenAssemblingSqlStatements
                    .UseThisToCreateNewSqlStatementBuilders<Assembler.v2016.MsSqlStatementBuilderFactory>();

                runtimeConfiguration?.Invoke(init);
            });
        }
        #endregion

        #region 2017
        public static void AddMsSql2017Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2017<T>(() => connectionString, null, runtimeConfiguration);

        public static void AddMsSql2017Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2017<T>(connectionStringFactory, null, runtimeConfiguration);

        private static void ConfigureMsSql2017<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                init.WhenAssemblingSqlStatements
                    .UseThisToCreateNewSqlStatementBuilders<Assembler.v2017.MsSqlStatementBuilderFactory>();

                runtimeConfiguration?.Invoke(init);
            });
        }
        #endregion

        #region 2019
        public static void AddMsSql2019Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2019<T>(() => connectionString, null, runtimeConfiguration);

        public static void AddMsSql2019Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2019<T>(connectionStringFactory, null, runtimeConfiguration);

        private static void ConfigureMsSql2019<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                init.WhenAssemblingSqlStatements
                    .UseThisToCreateNewSqlStatementBuilders<Assembler.v2019.MsSqlStatementBuilderFactory>();

                runtimeConfiguration?.Invoke(init);
            });
        }
        #endregion
    }
}
