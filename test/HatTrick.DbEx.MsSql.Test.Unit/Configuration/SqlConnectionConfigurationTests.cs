using DbEx.DataService;
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
        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_using_instance_should_be_the_same_factory(int version)
        {
            //given
            var factory = Substitute.For<ISqlConnectionFactory>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use(factory));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlConnectionFactory>();

            //then
            resolved.Should().Be(factory);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_service_serviceProvider_should_be_a_delegate_sql_connector_factory(int version)
        {
            //given
            var sqlConnector = Substitute.For<ISqlConnection>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use(sp => sqlConnector));

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlConnectionFactory>();

            //then
            factory.Should().BeOfType<DelegateSqlConnectionFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_generically_should_return_the_correct_factory(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use<NoOpSqlConnectionFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory>();

            //then
            factory.Should().NotBeNull().And.BeOfType<NoOpSqlConnectionFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_delegate_should_return_the_correct_sql_connector(int version)
        {
            //given
            var sqlConnector = Substitute.For<ISqlConnection>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use(() => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection();

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_with_service_serviceProvider_delegate_should_return_the_correct_sql_connector(int version)
        {
            //given
            var sqlConnector = Substitute.For<ISqlConnection>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use(sp => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection();

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_using_instance_should_produce_transients(int version)
        {
            //given
            var connectionStringFactory = Substitute.For<IConnectionStringFactory>();
            connectionStringFactory.GetConnectionString().Returns(ConfigurationProvider.ConnectionString);
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use(new MsSqlConnectionFactory(connectionStringFactory)));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory>();

            //when
            var a1 = factory.CreateSqlConnection();
            var a2 = factory.CreateSqlConnection();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_service_provideer_should_produce_transients(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use(sp => Substitute.For<ISqlConnection>()));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory>();

            //when
            var a1 = factory.CreateSqlConnection();
            var a2 = factory.CreateSqlConnection();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_delegate_should_produce_transients(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use(() => Substitute.For<ISqlConnection>()));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory>();

            //when
            var a1 = factory.CreateSqlConnection();
            var a2 = factory.CreateSqlConnection();

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_with_serviceProvider_delegate_should_produce_transients(int version)
        {
            //given
            var sqlConnector = Substitute.For<ISqlConnection>();
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => c.SqlStatements.QueryExecution.Connection.Use(sp => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection();

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }

        private class NoOpSqlConnectionFactory : ISqlConnectionFactory
        {
            public IDbConnection CreateSqlConnection()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
