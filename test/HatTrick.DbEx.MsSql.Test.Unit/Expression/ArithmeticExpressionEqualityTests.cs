using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class ArithmeticFunctionExpressionEqualityTests : TestBase
    {
        [Fact]
        public void Arithmetic_functions_of_person_id_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.Id + 1;
            var exp2 = dbo.Person.Id + 1;

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Arithmetic_functions_of_person_id_should_not_be_equal_when_adding_different_values()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.Id + 1;
            var exp2 = dbo.Person.Id + 2;

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Arithmetic_functions_of_person_id_with_one_aliased_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.Id + 1;
            var exp2 = (dbo.Person.Id + 1).As("foo");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Arithmetic_functions_of_person_id_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.Id + 1;
            var exp2 = dbo.Person.Id + 1;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Arithmetic_functions_of_person_id_with_one_aliased_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.Id + 1;
            var exp2 = (dbo.Person.Id + 1).As("foo");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
