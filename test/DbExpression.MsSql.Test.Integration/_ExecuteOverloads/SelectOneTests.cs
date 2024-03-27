using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql.Connection;
using System;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public partial class SelectOneTests : ResetDatabaseNotRequired
    {
        #region value
        [Theory]
        [InlineData(50)]
        public void Does_execute_value_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_execute_value_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var value = exp.Execute(45);

            //then
            value.Should().Be(expected);
        }

        [Fact]
        public void Does_execute_value_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [InlineData(1)]
        public void Does_execute_value_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var value = exp.Execute(conn);

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_value_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int expected)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_execute_value_with_connection_and_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var value = exp.Execute(conn, 45);

            //then
            value.Should().Be(expected);
        }

        [Fact]
        public async Task Does_execute_async_dynamic_with_connection_and_commandTimeout_and_map_overrides_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(conn, 45, row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }
        #endregion
    }
}
