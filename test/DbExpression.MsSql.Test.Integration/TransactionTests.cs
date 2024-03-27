using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "UPDATE")]
    public partial class TransactionTests : ResetDatabaseAfterEveryTest
    {
        [Fact]
        public async Task Does_truncate_with_update_statement_rollback_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
