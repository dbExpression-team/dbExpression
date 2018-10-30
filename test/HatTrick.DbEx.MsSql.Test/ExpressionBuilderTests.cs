using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Executor;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Mapper;
using System.Collections.Generic;
using System.Configuration;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class ExpressionBuilderTests
    {
        protected ExpressionBuilderTests()
        {
            DbExpressionConfiguration.ConnectionStringSettings = new List<ConnectionStringSettings> { ConfigurationManager.ConnectionStrings["cq.genres"] };
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
