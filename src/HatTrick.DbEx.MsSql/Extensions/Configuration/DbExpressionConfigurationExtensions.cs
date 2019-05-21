using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.MsSql.Extensions.Configuration
{
    public static class DbExpressionConfigurationExtensions
    {
        private static DatabaseConfigurationBuilder CreateDatabaseConfigurationBuilder<T>(this DbExpressionConfigurationBuilder builder)
            where T : class, IDatabaseMetadataProvider, new()
        {
            var database = new DatabaseConfiguration(new T());
            builder.AddDatabase(database.Metadata.Name, database);

            database.ExecutionPipelineFactory = new ExecutionPipelineFactory(builder.Configuration, database);

            return new DatabaseConfigurationBuilder(database);
        }

        //TO_DISCUSS: Should metadata include server info so we can infer compatibility version, or specifically specify based on method name (i.e. AddMsSql2014Database)
        #pragma warning disable IDE0060
        private static void ConfigureMsSqlCommon<T>(this DbExpressionConfigurationBuilder builder, DatabaseConfigurationBuilder config)
            where T : class, IDatabaseMetadataProvider, new()
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

        public static void AddMsSql2014Database<T>(this DbExpressionConfigurationBuilder builder, Action<DatabaseConfigurationBuilder> configure = null)
            where T : class, IDatabaseMetadataProvider, new()
        {
            var config = builder.CreateDatabaseConfigurationBuilder<T>();
            builder.ConfigureMsSqlCommon<T>(config);

            //configure sql statement builder factory
            var factory = new Assembler.v2014.MsSqlStatementBuilderFactory();
            factory.RegisterDefaultAssemblers();
            factory.RegisterDefaultPartAppenders();
            factory.RegisterDefaultValueFormatters();
            config.UseStatementBuilderFactory(factory);

            configure?.Invoke(config);
        }

        public static void AddMsSql2012Database<T>(this DbExpressionConfigurationBuilder builder, Action<DatabaseConfigurationBuilder> configure = null)
            where T : class, IDatabaseMetadataProvider, new()
        {
            var config = builder.CreateDatabaseConfigurationBuilder<T>();
            builder.ConfigureMsSqlCommon<T>(config);

            //configure sql statement builder factory
            var factory = new Assembler.v2012.MsSqlStatementBuilderFactory();
            factory.RegisterDefaultAssemblers();
            factory.RegisterDefaultPartAppenders();
            factory.RegisterDefaultValueFormatters();
            config.UseStatementBuilderFactory(factory);

            configure?.Invoke(config);
        }
    }
}
