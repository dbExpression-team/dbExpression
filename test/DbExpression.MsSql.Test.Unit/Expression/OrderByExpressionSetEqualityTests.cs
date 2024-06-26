using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Expression
{
    public class OrderByExpressionSetEqualityTests : TestBase
    {
        [Fact]
        public void OrderBy_expressions_of_same_field_and_direction_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc();
            var exp2 = dbo.Person.CreditLimit.Asc();

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void OrderBy_expressions_of_same_field_and_different_directions_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc();
            var exp2 = dbo.Person.CreditLimit.Desc();

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void OrderBy_expressions_with_same_fields_and_same_direction_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc() & dbo.Person.Id.Desc();
            var exp2 = dbo.Person.CreditLimit.Asc() & dbo.Person.Id.Desc();

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void OrderBy_expressions_with_same_fields_and_same_direction_alternating_in_construction_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc() & dbo.Person.Id.Desc();
            var exp2 = dbo.Person.CreditLimit.Desc() & dbo.Person.Id.Asc();

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void OrderBy_expressions_with_same_fields_and_alternating_direction_alternating_in_construction_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc() & dbo.Person.Id.Desc();
            var exp2 = dbo.Person.Id.Desc() & dbo.Person.CreditLimit.Asc();

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void OrderBy_expressions_of_same_field_and_direction_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc();
            var exp2 = dbo.Person.CreditLimit.Asc();

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void OrderBy_expressions_of_same_field_and_different_directions_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc();
            var exp2 = dbo.Person.CreditLimit.Desc();

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void OrderBy_expressions_with_same_fields_and_same_direction_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc() & dbo.Person.Id.Desc();
            var exp2 = dbo.Person.CreditLimit.Asc() & dbo.Person.Id.Desc();

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void OrderBy_expressions_with_same_fields_and_same_direction_alternating_in_construction_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc() & dbo.Person.Id.Desc();
            var exp2 = dbo.Person.CreditLimit.Desc() & dbo.Person.Id.Asc();

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void OrderBy_expressions_with_same_fields_and_alternating_direction_alternating_in_construction_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.CreditLimit.Asc() & dbo.Person.Id.Desc();
            var exp2 = dbo.Person.Id.Desc() & dbo.Person.CreditLimit.Asc();

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
