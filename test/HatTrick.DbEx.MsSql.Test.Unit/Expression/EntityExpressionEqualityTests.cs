using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class EntityExpressionEqualityTests : TestBase
    {
        [Fact]
        public void Entity_expressions_of_same_entity_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person;
            var exp2 = dbo.Person;

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Entity_expressions_of_different_entities_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person;
            var exp2 = dbo.Address;

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Entity_expressions_of_same_entity_with_one_aliased_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person;
            var exp2 = dbo.Person.As("alias");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Entity_expressions_of_same_entities_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person;
            var exp2 = dbo.Person;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Entity_expressions_of_different_entities_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person;
            var exp2 = dbo.Address;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Entity_expressions_of_same_entities_with_one_aliased_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person;
            var exp2 = dbo.Person.As("alias");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
