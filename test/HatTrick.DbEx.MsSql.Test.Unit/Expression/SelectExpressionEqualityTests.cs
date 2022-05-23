using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class SelectExpressionSetEqualityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Select_expressions_of_same_fields_should_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new SelectExpression<int>(dbo.Person.Id);
            var exp2 = new SelectExpression<int>(dbo.Person.Id);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Select_expressions_of_different_fields_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new SelectExpression<int?>(dbo.Person.CreditLimit);
            var exp2 = new SelectExpression<int?>(dbo.Person.YearOfLastCreditLimitReview);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Select_expressions_with_same_fields_and_same_alias_should_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new SelectExpression<int?>(dbo.Person.CreditLimit).As("this");
            var exp2 = new SelectExpression<int?>(dbo.Person.CreditLimit).As("this");

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Select_expressions_with_same_fields_and_one_alias_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new SelectExpression<int?>(dbo.Person.CreditLimit).As("this");
            var exp2 = new SelectExpression<int?>(dbo.Person.CreditLimit);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Select_expressions_of_same_fields_should_have_same_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new SelectExpression<int>(dbo.Person.Id);
            var exp2 = new SelectExpression<int>(dbo.Person.Id);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Select_expressions_of_different_fields_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new SelectExpression<int?>(dbo.Person.CreditLimit);
            var exp2 = new SelectExpression<int?>(dbo.Person.YearOfLastCreditLimitReview);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Select_expressions_with_same_fields_and_one_alias_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new SelectExpression<int?>(dbo.Person.CreditLimit).As("this");
            var exp2 = new SelectExpression<int?>(dbo.Person.CreditLimit);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Select_expressions_with_same_fields_and_same_alias_should_have_same_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new SelectExpression<int?>(dbo.Person.CreditLimit).As("this");
            var exp2 = new SelectExpression<int?>(dbo.Person.CreditLimit).As("this");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }
    }
}
