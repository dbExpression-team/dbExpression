using v2019DbEx.dboDataService;
using v2019DbEx.DataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;
using v2019DbEx.dboData;
using DbExpression.Sql.Connection;
using System.Data;
using System;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace DbExpression.MsSql.Test.Integration
{
    public partial class SelectManyTests : ResetDatabaseNotRequired
    {
        #region value list
        [Theory]
        [InlineData(50)]
        public void Does_execute_value_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }
        
        [Theory]
        [InlineData(50)]
        public void Does_execute_value_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = exp.Execute(45);

            //then
            values.Should().HaveCount(expected);
        }

        [Fact]
        public void Does_execute_value_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_value_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = exp.Execute(conn);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_value_list_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_value_list_with_connection_and_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = exp.Execute(conn, 45);

            //then
            values.Should().HaveCount(expected);
        }
        #endregion

        #region type/entity list
        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {

            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(45);

            //then
            persons.Should().HaveCount(expected);
        }

        [Fact]
        public void Does_execute_type_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }
        
        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(conn);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_connection_and_commandTimeout_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(conn, 45);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_map_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_commandTimeout_and_map_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(45, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_connection_and_commandTimeout_and_map_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn, 45, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_map_to_entity_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_type_list_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }
        #endregion

        #region dynamic list
        [Theory]
        [InlineData(50)]
        public void Does_execute_dynamic_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {

            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_dynamic_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var dynamics = exp.Execute(45);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Fact]
        public void Does_execute_dynamic_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_dynamic_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var dynamics = exp.Execute(conn);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var dynamics = exp.Execute(conn, 45);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_dynamic_list_with_map_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.Id, 
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = exp.Execute(row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            ids.Should().HaveCount(expected);
            @returned.Should().HaveCount(expected);
            ids.Should().Equal(@returned);
        }

        [Theory]
        [InlineData(45, 50)]
        public void Does_execute_dynamic_list_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int expectedCommandTimeout, int expectedCount)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = exp.Execute(expectedCommandTimeout, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            usedCommandTimeout.Should().Be(expectedCommandTimeout);
            ids.Should().HaveCount(expectedCount);
            @returned.Should().HaveCount(expectedCount);
            ids.Should().Equal(@returned);
        }

        [Fact]
        public void Does_execute_dynamic_list_with_connection_and_map_overrides_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(conn, row => row.ReadField()!.GetValue<int>());

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_dynamic_list_with_connection_and_map_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = exp.Execute(45, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            ids.Should().HaveCount(expected);
            @returned.Should().HaveCount(expected);
            ids.Should().Equal(@returned);
        }

        [Theory]
        [InlineData(45)]
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected, row => row.ReadField()!.GetValue<int>());

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = exp.Execute(conn, 45, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            ids.Should().HaveCount(expected);
            @returned.Should().HaveCount(expected);
            ids.Should().Equal(@returned);
        }
        #endregion

        #region value list async
        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_value_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_value_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await foreach(var _ in exp.ExecuteAsyncEnumerable(expected));

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_value_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = await exp.ExecuteAsync(45);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_value_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<int> values = new();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when
            await foreach (var id in exp.ExecuteAsyncEnumerable(45))
                values.Add(id);

            //then
            values.Should().HaveCount(expected);
        }

        [Fact]
        public async Task Does_execute_async_value_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Fact]
        public async Task Does_execute_async_enumerable_value_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await foreach (var id in exp.ExecuteAsyncEnumerable(conn));

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_value_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = await exp.ExecuteAsync(conn);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_value_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            List<int> values = new();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await foreach (var id in exp.ExecuteAsyncEnumerable(conn))
                values.Add(id);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_value_list_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_value_list_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await foreach(var _ in exp.ExecuteAsyncEnumerable(conn, expected));

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_value_list_with_connection_and_commandTimeout_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = await exp.ExecuteAsync(conn, 45);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_value_list_with_connection_and_commandTimeout_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            List<int> values = new();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await foreach (var id in exp.ExecuteAsyncEnumerable(conn, 45))
                values.Add(id);

            //then
            values.Should().HaveCount(expected);
        }
        #endregion

        #region type/entity list async
        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(45);

            //then
            persons.Should().HaveCount(expected);
        }

        [Fact]
        public async Task Does_execute_async_type_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_map_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_commandTimeout_and_map_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(45, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_map_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_and_map_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, 45, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_map_to_entity_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(45, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_async_map_to_entity_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(row => 
                {
                    Person person = new()
                    {
                        Id = row.ReadField()!.GetValue<int>()
                    };
                    return person; 
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(45, row =>
                {
                    Person person = new()
                    {
                        Id = row.ReadField()!.GetValue<int>()
                    };
                    return person;
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, row =>
                {
                    Person person = new()
                    {
                        Id = row.ReadField()!.GetValue<int>()
                    };
                    return person;
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45, row =>
                {
                    Person person = new()
                    {
                        Id = row.ReadField()!.GetValue<int>()
                    };
                    return person;
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_void_with_async_map_to_entity_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var persons = new List<Person>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(async row =>
                {
                    Person person = new()
                    {
                        Id = row.ReadField()!.GetValue<int>()
                    };
                    await Task.Delay(TimeSpan.Zero);
                    persons.Add(person);
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_void_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var persons = new List<Person>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(45, async row =>
                {
                    Person person = new()
                    {
                        Id = row.ReadField()!.GetValue<int>()
                    };
                    await Task.Delay(TimeSpan.Zero);
                    persons.Add(person);
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }


        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_void_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new List<Person>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, async row =>
                {
                    Person person = new()
                    {
                        Id = row.ReadField()!.GetValue<int>()
                    };
                    await Task.Delay(TimeSpan.Zero);
                    persons.Add(person);
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_void_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new List<Person>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, 45, async row =>
                {
                    Person person = new()
                    {
                        Id = row.ReadField()!.GetValue<int>()
                    };
                    await Task.Delay(TimeSpan.Zero);
                    persons.Add(person);
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_async_map_to_factory_created_entity_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(async (row, person) =>
                {
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(45, async (row, person) =>
                {
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, async (row, person) =>
                {
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45, async (row, person) =>
                {
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }
        #endregion

        #region type/entity list async enumerable
        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await foreach(var _ in exp.ExecuteAsyncEnumerable(expected));

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable(expected))
                persons.Add(person);

            //then
            persons.Should().HaveCount(expected);
        }

        [Fact]
        public async Task Does_execute_async_enumerable_type_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable(conn))
                persons.Add(person);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable(conn))
                persons.Add(person);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable(conn, expected))
                persons.Add(person);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_and_commandTimeout_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable(conn, 45))
                persons.Add(person);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_map_to_entity_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable((row, person) => person.Id = row.ReadField()!.GetValue<int>()))
                persons.Add(person);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable(45, (row, person) => person.Id = row.ReadField()!.GetValue<int>()))
                persons.Add(person);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_and_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable(conn, (row, person) => person.Id = row.ReadField()!.GetValue<int>()))
                persons.Add(person);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable(conn, 45, (row, person) => person.Id = row.ReadField()!.GetValue<int>()))
                persons.Add(person);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_async_map_to_entity_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var p in exp.ExecuteAsyncEnumerable(row =>
            {
                Person person = new()
                {
                    Id = row.ReadField()!.GetValue<int>()
                };
                return person;
            })) persons.Add(p);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var p in exp.ExecuteAsyncEnumerable(45, row =>
            {
                Person person = new()
                {
                    Id = row.ReadField()!.GetValue<int>()
                };
                return person;
            })) persons.Add(p);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when
            List<Person> persons = new();
            await foreach (var p in exp.ExecuteAsyncEnumerable(conn, row =>
            {
                Person person = new()
                {
                    Id = row.ReadField()!.GetValue<int>()
                };
                return person;
            })) persons.Add(p);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when
            List<Person> persons = new();
            await foreach (var p in exp.ExecuteAsyncEnumerable(conn, 45, row =>
            {
                Person person = new()
                {
                    Id = row.ReadField()!.GetValue<int>()
                };
                return person;
            })) persons.Add(p);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_async_map_to_factory_created_entity_delegate_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var persons = new List<Person>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await foreach (var p in exp.ExecuteAsyncEnumerable(async (row, person) =>
            {
                person.Id = row.ReadField()!.GetValue<int>();
                await Task.Delay(TimeSpan.Zero);
            })) persons.Add(p);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var persons = new List<Person>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await foreach (var p in exp.ExecuteAsyncEnumerable(45, async (row, person) =>
            {
                person.Id = row.ReadField()!.GetValue<int>();
                await Task.Delay(TimeSpan.Zero);
            })) persons.Add(p);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new List<Person>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await foreach (var p in exp.ExecuteAsyncEnumerable(conn, async (row, person) =>
            {
                person.Id = row.ReadField()!.GetValue<int>();
                await Task.Delay(TimeSpan.Zero);
            })) persons.Add(p);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_type_list_with_connection_and_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            var persons = new List<Person>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await foreach (var p in exp.ExecuteAsyncEnumerable(conn, 45, async (row, person) =>
            {
                person.Id = row.ReadField()!.GetValue<int>();
                await Task.Delay(TimeSpan.Zero);
            })) persons.Add(p);

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }
        #endregion

        #region dynamic list async
        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_dynamic_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {

            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int expected)
        {

            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await foreach (var _ in exp.ExecuteAsyncEnumerable(expected));

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_dynamic_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.Id, 
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var dynamics = await exp.ExecuteAsync(45);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_commandTimeout_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<dynamic> dynamics = new();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await foreach (var value in exp.ExecuteAsyncEnumerable(45))
                dynamics.Add(value);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Fact]
        public async Task Does_execute_async_dynamic_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Fact]
        public async Task Does_execute_async_enumerable_dynamic_list_with_connection_override_have_correct_connection_on_execution()
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnBeforeCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await foreach (var value in exp.ExecuteAsyncEnumerable(conn))

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_dynamic_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var dynamics = await exp.ExecuteAsync(conn);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_connection_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            List<dynamic> dynamics = new();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await foreach (var value in exp.ExecuteAsyncEnumerable(conn))
                dynamics.Add(value);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_dynamic_list_with_connection_and_commandTimeout_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var dynamics = await exp.ExecuteAsync(conn, 45);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_connection_and_commandTimeout_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();
            List<dynamic> dynamics = new();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await foreach (var value in exp.ExecuteAsyncEnumerable(conn, 45))
                dynamics.Add(value);

            //then
            dynamics.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_dynamic_list_with_map_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = await exp.ExecuteAsync(row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            ids.Should().HaveCount(expected);
            @returned.Should().HaveCount(expected);
            ids.Should().Equal(@returned);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_map_override_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await foreach(var value in exp.ExecuteAsyncEnumerable(row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; }));

            //then
            ids.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(45, 50)]
        public async Task Does_execute_async_dynamic_list_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int expectedCommandTimeout, int expectedCount)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = await exp.ExecuteAsync(expectedCommandTimeout, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            usedCommandTimeout.Should().Be(expectedCommandTimeout);
            ids.Should().HaveCount(expectedCount);
            @returned.Should().HaveCount(expectedCount);
            ids.Should().Equal(@returned);
        }

        [Theory]
        [InlineData(45, 50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int expectedCommandTimeout, int expectedCount)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(
                c => c.Events.OnAfterCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await foreach (var value in exp.ExecuteAsyncEnumerable(expectedCommandTimeout, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; })) ;

            //then
            usedCommandTimeout.Should().Be(expectedCommandTimeout);
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_dynamic_list_with_commandTimeout_and_map_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = await exp.ExecuteAsync(45, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            ids.Should().HaveCount(expected);
            @returned.Should().HaveCount(expected);
            ids.Should().Equal(@returned);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_commandTimeout_and_map_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await foreach (var value in exp.ExecuteAsyncEnumerable(45, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; })) ;

            //then
            ids.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_dynamic_list_with_connection_and_map_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = await exp.ExecuteAsync(conn, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            ids.Should().HaveCount(expected);
            @returned.Should().HaveCount(expected);
            ids.Should().Equal(@returned);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_connection_and_map_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await foreach (var value in exp.ExecuteAsyncEnumerable(conn, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; })) ;

            //then
            ids.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(45)]
        public async Task Does_execute_async_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, expected, row => row.ReadField()!.GetValue<int>());

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(45)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int expected)
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

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await foreach (var value in exp.ExecuteAsyncEnumerable(conn, expected, row => row.ReadField()!.GetValue<int>())) ;

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = await exp.ExecuteAsync(conn, 45, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; });

            //then
            ids.Should().HaveCount(expected);
            @returned.Should().HaveCount(expected);
            ids.Should().Equal(@returned);
        }

        [Theory]
        [InlineData(50)]
        public async Task Does_execute_async_enumerable_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var conn = db.GetConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await foreach (var value in exp.ExecuteAsyncEnumerable(conn, 45, row => { var id = row.ReadField()!.GetValue<int>(); ids.Add(id); return id; }));

            //then
            ids.Should().HaveCount(expected);
        }
        #endregion
    }
}
