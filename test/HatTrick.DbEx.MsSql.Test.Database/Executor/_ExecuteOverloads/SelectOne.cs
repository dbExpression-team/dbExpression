using DbEx.dboDataService;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;
using DbEx.dboData;
using Moq;
using HatTrick.DbEx.Sql.Connection;
using System.Data;
using System;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectOne : ExecutorTestBase
    {
        #region value
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
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
            ConfigureForMsSqlVersion(version);

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
            IDbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
            IDbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_with_connection_and_commandTimeout_override_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            object value = default;

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            await exp.ExecuteAsync(o =>
                { value = o.ReadField().GetValue<int>(); }
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
            var config = ConfigureForMsSqlVersion(version,
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
        public void Does_execute_type_with_commandTimeout_override_succeed(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var person = exp.Execute(45);

            //then
            int id = person.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var person = exp.Execute(conn);

            //then
            int id = person.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var person = exp.Execute(conn, 45);

            //then
            int id = person.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_map_delegate_override_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(row => id = row.ReadField().GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_commandTimeout_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(45, row => id = row.ReadField().GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_and_commandTimeout_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn, 45, row => id = row.ReadField().GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_map_to_entity_delegate_override_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = exp.Execute((row, person) => person.Id = row.ReadField().GetValue<int>());

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = exp.Execute((row, person) => person.Id = row.ReadField().GetValue<int>());

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = exp.Execute((row, person) => person.Id = row.ReadField().GetValue<int>());

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }
        #endregion

        #region dynamic
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {

            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
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
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = exp.Execute(45);

            //then
            int id = d.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = exp.Execute(conn);

            //then
            int id = d.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_commandTimeout_override_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = exp.Execute(conn, 45);

            //then
            int id = d.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_map_override_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = exp.Execute(row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int version, int expectedCommandTimeout = 45)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = exp.Execute(expectedCommandTimeout, row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

            //then
            usedCommandTimeout.Should().Be(expectedCommandTimeout);
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_map_overrides_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(conn, row => row.ReadField().GetValue<int>());

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_map_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = exp.Execute(45, row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 45)
        {
            //given
            IDbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            exp.Execute(conn, expected, row => row.ReadField().GetValue<int>());

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_dynamic_with_connection_and_commandTimeout_and_map_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = exp.Execute(conn, 45, row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

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
            var config = ConfigureForMsSqlVersion(version,
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
            ConfigureForMsSqlVersion(version);

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
            IDbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
            IDbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

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
            var config = ConfigureForMsSqlVersion(version,
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
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var person = await exp.ExecuteAsync(45);

            //then
            int id = person.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var person = await exp.ExecuteAsync(conn);

            //then
            int id = person.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            IDbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var person = await exp.ExecuteAsync(conn, 45);

            //then
            int id = person.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_map_delegate_override_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(row => id = row.ReadField().GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(45, row => id = row.ReadField().GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, row => id = row.ReadField().GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_and_map_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            var id = 0;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, 45, row => id = row.ReadField().GetValue<int>());

            //then
            id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_map_to_entity_delegate_override_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync((row, person) => person.Id = row.ReadField().GetValue<int>());

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(45, (row, person) => person.Id = row.ReadField().GetValue<int>());

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(conn, (row, person) => person.Id = row.ReadField().GetValue<int>());

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_and_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(conn, 45, (row, person) => person.Id = row.ReadField().GetValue<int>());

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_async_map_to_entity_delegate_override_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(row =>
                {
                    var person = new Person();
                    person.Id = row.ReadField().GetValue<int>();
                    return person;
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(45, row =>
                {
                    var person = new Person();
                    person.Id = row.ReadField().GetValue<int>();
                    return person;
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(conn, row =>
                {
                    var person = new Person();
                    person.Id = row.ReadField().GetValue<int>();
                    return person;
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(conn, 45, row =>
                {
                    var person = new Person();
                    person.Id = row.ReadField().GetValue<int>();
                    return person;
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_async_map_to_entity_delegate_override_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            Person person = default;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(async row =>
                {
                    person = new Person();
                    person.Id = row.ReadField().GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            Person person = default;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(45, async row =>
                {
                    person = new Person();
                    person.Id = row.ReadField().GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_connection_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            Person person = default;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, async row =>
                {
                    person = new Person();
                    person.Id = row.ReadField().GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_void_with_connection_and_commandTimeout_and_async_map_to_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);
            Person person = default;

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, 45, async row =>
                {
                    person = new Person();
                    person.Id = row.ReadField().GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_async_map_to_factory_created_entity_delegate_override_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(async (row, person) =>
                {
                    person.Id = row.ReadField().GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(45, async (row, person) =>
                {
                    person.Id = row.ReadField().GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(conn, async (row, person) =>
                {
                    person.Id = row.ReadField().GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_with_connection_and_commandTimeout_and_async_map_to_factory_created_entity_delegate_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person);

            //when               
            var person = await exp.ExecuteAsync(conn, 45, async (row, person) =>
                {
                    person.Id = row.ReadField().GetValue<int>();
                    await Task.Delay(TimeSpan.Zero);
                }
            );

            //then
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
        }
        #endregion

        #region dynamic async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {

            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
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
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            dynamic d = await exp.ExecuteAsync(45);

            //then
            int id = d.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_override_have_correct_connection_on_execution(int version)
        {
            //given
            IDbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnBeforeSqlStatementExecution(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_override_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = await exp.ExecuteAsync(conn);

            //then
            int id = d.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 1)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var d = await exp.ExecuteAsync(conn, 45);

            //then
            int id = d.Id;
            id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_map_override_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_commandTimeout_and_map_overrides_have_correct_commandTimeout_on_execution(int version, int expectedCommandTimeout = 45)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(expectedCommandTimeout, row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

            //then
            usedCommandTimeout.Should().Be(expectedCommandTimeout);
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_commandTimeout_and_map_overrides_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_and_map_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(conn, row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_and_commandTimeout_and_map_overrides_have_correct_connection_and_commandTimeout_on_execution(int version, int expected = 45)
        {
            //given
            IDbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.Events.OnAfterSqlStatementExecution(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn, expected, row => row.ReadField().GetValue<int>());

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_dynamic_with_connection_and_commandTimeout_and_map_overrides_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory);

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var id = 0;
            var @returned = await exp.ExecuteAsync(conn, 45, row => { var i = row.ReadField().GetValue<int>(); id = i; return i; });

            //then
            id.Should().Be(@returned);
        }
        #endregion
    }
}
