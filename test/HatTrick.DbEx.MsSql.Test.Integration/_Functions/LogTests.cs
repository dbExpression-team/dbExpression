using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Builder.Alias;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LOG")]
    public partial class LogTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_of_total_purchase_quantity_succeed(int version, float expected = 0f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.Id)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_of_total_purchase_amount_succeed(int version, float expected = 3.331f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.Purchase.TotalPurchaseAmount).As("amount")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 2);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_of_purchase_price_succeed(int version, float expected = 2.055f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.PurchasePrice)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_with_literal_base_value_of_total_purchase_quantity_succeed(int version, float expected = 0f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.Id, 2)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_with_literal_base_value_of_total_purchase_amount_succeed(int version, float expected = 4.806f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.Purchase.TotalPurchaseAmount, 2).As("amount")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 2);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_with_literal_base_value_of_purchase_price_succeed(int version, float expected = 2.055f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.PurchasePrice)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_with_base_of_total_purchase_quantity_succeed(int version, float expected = 1f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.Id, dbo.PurchaseLine.Id)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 9);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_with_base_of_total_purchase_amount_succeed(int version, float expected = 0.886f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.Purchase.TotalPurchaseAmount, dbo.Purchase.Id).As("amount")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 9);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_log_with_base_of_purchase_price_succeed(int version, float expected = 0.967f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.PurchasePrice, dbo.PurchaseLine.Id)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 9);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_log_of_aliased_field_succeed(int version, float expected = 1.443f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .Where(dbo.PurchaseLine.Id == 1)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_log_of_aliased_field_with_literal_value_for_base_succeed(int version, float expected = 2.965f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Log(("lines", "PurchasePrice"), 2).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .Where(dbo.PurchaseLine.Id == 1)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }
    }
}
