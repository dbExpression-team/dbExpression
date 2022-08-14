using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "UPDATE")]
    public partial class TransactionTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_truncate_with_update_statement_rollback_successfully(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var tooLong = new string(Enumerable.Repeat('a', 1000).ToArray());
            var isRolledBack = false;

            using var connection = db.GetConnection();
            connection.EnsureOpen();
            connection.BeginTransaction();

            try
            {
                await db.Update(dbo.Person.FirstName.Set("foo"))
                   .From(dbo.Person)
                   .ExecuteAsync(connection);

                await db.Update(dbo.Person.FirstName.Set("bar"))
                   .From(dbo.Person)
                   .ExecuteAsync(connection);

                await db.Update(dbo.Person.FirstName.Set(tooLong))
                   .From(dbo.Person)
                   .ExecuteAsync(connection);

                connection.CommitTransaction();
            }
            catch (Exception)
            {
                connection.RollbackTransaction();
                isRolledBack = true;
            }

            //then
            isRolledBack.Should().BeTrue();
        }
    }
}
