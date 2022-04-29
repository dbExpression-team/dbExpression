using FluentAssertions;
using HatTrick.DbEx.Sql.Connection;
using NSubstitute;
using System.Data;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Assembler
{
    public class DelegateSqlConnectorFactoryTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_delegate_should_be_a_delegate_sql_connector_factory(int version)
        {
            //given
            var sqlConnector = Substitute.For<IDbConnection>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.QueryExecution.Connection.Use(_ => sqlConnector));

            //when
            var factory = database.ConnectionFactory;

            //then
            factory.Should().BeOfType<DelegateSqlConnectionFactory>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void A_sql_connector_factory_registered_via_delegate_should_return_the_correct_sql_connector(int version)
        {
            //given
            var sqlConnector = Substitute.For<IDbConnection>();
            var database = ConfigureForMsSqlVersion(version, postConfigure: c => c.SqlStatements.QueryExecution.Connection.Use(_ => sqlConnector));
            var factory = database.ConnectionFactory;

            //when
            var factorySqlConnector = factory.CreateSqlConnection("connection string");

            //then
            factorySqlConnector.Should().Be(sqlConnector);
        }
    }
}
