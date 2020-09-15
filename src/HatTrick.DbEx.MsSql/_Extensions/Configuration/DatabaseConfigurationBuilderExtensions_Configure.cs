using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
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

        //TO_DISCUSS: Should metadata include server info so we can infer compatibility version, or specifically specify based on method name (i.e. AddMsSql2014Database)
        #pragma warning disable IDE0060
        private static void ConfigureMsSqlCommon(this RuntimeSqlDatabaseConfigurationBuilder builder, ISqlDatabaseMetadataProvider metadata, Func<string> connectionStringFactory)
        {
            builder.UseDatabaseMetadata(metadata);
            builder.UseConnectionFactory(new MsSqlConnectionFactory(connectionStringFactory));
            builder.UseQueryExpressionFactory<QueryExpressionFactory>();
            builder.UseAppenderFactory<AppenderFactory>();
            builder.UseEntityFactory<EntityFactory>();
            builder.UseValueConverterFactory<ValueConverterFactory>();
            builder.UseMapperFactory<MapperFactory>();
            builder.UseExecutionPipelineFactory<ExecutionPipelineFactory>();
            builder.UseParameterBuilderFactory(new MsSqlParameterBuilderFactory(new MsSqlTypeMaps()));

            var appenderFactory = new MsSqlAssemblyPartAppenderFactory();
            appenderFactory.RegisterDefaultPartAppenders();
            builder.UseAssemblyPartAppenderFactory(appenderFactory);

            var executor = new SqlStatementExecutorFactory();
            executor.RegisterDefaultExecutors();
            builder.UseSqlStatementExecutorFactory(executor);
        }

        #region 2005
        public static void AddMsSql2005Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2005<T>(() => connectionString, null, runtimeConfiguration, fieldConfiguration);

        public static void AddMsSql2005Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2005<T>(connectionStringFactory, null, runtimeConfiguration, fieldConfiguration);

        private static void ConfigureMsSql2005<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2005.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                init.UseStatementBuilderFactory(factory);

                runtimeConfiguration?.Invoke(init);

                fieldConfiguration?.Invoke(new FieldExpressionConfigurationBuilder((init as IRuntimeSqlDatabaseConfigurationBuilder).Configuration));
            });
        }
        #endregion

        #region 2008
        public static void AddMsSql2008Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2008<T>(() => connectionString, null, runtimeConfiguration, fieldConfiguration);

        public static void AddMsSql2008Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2008<T>(connectionStringFactory, null, runtimeConfiguration, fieldConfiguration);

        private static void ConfigureMsSql2008<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2008.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                init.UseStatementBuilderFactory(factory);

                runtimeConfiguration?.Invoke(init);

                fieldConfiguration?.Invoke(new FieldExpressionConfigurationBuilder((init as IRuntimeSqlDatabaseConfigurationBuilder).Configuration));
            });
        }
        #endregion

        #region 2012
        public static void AddMsSql2012Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2012<T>(() => connectionString, null, runtimeConfiguration, fieldConfiguration);

        public static void AddMsSql2012Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2012<T>(connectionStringFactory, null, runtimeConfiguration, fieldConfiguration);

        private static void ConfigureMsSql2012<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2012.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                init.UseStatementBuilderFactory(factory);

                runtimeConfiguration?.Invoke(init);

                fieldConfiguration?.Invoke(new FieldExpressionConfigurationBuilder((init as IRuntimeSqlDatabaseConfigurationBuilder).Configuration));
            });
        }
        #endregion

        #region 2014
        public static void AddMsSql2014Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2014<T>(() => connectionString, null, runtimeConfiguration, fieldConfiguration);

        public static void AddMsSql2014Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2014<T>(connectionStringFactory, null, runtimeConfiguration, fieldConfiguration);

        private static void ConfigureMsSql2014<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2014.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                init.UseStatementBuilderFactory(factory);

                runtimeConfiguration?.Invoke(init);

                fieldConfiguration?.Invoke(new FieldExpressionConfigurationBuilder((init as IRuntimeSqlDatabaseConfigurationBuilder).Configuration));
            });
        }
        #endregion

        #region 2016
        public static void AddMsSql2016Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2016<T>(() => connectionString, null, runtimeConfiguration, fieldConfiguration);

        public static void AddMsSql2016Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2016<T>(connectionStringFactory, null, runtimeConfiguration, fieldConfiguration);

        private static void ConfigureMsSql2016<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2016.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                init.UseStatementBuilderFactory(factory);

                runtimeConfiguration?.Invoke(init);

                fieldConfiguration?.Invoke(new FieldExpressionConfigurationBuilder((init as IRuntimeSqlDatabaseConfigurationBuilder).Configuration));
            });
        }
        #endregion

        #region 2017
        public static void AddMsSql2017Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2017<T>(() => connectionString, null, runtimeConfiguration, fieldConfiguration);

        public static void AddMsSql2017Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2017<T>(connectionStringFactory, null, runtimeConfiguration, fieldConfiguration);

        private static void ConfigureMsSql2017<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2017.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                init.UseStatementBuilderFactory(factory);

                runtimeConfiguration?.Invoke(init);

                fieldConfiguration?.Invoke(new FieldExpressionConfigurationBuilder((init as IRuntimeSqlDatabaseConfigurationBuilder).Configuration));
            });
        }
        #endregion

        #region 2019
        public static void AddMsSql2019Database<T>(this RuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2019<T>(() => connectionString, null, runtimeConfiguration, fieldConfiguration);

        public static void AddMsSql2019Database<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
            => builder.ConfigureMsSql2019<T>(connectionStringFactory, null, runtimeConfiguration, fieldConfiguration);

        private static void ConfigureMsSql2019<T>(this RuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeSqlDatabaseConfigurationBuilder> runtimeConfiguration = null, Action<IFieldExpressionConfigurationBuilder> fieldConfiguration = null)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            var runtime = new T();
            (builder as IRuntimeEnvironmentBuilder).ConfigureSqlDatabase(runtime.Database, init =>
            {
                init.ConfigureMsSqlCommon(runtime.Metadata, connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2019.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                init.UseStatementBuilderFactory(factory);

                runtimeConfiguration?.Invoke(init);

                fieldConfiguration?.Invoke(new FieldExpressionConfigurationBuilder((init as IRuntimeSqlDatabaseConfigurationBuilder).Configuration));
            });
        }
        #endregion
    }
}
