using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class HavingExpressionEqualityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_of_same_values_should_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit > 1);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_of_different_values_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit > 2);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_of_same_values_and_different_operators_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit < 1);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_with_same_values_and_same_logical_operators_should_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_with_same_values_and_different_logical_operators_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit > 1 | dbo.Person.Id == 1);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_of_same_values_should_have_same_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit > 1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_of_different_values_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit > 2);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_of_same_values_and_different_operators_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit < 1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_with_same_values_and_same_logical_operators_should_have_same_hash_code(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Having_expressions_with_same_values_and_different_logical_operators_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new HavingExpression(dbo.Person.CreditLimit > 1 & dbo.Person.Id == 1);
            var exp2 = new HavingExpression(dbo.Person.CreditLimit > 1 | dbo.Person.Id == 1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
