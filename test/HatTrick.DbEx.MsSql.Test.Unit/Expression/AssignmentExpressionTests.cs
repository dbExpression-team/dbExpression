using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class AssignmentExpressionEqualityTests : TestBase
    {
        [Fact]
        public void Assignment_expressions_of_same_values_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Set(1);
            var exp2 = dbo.Person.CreditLimit.Set(1);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Assignment_expressions_of_different_values_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Set(1);
            var exp2 = dbo.Person.CreditLimit.Set(2);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Assignment_expressions_of_same_values_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Set(1);
            var exp2 = dbo.Person.CreditLimit.Set(1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Assignment_expressions_of_different_values_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Set(1);
            var exp2 = dbo.Person.CreditLimit.Set(2);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
