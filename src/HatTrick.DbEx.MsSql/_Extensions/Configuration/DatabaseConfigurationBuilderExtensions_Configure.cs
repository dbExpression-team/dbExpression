using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
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

        #region 2005
        public static void AddMsSql2005Database<T>(this IRuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2005<T>(() => connectionString, runtimeConfiguration);

        public static void AddMsSql2005Database<T>(this IRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2005<T>(connectionStringFactory, runtimeConfiguration);

        private static void ConfigureMsSql2005<T>(Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();
            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);

            configBuilder.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

            configBuilder.SqlStatements.Assembly.StatementBuilder.Use<Assembler.v2005.MsSqlStatementBuilderFactory>();

            runtimeConfiguration?.Invoke(configBuilder);

            runtime.Database.UseConfiguration(config);
        }
        #endregion

        #region 2008
        public static void AddMsSql2008Database<T>(this IRuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2008<T>(() => connectionString, runtimeConfiguration);

        public static void AddMsSql2008Database<T>(this IRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2008<T>(connectionStringFactory, runtimeConfiguration);

        private static void ConfigureMsSql2008<T>(Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();
            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);

            configBuilder.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

            configBuilder.SqlStatements.Assembly.StatementBuilder.Use<Assembler.v2008.MsSqlStatementBuilderFactory>();

            runtimeConfiguration?.Invoke(configBuilder);

            runtime.Database.UseConfiguration(config);
        }
        #endregion

        #region 2012
        public static void AddMsSql2012Database<T>(this IRuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2012<T>(() => connectionString, runtimeConfiguration);

        public static void AddMsSql2012Database<T>(this IRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2012<T>(connectionStringFactory, runtimeConfiguration);

        private static void ConfigureMsSql2012<T>(Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();
            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);

            configBuilder.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

            configBuilder.SqlStatements.Assembly.StatementBuilder.Use<Assembler.v2012.MsSqlStatementBuilderFactory>();

            runtimeConfiguration?.Invoke(configBuilder);

            runtime.Database.UseConfiguration(config);
        }
        #endregion

        #region 2014
        public static void AddMsSql2014Database<T>(this IRuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2014<T>(() => connectionString, runtimeConfiguration);

        public static void AddMsSql2014Database<T>(this IRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2014<T>(connectionStringFactory, runtimeConfiguration);

        private static void ConfigureMsSql2014<T>(Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();
            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);

            configBuilder.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

            configBuilder.SqlStatements.Assembly.StatementBuilder.Use<Assembler.v2014.MsSqlStatementBuilderFactory>();

            runtimeConfiguration?.Invoke(configBuilder);

            runtime.Database.UseConfiguration(config);
        }
        #endregion

        #region 2016
        public static void AddMsSql2016Database<T>(this IRuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2016<T>(() => connectionString, runtimeConfiguration);

        public static void AddMsSql2016Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2016<T>(connectionStringFactory, runtimeConfiguration);

        private static void ConfigureMsSql2016<T>(Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();
            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);

            configBuilder.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

            configBuilder.SqlStatements.Assembly.StatementBuilder.Use<Assembler.v2016.MsSqlStatementBuilderFactory>();

            runtimeConfiguration?.Invoke(configBuilder);

            runtime.Database.UseConfiguration(config);
        }
        #endregion

        #region 2017
        public static void AddMsSql2017Database<T>(this IRuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2017<T>(() => connectionString, runtimeConfiguration);

        public static void AddMsSql2017Database<T>(this IRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2017<T>(connectionStringFactory, runtimeConfiguration);

        private static void ConfigureMsSql2017<T>(Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();
            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);

            configBuilder.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

            configBuilder.SqlStatements.Assembly.StatementBuilder.Use<Assembler.v2017.MsSqlStatementBuilderFactory>();

            runtimeConfiguration?.Invoke(configBuilder);

            runtime.Database.UseConfiguration(config);
        }
        #endregion

        #region 2019
        public static void AddMsSql2019Database<T>(this IRuntimeEnvironmentBuilder builder, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2019<T>(() => connectionString, runtimeConfiguration);

        public static void AddMsSql2019Database<T>(this IRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => ConfigureMsSql2019<T>(connectionStringFactory, runtimeConfiguration);

        private static void ConfigureMsSql2019<T>(Func<string> connectionStringFactory, Action<IRuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();
            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);

            configBuilder.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

            configBuilder.SqlStatements.Assembly.StatementBuilder.Use<Assembler.v2019.MsSqlStatementBuilderFactory>();

            runtimeConfiguration?.Invoke(configBuilder);

            runtime.Database.UseConfiguration(config);
        }
        #endregion

        private static void ConfigureMsSqlCommon(this IRuntimeSqlDatabaseConfigurationBuilder builder, ISqlDatabaseMetadataProvider metadata, Func<string> connectionStringFactory)
        {
            builder.SchemaMetadata.Use(metadata);

            builder.QueryExpressions.UseDefaultFactory();

            builder.Entities
                .Creation.UseDefaultFactory()
                .Mapping.UseDefaultFactory();

            builder.Conversions.UseDefaultFactory();

            builder.SqlStatements
                .Assembly
                    .StatementAppender.UseDefaultFactory()
                    .ElementAppender.Use<MsSqlExpressionElementAppenderFactory>()
                    .ParameterBuilder.Use(new MsSqlParameterBuilderFactory(new MsSqlTypeMapFactory(), () => (builder as IRuntimeSqlDatabaseConfigurationProvider).Configuration.ValueConverterFactory))
                    .ConfigureOutputSettings(
                        a => a.PrependCommaOnSelectClause = true
                    )
                .Execution
                    .Executor.UseDefaultFactory()
                    .Pipeline.UseDefaultFactory()
                    .Connection.Use(new MsSqlConnectionFactory(connectionStringFactory));
        }
    }
}
