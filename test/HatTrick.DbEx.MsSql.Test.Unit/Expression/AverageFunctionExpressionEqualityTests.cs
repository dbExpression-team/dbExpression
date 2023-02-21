using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class AverageFunctionExpressionEqualityTests : TestBase
    {
        [Fact]
        public void Average_functions_of_person_id_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Average_functions_of_person_id_with_one_aliased_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id).As("foo");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Average_functions_of_person_id_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Average_functions_of_person_id_with_one_aliased_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id).As("foo");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Average_functions_of_person_id_with_one_distinct_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id).Distinct();

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
