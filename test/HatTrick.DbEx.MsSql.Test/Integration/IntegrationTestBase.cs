using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Executor;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public abstract class IntegrationTestBase
    {
        protected IntegrationTestBase() : this(ConfigurationManager.AppSettings["DefaultDatabase"])
        {
        }

        protected IntegrationTestBase(string databaseName)
        {
            //replace the path
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString.Replace("{Path}", path);

            new Seeder(databaseName, connectionString).RunScript("Reset.sql");

            DbExpressionConfiguration.ConnectionStringSettings = new List<ConnectionStringSettings> { new ConnectionStringSettings(databaseName, connectionString) };
            var factory = new MsSqlStatementBuilderFactory();
            factory.RegisterDefaultAssemblers();
            factory.RegisterDefaultPartAssemblers();
            factory.RegisterDefaultValueFormatters();
            DbExpressionConfiguration.StatementBuilderFactory = factory;
            DbExpressionConfiguration.ParameterBuilderFactory = new MsSqlParameterBuilderFactory();

            var executor = new MsSqlExecutorFactory();
            executor.RegisterDefaultExecutors();

            DbExpressionConfiguration.ExecutorFactory = executor;
            DbExpressionConfiguration.ConnectionFactory = new MsSqlConnectionFactory();
            DbExpressionConfiguration.AssemblerConfiguration.Minify = false;

            //TODO: mappers are not used at all....
            var mapperFactory = new MapperFactory();
            mapperFactory.RegisterDefaultMaps();
            DbExpressionConfiguration.MapperFactory = mapperFactory;
        }
    }
}
