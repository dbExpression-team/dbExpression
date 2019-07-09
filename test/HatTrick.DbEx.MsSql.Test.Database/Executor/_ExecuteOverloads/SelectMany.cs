using DbEx.Data.dbo;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectMany : ExecutorTestBase
    {
        #region value list
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_list_overloads_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = exp.Execute(45);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_list_overloads_connection(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = exp.Execute(conn);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_list_overloads_connection_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = exp.Execute(conn, 45);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_list_overloads_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            exp.Execute(id => ids.Add(id));

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_list_overloads_commandTimeout_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            exp.Execute(45, id => ids.Add(id));

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_list_overloads_connection_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            exp.Execute(conn, id => ids.Add(id));

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_value_list_overloads_connection_commandTimeout_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            exp.Execute(conn, 45, id => ids.Add(id));

            //then
            ids.Should().HaveCount(expectedCount);
        }
        #endregion

        #region type/entity list
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_list_overloads_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(45);

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_list_overloads_connection(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(conn);

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_list_overloads_connection_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute(conn, 45);

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_list_overloads_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            exp.Execute(person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_list_overloads_commandTimeout_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            exp.Execute(45, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_list_overloads_connection_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            exp.Execute(conn, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_type_list_overloads_connection_commandTimeout_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            exp.Execute(conn, 45, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }
        #endregion

        #region dynamic list
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_list_overloads_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var ids = exp.Execute(45);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_list_overloads_connection(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var ids = exp.Execute(conn);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_list_overloads_connection_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var ids = exp.Execute(conn, 45);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_list_overloads_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            exp.Execute(id => persons.Add(id));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_list_overloads_commandTimeout_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            exp.Execute(45, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_list_overloads_connection_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            exp.Execute(conn, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Execute_dynamic_list_overloads_connection_commandTimeout_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            exp.Execute(conn, 45, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }
        #endregion

        #region value list async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = await exp.ExecuteAsync(45);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_connection(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = await exp.ExecuteAsync(conn);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_connection_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = await exp.ExecuteAsync(conn, 45);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_Action_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await exp.ExecuteAsync(id => ids.Add(id));

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_Func_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await exp.ExecuteAsync(async id => { ids.Add(id); await Task.CompletedTask; });

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_commandTimeout_Action_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await exp.ExecuteAsync(45, id => ids.Add(id));

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_commandTimeout_Func_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await exp.ExecuteAsync(45, async id => { ids.Add(id); await Task.CompletedTask; });

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_connection_Action_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await exp.ExecuteAsync(conn, id => ids.Add(id));

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_connection_Func_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await exp.ExecuteAsync(conn, async id => { ids.Add(id); await Task.CompletedTask; });

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_connection_commandTimeout_Action_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await exp.ExecuteAsync(conn, 45, id => ids.Add(id));

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_value_list_overloads_connection_commandTimeout_Func_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<int>(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            var ids = new List<int>();
            await exp.ExecuteAsync(conn, 45, async id => { ids.Add(id); await Task.CompletedTask; });

            //then
            ids.Should().HaveCount(expectedCount);
        }
        #endregion

        #region type/entity list async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(45);

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_connection(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn);

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_connection_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45);

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_Action_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            await exp.ExecuteAsync(person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_Func_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            await exp.ExecuteAsync(async person => { persons.Add(person); await Task.CompletedTask; });

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_commandTimeout_Action_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            await exp.ExecuteAsync(45, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_commandTimeout_Func_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            await exp.ExecuteAsync(45, async person => { persons.Add(person); await Task.CompletedTask; });

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_connection_Action_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            await exp.ExecuteAsync(conn, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_connection_Func_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            await exp.ExecuteAsync(conn, async person => { persons.Add(person); await Task.CompletedTask; });

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_connection_commandTimeout_Action_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            await exp.ExecuteAsync(conn, 45, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_type_list_overloads_connection_commandTimeout_Func_onEntityMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = new List<Person>();
            await exp.ExecuteAsync(conn, 45, async person => { persons.Add(person); await Task.CompletedTask; });

            //then
            persons.Should().HaveCount(expectedCount);
        }
        #endregion

        #region dynamic list async
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var ids = await exp.ExecuteAsync(45);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_connection(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var ids = await exp.ExecuteAsync(conn);

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_connection_commandTimeout(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(conn, 45);

            //then
            var ids = persons.Select(p => p.Id);
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_Action_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            await exp.ExecuteAsync(id => persons.Add(id));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_Func_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            await exp.ExecuteAsync(async id => { persons.Add(id); await Task.CompletedTask; });

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_commandTimeout_Action_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            await exp.ExecuteAsync(45, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_commandTimeout_Func_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            await exp.ExecuteAsync(45, async person => { persons.Add(person); await Task.CompletedTask; });

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_connection_Action_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            await exp.ExecuteAsync(conn, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_connection_Func_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            await exp.ExecuteAsync(conn, async person => { persons.Add(person); await Task.CompletedTask; });

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_connection_commandTimeout_Action_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            await exp.ExecuteAsync(conn, 45, person => persons.Add(person));

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task ExecuteAsync_dynamic_list_overloads_connection_commandTimeout_Func_onValueMaterialized(int version, int expectedCount = 50)
        {
            //given
            var config = ConfigureForMsSqlVersion(version);
            var conn = config.ConnectionFactory.CreateSqlConnection();

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person);

            //when               
            var persons = new List<dynamic>();
            await exp.ExecuteAsync(conn, 45, async person => { persons.Add(person); await Task.CompletedTask; });

            //then
            persons.Should().HaveCount(expectedCount);
        }
        #endregion
    }
}
