using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.Sql.Expression;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Expression
{
    public class DbTypeExpressionEqualityTests : TestBase
    {
        [Fact]
        public void DbType_expressions_of_same_values_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new DbTypeExpression<TestEnum>(TestEnum.AValue);
            var exp2 = new DbTypeExpression<TestEnum>(TestEnum.AValue);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void DbType_expressions_of_different_values_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new DbTypeExpression<TestEnum>(TestEnum.AValue);
            var exp2 = new DbTypeExpression<TestEnum>(TestEnum.BValue);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void DbType_expressions_of_same_values_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new DbTypeExpression<TestEnum>(TestEnum.AValue);
            var exp2 = new DbTypeExpression<TestEnum>(TestEnum.AValue);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc2.Should().Be(hc2);
        }

        [Fact]
        public void DbType_expressions_of_different_values_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new DbTypeExpression<TestEnum>(TestEnum.AValue);
            var exp2 = new DbTypeExpression<TestEnum>(TestEnum.BValue);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        private enum TestEnum
        {
            AValue,
            BValue
        }
    }
}
