using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.MsSql.Extensions.Configuration
{
    public static class DbExpressionConfigurationExtensions
    {
        public static void UseMsSql2014(this DbExpressionConfiguration settings)
        {
            //configure the expression part(s) assembler
            settings.AssemblerConfiguration = new DbExpressionAssemblerConfiguration { Minify = false };

            //configure the builder that constructs sql statements
            var factory = new MsSqlStatementBuilderFactory();
            factory.RegisterDefaultAliasProviders();
            factory.RegisterDefaultAssemblers();
            factory.RegisterDefaultPartAppenders();
            factory.RegisterDefaultValueFormatters();
            settings.StatementBuilderFactory = factory;

            //configure the appender factory
            settings.AppenderFactory = new AppenderFactory();

            //configure the parameter builder factory
            settings.ParameterBuilderFactory = new MsSqlParameterBuilderFactory();

            //configure the sql statement executor
            var executor = new MsSqlExecutorFactory();
            executor.RegisterDefaultExecutors();
            settings.ExecutorFactory = executor;

            //configure the connection factory
            settings.ConnectionFactory = new MsSqlConnectionFactory();

            //configure the factory to create entities
            var entityFactory = new EntityFactory();
            entityFactory.RegisterDefaultFactories();
            settings.EntityFactory = entityFactory;

            //configure mappers for mapping db data to objects/values
            var mapperFactory = new MapperFactory();
            mapperFactory.RegisterDefaultMappers();
            settings.MapperFactory = mapperFactory;
        }
    }
}
