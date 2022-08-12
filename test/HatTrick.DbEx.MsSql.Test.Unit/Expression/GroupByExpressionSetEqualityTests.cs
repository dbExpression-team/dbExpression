using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class GroupByExpressionSetEqualityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void GroupBy_expressions_of_same_values_should_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            
            var exp1 = new GroupByExpressionSet(dbo.Person.CreditLimit);
            var exp2 = new GroupByExpressionSet(dbo.Person.CreditLimit);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void GroupBy_expressions_of_different_values_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp1 = new GroupByExpressionSet(dbo.Person.CreditLimit);
            var exp2 = new GroupByExpressionSet(dbo.Person.Id);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void GroupBy_expressions_of_with_different_number_of_values_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp1 = new GroupByExpressionSet(dbo.Person.CreditLimit, dbo.Person.Id);
            var exp2 = new GroupByExpressionSet(dbo.Person.Id);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void GroupBy_expressions_of_with_same_number_of_values_in_different_order_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp1 = new GroupByExpressionSet(dbo.Person.CreditLimit, dbo.Person.Id);
            var exp2 = new GroupByExpressionSet(dbo.Person.Id, dbo.Person.CreditLimit);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void GroupBy_expressions_of_same_values_should_have_same_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp1 = new GroupByExpressionSet(dbo.Person.CreditLimit);
            var exp2 = new GroupByExpressionSet(dbo.Person.CreditLimit);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void GroupBy_expressions_of_different_values_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp1 = new GroupByExpressionSet(dbo.Person.CreditLimit);
            var exp2 = new GroupByExpressionSet(dbo.Person.Id);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void GroupBy_expressions_of_with_different_number_of_values_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp1 = new GroupByExpressionSet(dbo.Person.CreditLimit, dbo.Person.Id);
            var exp2 = new GroupByExpressionSet(dbo.Person.CreditLimit);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void GroupBy_expressions_of_with_same_number_of_values_in_different_order_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp1 = new GroupByExpressionSet(dbo.Person.CreditLimit, dbo.Person.Id);
            var exp2 = new GroupByExpressionSet(dbo.Person.Id, dbo.Person.CreditLimit);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
