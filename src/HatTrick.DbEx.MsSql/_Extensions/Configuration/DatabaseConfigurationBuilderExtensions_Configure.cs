using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Mapper;
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
        private static void ConfigureMsSqlCommon<T>(this RuntimeDatabaseConfigurationBuilder builder, Func<string> connectionStringFactory)
            where T : class, IRuntimeSqlDatabase, new()
        {
            builder.UseAppenderFactory<AppenderFactory>();
            builder.UseEntityFactory<EntityFactory>();
            builder.UseMapperFactory<MapperFactory>();

            //configure sql statement executor factory
            var executor = new MsSqlExecutorFactory();
            executor.RegisterDefaultExecutors();
            builder.UseExecutorFactory(executor);

            //configure the parameter builder factory
            builder.UseParameterBuilderFactory<MsSqlParameterBuilderFactory>();

            //configure the connection factory
            builder.UseConnectionFactory(new MsSqlConnectionFactory(connectionStringFactory));

            //use identity insert strategy for MsSql
            builder.UseIdentityInsertStrategy();
        }

        #region 2005
        public static void AddMsSql2005Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2005<T>(() => connectionString, null, configure);

        public static void AddMsSql2005Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2005<T>(connectionStringFactory, null, configure);

        private static void ConfigureMsSql2005<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            (builder as IDbExpressionRuntimeEnvironmentBuilder).ConfigureSqlDatabase(new T(), init =>
            {
                init.ConfigureMsSqlCommon<T>(connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2005.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                factory.RegisterDefaultPartAppenders();
                init.UseStatementBuilderFactory(factory);

                configure?.Invoke(init);
            });
        }
        #endregion

        #region 2008
        public static void AddMsSql2008Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2008<T>(() => connectionString, null, configure);

        public static void AddMsSql2008Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2008<T>(connectionStringFactory, null, configure);

        private static void ConfigureMsSql2008<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            (builder as IDbExpressionRuntimeEnvironmentBuilder).ConfigureSqlDatabase(new T(), init =>
            {
                init.ConfigureMsSqlCommon<T>(connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2008.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                factory.RegisterDefaultPartAppenders();
                init.UseStatementBuilderFactory(factory);

                configure?.Invoke(init);
            });
        }
        #endregion

        #region 2012
        public static void AddMsSql2012Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2012<T>(() => connectionString, null, configure);

        public static void AddMsSql2012Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2012<T>(connectionStringFactory, null, configure);

        private static void ConfigureMsSql2012<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            (builder as IDbExpressionRuntimeEnvironmentBuilder).ConfigureSqlDatabase(new T(), init =>
            {
                init.ConfigureMsSqlCommon<T>(connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2012.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                factory.RegisterDefaultPartAppenders();
                init.UseStatementBuilderFactory(factory);

                configure?.Invoke(init);
            });
        }
        #endregion

        #region 2014
        public static void AddMsSql2014Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2014<T>(() => connectionString, null, configure);

        public static void AddMsSql2014Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2014<T>(connectionStringFactory, null, configure);

        private static void ConfigureMsSql2014<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            (builder as IDbExpressionRuntimeEnvironmentBuilder).ConfigureSqlDatabase(new T(), init =>
            {
                init.ConfigureMsSqlCommon<T>(connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2014.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                factory.RegisterDefaultPartAppenders();
                init.UseStatementBuilderFactory(factory);

                configure?.Invoke(init);
            });
        }
        #endregion

        #region 2016
        public static void AddMsSql2016Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2016<T>(() => connectionString, null, configure);

        public static void AddMsSql2016Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2016<T>(connectionStringFactory, null, configure);

        private static void ConfigureMsSql2016<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            (builder as IDbExpressionRuntimeEnvironmentBuilder).ConfigureSqlDatabase(new T(), init =>
            {
                init.ConfigureMsSqlCommon<T>(connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2016.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                factory.RegisterDefaultPartAppenders();
                init.UseStatementBuilderFactory(factory);

                configure?.Invoke(init);
            });
        }
        #endregion

        #region 2017
        public static void AddMsSql2017Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2017<T>(new T(), () => connectionString, null, configure);

        public static void AddMsSql2017Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2017<T>(new T(), connectionStringFactory, null, configure);

        private static void ConfigureMsSql2017<T>(this DbExpressionRuntimeEnvironmentBuilder builder, IRuntimeSqlDatabase database, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            (builder as IDbExpressionRuntimeEnvironmentBuilder).ConfigureSqlDatabase(new T(), init =>
            {
                init.ConfigureMsSqlCommon<T>(connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2017.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                factory.RegisterDefaultPartAppenders();
                init.UseStatementBuilderFactory(factory);

                configure?.Invoke(init);
            });
        }
        #endregion

        #region 2019
        public static void AddMsSql2019Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, string connectionString, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2019<T>(() => connectionString, null, configure);

        public static void AddMsSql2019Database<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
            => builder.ConfigureMsSql2019<T>(connectionStringFactory, null, configure);

        private static void ConfigureMsSql2019<T>(this DbExpressionRuntimeEnvironmentBuilder builder, Func<string> connectionStringFactory, string metadataKey = null, Action<RuntimeDatabaseConfigurationBuilder> configure = null)
            where T : class, IRuntimeSqlDatabase, new()
        {
            EnsureValidConnectionString(connectionStringFactory);
            (builder as IDbExpressionRuntimeEnvironmentBuilder).ConfigureSqlDatabase(new T(), init =>
            {
                init.ConfigureMsSqlCommon<T>(connectionStringFactory);

                //configure sql statement builder factory
                var factory = new Assembler.v2019.MsSqlStatementBuilderFactory();
                factory.RegisterDefaultStatementAssemblers();
                factory.RegisterDefaultPartAppenders();
                init.UseStatementBuilderFactory(factory);

                configure?.Invoke(init);
            });
        }
        #endregion
    }
}
