using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class LiteralExpressionEqualityTests : TestBase
    {
        [Fact]
        public void Literal_expressions_of_same_values_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new LiteralExpression<int>(1);
            var exp2 = new LiteralExpression<int>(1);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Literal_expressions_of_different_values_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new LiteralExpression<int>(1);
            var exp2 = new LiteralExpression<int>(2);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Literal_expressions_of_same_values_with_one_aliased_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new LiteralExpression<int>(1);
            var exp2 = new LiteralExpression<int>(1).As("foo");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Literal_expressions_of_same_values_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new LiteralExpression<int>(1);
            var exp2 = new LiteralExpression<int>(1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Literal_expressions_of_same_values_with_one_aliased_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new LiteralExpression<int>(1);
            var exp2 = new LiteralExpression<int>(1).As("foo");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Literal_expressions_of_different_values_with_one_distinct_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new LiteralExpression<int>(1);
            var exp2 = new LiteralExpression<int>(2);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
