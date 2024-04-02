using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace DbExpression.MsSql.Test.Unit
{
    public class AliasingTests : TestBase
    {
        [Fact]
        public void Two_instances_of_aliased_coalesce_function_should_not_be_same_instance()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var coalesce = db.fx.Coalesce(dbo.Person.BirthDate, dbo.Person.DateUpdated);
            var coalesceAsFoo = coalesce.As("Foo");
            var coalesceAsBar = coalesce.As("Bar");

            //then
            coalesceAsFoo.Should().NotBeSameAs(coalesceAsBar);
        }
    }
}
