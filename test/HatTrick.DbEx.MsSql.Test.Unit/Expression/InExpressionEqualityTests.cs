using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Expression
{
    public class InExpressionSetEqualityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void In_expressions_of_same_values_should_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = dbo.Person.CreditLimit.In(1, 2, 3, 4);
            var exp2 = dbo.Person.CreditLimit.In(1, 2, 3, 4);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void In_expressions_of_different_values_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = dbo.Person.CreditLimit.In(1, 2, 3, 4);
            var exp2 = dbo.Person.CreditLimit.In(1, 2, 3, 5);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void In_expressions_of_same_values_in_different_order_should_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = dbo.Person.CreditLimit.In(1, 2, 3, 4);
            var exp2 = dbo.Person.CreditLimit.In(4, 3, 2, 1);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void In_expressions_of_same_values_should_have_same_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = dbo.Person.CreditLimit.In(1, 2, 3, 4);
            var exp2 = dbo.Person.CreditLimit.In(1, 2, 3, 4);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void In_expressions_of_different_values_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = dbo.Person.CreditLimit.In(1, 2, 3, 4);
            var exp2 = dbo.Person.CreditLimit.In(1, 2, 3, 5);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void In_expressions_of_same_values_in_different_order_should_have_same_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = dbo.Person.CreditLimit.In(1, 2, 3, 4);
            var exp2 = dbo.Person.CreditLimit.In(4, 3, 2, 1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }
    }
}
