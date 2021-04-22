using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "MAX")]
    public partial class IsNullAndMaximum : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_isnull_of_credit_limit_and_max_of_quantity_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Person.CreditLimit, db.fx.Max(dbo.PurchaseLine.Quantity))
                ).From(dbo.PurchaseLine)
                .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
                .InnerJoin(dbo.Person).On(dbo.Person.Id == dbo.Purchase.PersonId)
                .GroupBy(dbo.Person.CreditLimit);

            //when               
            int result = exp.Execute();

            //then
            result.Should().BeGreaterThan(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_max_of_isnull_of_credit_limit_and_quantity_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.IsNull(dbo.Person.CreditLimit, dbo.PurchaseLine.Quantity))
                ).From(dbo.PurchaseLine)
                .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
                .InnerJoin(dbo.Person).On(dbo.Person.Id == dbo.Purchase.PersonId);

            //when               
            int result = exp.Execute();

            //then
            result.Should().BeGreaterThan(0);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_isnull_of_ship_date_and_max_of_expected_delivery_date_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, db.fx.Max(dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != DBNull.Value)
                .GroupBy(dbo.Purchase.ShipDate);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().BeAfter(DateTime.MinValue);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_max_of_isnull_of_ship_date_and_expected_delivery_date_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
        }
    }
}
