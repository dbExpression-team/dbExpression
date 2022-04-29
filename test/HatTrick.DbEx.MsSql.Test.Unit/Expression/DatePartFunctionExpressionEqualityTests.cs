using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Expression
{
    public class DatePartFunctionExpressionEqaulityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void DatePart_functions_of_purchase_date_should_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate);
            var exp2 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void DatePart_functions_of_purchase_date_with_one_aliased_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate);
            var exp2 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("foo");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void DatePart_functions_of_purchase_date_should_have_same_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate);
            var exp2 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void DatePart_functions_of_purchase_date_with_one_aliased_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate);
            var exp2 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("foo");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void DatePart_functions_of_purchase_date_with_different_date_part_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = db.fx.DatePart(DateParts.Day, dbo.Purchase.PurchaseDate);
            var exp2 = db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
