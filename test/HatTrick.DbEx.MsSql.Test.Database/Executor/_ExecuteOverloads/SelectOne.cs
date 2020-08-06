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
                c => c.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var value = exp.Execute(conn, 45);

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
                c => c.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var person = exp.Execute(conn, 45);

            //then
            int id = person.Id;
            id.Should().Be(expected);
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
                c => c.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
                c => c.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.BeforeExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
                c => c.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
                c => c.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == expected);

            //when               
            var person = await exp.ExecuteAsync(conn, 45);

            //then
            int id = person.Id;
            id.Should().Be(expected);
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
                c => c.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
                c => c.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
