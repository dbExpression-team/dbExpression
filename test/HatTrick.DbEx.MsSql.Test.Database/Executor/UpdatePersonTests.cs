using DataService;
using HatTrick.DbEx.Sql.Extensions.Builder;
using Xunit;
using FluentAssertions;

using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    public class UpdatePersonTests : ExecutorTestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Can_a_persons_firstname_update(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(dbo.Person.FirstName.Set("Foo"))
               .From(dbo.Person)
               .Where(dbo.Person.Id == 1);               

            //when               
            exp.Execute();

            //then
            var firstName = db.Select(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == 1).Execute();
            firstName.Should().NotBeNullOrWhiteSpace();
            firstName.Should().Be("Foo");
        }
    }
}
