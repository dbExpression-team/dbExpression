using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class DatePartsExpressionEqualityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void DateParts_expressions_of_same_values_should_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp1 = new DatePartsExpression<TestEnum>(TestEnum.AValue);
            var exp2 = new DatePartsExpression<TestEnum>(TestEnum.AValue);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void DateParts_expressions_of_different_values_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp1 = new DatePartsExpression<TestEnum>(TestEnum.AValue);
            var exp2 = new DatePartsExpression<TestEnum>(TestEnum.BValue);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void DateParts_expressions_of_same_values_should_have_same_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp1 = new DatePartsExpression<TestEnum>(TestEnum.AValue);
            var exp2 = new DatePartsExpression<TestEnum>(TestEnum.AValue);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc2.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void DateParts_expressions_of_different_values_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp1 = new DatePartsExpression<TestEnum>(TestEnum.AValue);
            var exp2 = new DatePartsExpression<TestEnum>(TestEnum.BValue);

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
