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

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectMany : ExecutorTestBase
    {
        #region value list
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_commandTimeout_override_have_correct_commandTimeout_on_execution(int version, int expected = 50)
        {
            //given
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_value_list_with_connection_and_commandTimeout_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(conn);

            //then
            usedConnection.Should().Equals(conn);
        }
        
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            exp.Execute(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_execute_type_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(conn, 45);

            //then
            persons.Should().HaveCount(expected);
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
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
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
        public void Does_execute_dynamic_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
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
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var @returned = exp.Execute(row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

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
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = exp.Execute(expectedCommandTimeout, row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.BeforeExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
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
        public void Does_execute_dynamic_list_with_connection_and_map_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = exp.Execute(45, row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
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
        public void Does_execute_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = exp.Execute(conn, 45, row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

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
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_value_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(conn);

            //then
            usedConnection.Should().Equals(conn);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(expected);

            //then
            usedConnection.Should().Equals(conn);
            usedCommandTimeout.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_execute_async_type_list_with_connection_and_commandTimeout_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45);

            //then
            persons.Should().HaveCount(expected);
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
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
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
            DbConnection usedConnection = null;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.BeforeExecutingCommand(e => usedConnection = e.DbCommand.Connection)
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
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
        public async Task Does_execute_async_dynamic_list_with_connection_override_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

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
            var @returned = await exp.ExecuteAsync(row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

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
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e => usedCommandTimeout = e.DbCommand.CommandTimeout)
            );

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = await exp.ExecuteAsync(expectedCommandTimeout, row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

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
            var @returned = await exp.ExecuteAsync(row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

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
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName
                )
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = await exp.ExecuteAsync(conn, row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

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
            DbConnection usedConnection = null;
            var usedCommandTimeout = 0;
            var config = ConfigureForMsSqlVersion(version,
                c => c.WhenExecutingSqlStatements.AfterExecutingCommand(e =>
                {
                    usedConnection = e.DbCommand.Connection;
                    usedCommandTimeout = e.DbCommand.CommandTimeout;
                })
            );
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(
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
        public async Task Does_execute_async_dynamic_list_with_connection_and_commandTimeout_and_map_overrides_succeed(int version, int expected = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            var @returned = await exp.ExecuteAsync(conn, 45, row => { var id = row.ReadField().GetValue<int>(); ids.Add(id); return id; });

            //then
            ids.Should().HaveCount(expected);
            @returned.Should().HaveCount(expected);
            ids.Should().Equal(@returned);
        }
        #endregion
    }
}
