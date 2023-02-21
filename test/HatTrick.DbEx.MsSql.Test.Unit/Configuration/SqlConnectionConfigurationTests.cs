using v2019DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.Sql.Connection;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Data;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Configuration
{
    public class SqlConnectionConfigurationTests : TestBase
    {
        [Fact]
        public void A_sql_connector_factory_registered_using_instance_should_be_the_same_factory()
        {
            //given
            var factory = Substitute.For<IDbConnectionFactory>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use(factory));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IDbConnectionFactory>();

            //then
            resolved.Should().Be(factory);
        }

        [Fact]
        public void A_sql_connector_factory_registered_via_service_serviceProvider_should_be_a_delegate_sql_connector_factory()
        {
            //given
            var sqlConnector = Substitute.For<ISqlConnection>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use(sp => sqlConnector));

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetService<IDbConnectionFactory>();

            //then
            factory.Should().BeOfType<DelegateSqlConnectionFactory>();
        }

        [Fact]
        public void A_sql_connector_factory_registered_generically_should_return_the_correct_factory()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use<NoOpSqlConnectionFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IDbConnectionFactory>();

            //then
            factory.Should().NotBeNull().And.BeOfType<NoOpSqlConnectionFactory>();
        }

        [Fact]
        public void A_sql_connector_factory_registered_via_delegate_should_return_the_correct_sql_connector()
        {
            //given
            var sqlConnector = Substitute.For<ISqlConnection>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use(() => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IDbConnectionFactory>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection();

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }

        [Fact]
        public void A_sql_connector_factory_registered_with_service_serviceProvider_delegate_should_return_the_correct_sql_connector()
        {
            //given
            var sqlConnector = Substitute.For<ISqlConnection>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use(sp => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IDbConnectionFactory>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection();

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }

        [Fact]
        public void A_sql_connector_factory_registered_using_instance_should_produce_transients()
        {
            //given
            var connectionStringFactory = Substitute.For<IConnectionStringFactory>();
            connectionStringFactory.GetConnectionString().Returns(ConfigurationProvider.ConnectionString);
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use(new MsSqlConnectionFactory(connectionStringFactory)));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IDbConnectionFactory>();

            //when
            var a1 = factory.CreateSqlConnection();
            var a2 = factory.CreateSqlConnection();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void A_sql_connector_factory_registered_via_service_provideer_should_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use(sp => Substitute.For<ISqlConnection>()));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IDbConnectionFactory>();

            //when
            var a1 = factory.CreateSqlConnection();
            var a2 = factory.CreateSqlConnection();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void A_sql_connector_factory_registered_via_delegate_should_produce_transients()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use(() => Substitute.For<ISqlConnection>()));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IDbConnectionFactory>();

            //when
            var a1 = factory.CreateSqlConnection();
            var a2 = factory.CreateSqlConnection();

            //then
            a1.Should().NotBe(a2);
        }

        [Fact]
        public void A_sql_connector_factory_registered_with_serviceProvider_delegate_should_produce_transients()
        {
            //given
            var sqlConnector = Substitute.For<ISqlConnection>();
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.QueryExecution.Connection.Use(sp => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IDbConnectionFactory>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection();

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }

        private class NoOpSqlConnectionFactory : IDbConnectionFactory
        {
            public IDbConnection CreateSqlConnection()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
