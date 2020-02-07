using DbEx.Data.dbo;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectOne : ExecutorTestBase
    {
        #region value
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_overloads_commandTimeout(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var id = exp.Execute(45);

            //then
            id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_overloads_connection(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var id = exp.Execute(conn);

            //then
            id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_overloads_connection_commandTimeout(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var id = exp.Execute(conn, 45);

            //then
            id.Should().Be(1);
        }
        #endregion

        #region type/entity
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_overloads_commandTimeout(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = exp.Execute(45);

            //then
            person.Id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_overloads_connection(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = exp.Execute(conn);

            //then
            person.Id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_overloads_connection_commandTimeout(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = exp.Execute(conn, 45);

            //then
            person.Id.Should().Be(1);
        }
        #endregion

        #region dynamic
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_overloads_commandTimeout(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = exp.Execute(45);

            //then
            int id = person.Id;
            id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_overloads_connection(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = exp.Execute(conn);

            //then
            int id = person.Id;
            id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_overloads_connection_commandTimeout(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = exp.Execute(conn, 45);

            //then
            int id = person.Id;
            id.Should().Be(1);
        }
        #endregion

        #region value
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_overloads_commandTimeout(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var id = await exp.ExecuteAsync(45);

            //then
            id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_overloads_connection(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var id = await exp.ExecuteAsync(conn);

            //then
            id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_overloads_connection_commandTimeout(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var id = await exp.ExecuteAsync(conn, 45);

            //then
            id.Should().Be(1);
        }
        #endregion

        #region type/entity
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_overloads_commandTimeout(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = await exp.ExecuteAsync(45);

            //then
            person.Id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_overloads_connection(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = await exp.ExecuteAsync(conn);

            //then
            person.Id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_overloads_connection_commandTimeout(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = await exp.ExecuteAsync(conn, 45);

            //then
            person.Id.Should().Be(1);
        }
        #endregion

        #region dynamic
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_overloads_commandTimeout(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = await exp.ExecuteAsync(45);

            //then
            int id = person.Id;
            id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_overloads_connection(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = await exp.ExecuteAsync(conn);

            //then
            int id = person.Id;
            id.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_overloads_connection_commandTimeout(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = await exp.ExecuteAsync(conn, 45);

            //then
            int id = person.Id;
            id.Should().Be(1);
        }
        #endregion
    }
}
