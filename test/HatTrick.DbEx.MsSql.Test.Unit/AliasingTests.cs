using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit
{
    public class AliasingTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Two_instances_of_aliased_coalesce_function_should_not_be_same_instance(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var coalesce = db.fx.Coalesce(dbo.Person.BirthDate, dbo.Person.DateUpdated);
            var coalesceAsFoo = coalesce.As("Foo");
            var coalesceAsBar = coalesce.As("Bar");

            //then
            coalesceAsFoo.Should().NotBeSameAs(coalesceAsBar);
        }
    }
}
