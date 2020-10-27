using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Microsoft.SqlServer.Management.Dmf;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class ConnectionPool : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Is_connection_returned_to_the_connection_pool_after_query_execution(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            config.ConnectionFactory = new MsSqlConnectionFactory(() => $"{ConfigurationProvider.ConnectionString};Connect Timeout=3;Max Pool Size=1;Min Pool Size = 1;");

            //when
            var a = db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();
            var b = db.SelectOne(dbo.Person.Id).From(dbo.Person).Where(dbo.Person.Id == 2).Execute();

            //then
            /* with max pool size of 1, the second query execution will throw timeout exception after 3 seconds if the first execuation leaks the connection */
        }
    }
}
