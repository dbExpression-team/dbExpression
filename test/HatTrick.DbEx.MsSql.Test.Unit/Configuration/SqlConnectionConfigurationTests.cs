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
            var factory = Substitute.For<ISqlConnectionFactory<MsSqlDb>>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use(factory));

            //when
            var resolved = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlConnectionFactory<MsSqlDb>>();

            //then
            resolved.Should().Be(factory);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_service_serviceProvider_should_be_a_delegate_sql_connector_factory(int version)
        {
            //given
            var sqlConnector = Substitute.For<IDbConnection>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use((sp, cs) => sqlConnector));

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetService<ISqlConnectionFactory<MsSqlDb>>();

            //then
            factory.Should().BeOfType<DelegateSqlConnectionFactory<MsSqlDb>>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_generically_should_return_the_correct_factory(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use<NoOpSqlConnectionFactory>());

            //when
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory<MsSqlDb>>();

            //then
            factory.Should().NotBeNull().And.BeOfType<NoOpSqlConnectionFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_delegate_should_return_the_correct_sql_connector(int version)
        {
            //given
            var sqlConnector = Substitute.For<IDbConnection>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use(cs => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory<MsSqlDb>>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection("connection string");

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_with_service_serviceProvider_delegate_should_return_the_correct_sql_connector(int version)
        {
            //given
            var sqlConnector = Substitute.For<IDbConnection>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use((sp, cs) => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory<MsSqlDb>>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection("connection string");

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_using_instance_should_produce_transients(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use(new MsSqlConnectionFactory<MsSqlDb>()));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory<MsSqlDb>>();

            //when
            var a1 = factory.CreateSqlConnection(ConfigurationProvider.ConnectionString);
            var a2 = factory.CreateSqlConnection(ConfigurationProvider.ConnectionString);

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_service_provideer_should_produce_transients(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use((sp, cs) => Substitute.For<IDbConnection>()));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory<MsSqlDb>>();

            //when
            var a1 = factory.CreateSqlConnection("abc");
            var a2 = factory.CreateSqlConnection("abc");

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_delegate_should_produce_transients(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use(cs => Substitute.For<IDbConnection>()));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory<MsSqlDb>>();

            //when
            var a1 = factory.CreateSqlConnection("abc");
            var a2 = factory.CreateSqlConnection("abc");

            //then
            a1.Should().NotBe(a2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_with_service_serviceProvider_delegate_should_produce_transients(int version)
        {
            //given
            var sqlConnector = Substitute.For<IDbConnection>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version, c => c.SqlStatements.QueryExecution.Connection.Use((sp, cs) => sqlConnector));
            var factory = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlConnectionFactory<MsSqlDb>>();

            //when
            var factorySqlConnector = factory.CreateSqlConnection("connection string");

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }






        private class NoOpSqlConnectionFactory : ISqlConnectionFactory<MsSqlDb>
        {
            public IDbConnection CreateSqlConnection(string connectionString)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
