using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Expression
{
    public class FilterExpressionSetEqualityTests : TestBase
    {
        [Fact]
        public void Filter_expressions_of_same_values_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1;
            var exp2 = dbo.Person.CreditLimit > 1;

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Filter_expressions_of_different_values_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1;
            var exp2 = dbo.Person.CreditLimit > 2;

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Filter_expressions_of_same_values_and_different_operators_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1;
            var exp2 = dbo.Person.CreditLimit < 1;

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Filter_expressions_with_same_values_and_same_logical_operators_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1;
            var exp2 = dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1;

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Filter_expressions_with_same_values_and_different_logical_operators_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1;
            var exp2 = dbo.Person.CreditLimit > 1 | dbo.Person.Id == 1;

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Filter_expressions_of_same_values_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1;
            var exp2 = dbo.Person.CreditLimit > 1;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Filter_expressions_of_different_values_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1;
            var exp2 = dbo.Person.CreditLimit > 2;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Filter_expressions_of_same_values_and_different_operators_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1;
            var exp2 = dbo.Person.CreditLimit < 1;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Filter_expressions_with_same_values_and_same_logical_operators_should_have_same_hash_code()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1;
            var exp2 = dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Filter_expressions_with_same_values_and_different_logical_operators_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1;
            var exp2 = dbo.Person.CreditLimit > 1 | dbo.Person.Id == 1;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
