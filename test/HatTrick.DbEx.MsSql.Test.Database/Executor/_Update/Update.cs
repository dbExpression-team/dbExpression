using DataService;
using HatTrick.DbEx.Sql.Extensions.Builder;
using Xunit;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "UPDATE")]
    public partial class Update : ExecutorTestBase
    {
        [Theory]
        [InlineData(2012)]
        [InlineData(2014)]
        public void Can_person_with_id_1_update_firstname(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(dbo.Person.FirstName.Set("Foo"))
               .From(dbo.Person)
               .Where(dbo.Person.Id == 1);

            //when               
            exp.Execute();

            //then
            var firstName = db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();
            firstName.Should().NotBeNullOrWhiteSpace();
            firstName.Should().Be("Foo");
        }
    }
}
