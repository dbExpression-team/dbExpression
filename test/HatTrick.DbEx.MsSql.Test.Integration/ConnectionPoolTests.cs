using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Connection;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class ConnectionPoolTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Is_connection_returned_to_the_connection_pool_after_query_execution(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            config.ConnectionStringFactory = new DelegateConnectionStringFactory(() => $"{ConfigurationProvider.ConnectionString};Connect Timeout=3;Max Pool Size=1;Min Pool Size = 1;");
            config.ConnectionFactory = new MsSqlConnectionFactory();

            //when
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 2).Execute();

            //then
            /* with max pool size of 1, the second query execution will throw timeout exception after 3 seconds if the first execution leaks the connection */
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Is_connection_returned_to_the_connection_pool_after_async_query_execution(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            config.ConnectionStringFactory = new DelegateConnectionStringFactory(() => $"{ConfigurationProvider.ConnectionString};Connect Timeout=3;Max Pool Size=1;Min Pool Size = 1;");
            config.ConnectionFactory = new MsSqlConnectionFactory();

            //when
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 2).ExecuteAsync();

            //then
            /* with max pool size of 1, the second query execution will throw timeout exception after 3 seconds if the first execution leaks the connection */
        }
    }
}
