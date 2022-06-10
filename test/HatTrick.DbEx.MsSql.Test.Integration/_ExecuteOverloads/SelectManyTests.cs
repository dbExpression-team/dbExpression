using DbEx.dboDataService;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;
using DbEx.dboData;
using HatTrick.DbEx.Sql.Connection;
using System.Data;
using System;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public partial class SelectManyTests : ExecutorTestBase
    {
        #region value list
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }
        
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = exp.Execute(45);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = exp.Execute(conn);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_connection_and_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {

            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(45);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }
        
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(conn);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(conn, 45);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_map_delegate_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_commandTimeout_and_map_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(45, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_connection_and_commandTimeout_and_map_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn, 45, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_map_to_entity_delegate_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {

            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

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

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_map_override_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int version, int expectedCommandTimeout = 45, int expectedCount = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_connection_and_map_overrides_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_connection_and_map_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 45)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_list_with_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = await exp.ExecuteAsync(45);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_list_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = await exp.ExecuteAsync(conn);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_list_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var values = await exp.ExecuteAsync(conn, 45);

            //then
            values.Should().HaveCount(expected);
        }
        #endregion

        #region type/entity list async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(45);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Be(conn.DbConnection);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, expected);

            //then
            usedConnection.Should().Be(conn.DbConnection);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_map_delegate_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_commandTimeout_and_map_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(45, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_map_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_and_map_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var persons = new HashSet<int>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, 45, row => persons.Add(row.ReadField()!.GetValue<int>()));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_map_to_entity_delegate_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync((row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(45, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45, (row, person) => person.Id = row.ReadField()!.GetValue<int>());

            //then
            persons.Should().HaveCount(expected);
            persons.Should().NotContain(x => x.Id <= 0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_async_map_to_entity_delegate_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_async_map_to_entity_delegate_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_async_map_to_factory_created_entity_delegate_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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

        #region dynamic list async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {

            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection? usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_map_override_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int version, int expectedCommandTimeout = 45, int expectedCount = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_commandTimeout_and_map_overrides_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_connection_and_map_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 45)
        {
            //given
            IDbConnection? usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
        #endregion
    }
}
