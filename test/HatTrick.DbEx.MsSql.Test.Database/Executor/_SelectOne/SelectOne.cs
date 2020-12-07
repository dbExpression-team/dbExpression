using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    public partial class SelectOne : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_a_person_record_select_successfully(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = exp.Execute();

            //then
            person.FirstName.Should().Be("Kenny");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public async Task Can_a_person_record_select_async_successfully(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            var person = await exp.ExecuteAsync();

            //then
            person.FirstName.Should().Be("Kenny");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public async Task Can_a_group_by_select_async_when_table_name_is_aliased_runsuccessfully(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var table = dbo.Person.As("dboPerson");  
                        
            var count = await db.SelectOne(db.fx.Count(table.FirstName))
                .From(table)
                .GroupBy(table.FirstName)
                .ExecuteAsync();

            //then
            count.Should().Be(expected);
        }
    }
}
