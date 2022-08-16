using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public partial class SelectOneTests : ExecutorTestBase
    {
        #region value
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_commandTimeout_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var value = exp.Execute(45);

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_connection_and_commandTimeout_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var value = exp.Execute(conn, 45);

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_value_with_action_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();
            object? value = default;

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            await exp.ExecuteAsync(o =>
                { value = o.ReadField()!.GetValue<int>(); }
            );

            //then
            value.Should().Be(expected);
        }
        #endregion

        #region type/entity
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {

            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_commandTimeout_override_succeed(int version, int? expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            Person? person = exp.Execute(45);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_override_succeed(int version, int? expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            Person? person = exp.Execute(conn);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_and_commandTimeout_overrides_succeed(int version, int? expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            Person? person = exp.Execute(conn, 45);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_map_delegate_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(row => id = row.ReadField()!.GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_commandTimeout_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(45, row => id = row.ReadField()!.GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_and_commandTimeout_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn, 45, row => id = row.ReadField()!.GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_map_to_entity_delegate_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = exp.Execute((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = exp.Execute((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = exp.Execute((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }
        #endregion

        #region dynamic
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {

            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_commandTimeout_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = exp.Execute(45);

            //then
            int id = d!.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = exp.Execute(conn);

            //then
            int id = d!.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = exp.Execute(conn, 45);

            //then
            int id = d!.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_map_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = exp.Execute(row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int version, int expectedCommandTimeout = 45)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = exp.Execute(expectedCommandTimeout, row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            usedCommandTimeout.Should().Be(expectedCommandTimeout);
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_map_overrides_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_map_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = exp.Execute(45, row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 45)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_commandTimeout_and_map_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = exp.Execute(conn, 45, row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }
        #endregion

        #region value async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_with_commandTimeout_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var value = await exp.ExecuteAsync(45);

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var value = await exp.ExecuteAsync(conn);

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var id = await exp.ExecuteAsync(conn, 45);

            //then
            id.Should().Be(expected);
        }
        #endregion

        #region type/entity async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
             Person? person = await exp.ExecuteAsync(45);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
             Person? person = await exp.ExecuteAsync(conn);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            Person? person = await exp.ExecuteAsync(conn, 45);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_map_delegate_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(row => id = row.ReadField()!.GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(45, row => id = row.ReadField()!.GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, row => id = row.ReadField()!.GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, 45, row => id = row.ReadField()!.GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_map_to_entity_delegate_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(45, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(conn, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(conn, 45, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_async_map_to_entity_delegate_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(row =>
                {
                     Person? person = new Person();
                    person.Id = row.ReadField()!.GetValue<int>();
                    return person;
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(45, row =>
                {
                     Person? person = new Person();
                    person.Id = row.ReadField()!.GetValue<int>();
                    return person;
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(conn, row =>
                {
                     Person? person = new Person();
                    person.Id = row.ReadField()!.GetValue<int>();
                    return person;
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(conn, 45, row =>
                {
                     Person? person = new Person();
                    person.Id = row.ReadField()!.GetValue<int>();
                    return person;
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_async_map_to_entity_delegate_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            Person? person = default;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(async row =>
                {
                    person = new Person();
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            Person? person = default;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(45, async row =>
                {
                    person = new Person();
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();
            Person? person = default;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, async row =>
                {
                    person = new Person();
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();
            Person? person = default;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, 45, async row =>
                {
                    person = new Person();
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_async_map_to_factory_created_entity_delegate_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(async (row, person) =>
                {
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(45, async (row, person) =>
                {
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
             Person? person = await exp.ExecuteAsync(conn, async (row, person) =>
                {
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            Person? person = await exp.ExecuteAsync(conn, 45, async (row, person) =>
                {
                    person.Id = row.ReadField()!.GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person!.Id.Should().NotBe(0);
        }
        #endregion

        #region dynamic async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {

            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(
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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_commandTimeout_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            dynamic d = (await exp.ExecuteAsync(45))!;

            //then
            int id = d.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = await exp.ExecuteAsync(conn);

            //then
            int id = d!.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = await exp.ExecuteAsync(conn, 45);

            //then
            int id = d!.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_map_override_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int version, int expectedCommandTimeout = 45)
        {
            //given
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(expectedCommandTimeout, row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            usedCommandTimeout.Should().Be(expectedCommandTimeout);
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_commandTimeout_and_map_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_and_map_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
            var conn = db.GetConnection();

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(conn, row => { var i = row.ReadField()!.GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 45)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = db.GetConnection();

            var exp = db.SelectOne(
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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_and_commandTimeout_and_map_overrides_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);
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
