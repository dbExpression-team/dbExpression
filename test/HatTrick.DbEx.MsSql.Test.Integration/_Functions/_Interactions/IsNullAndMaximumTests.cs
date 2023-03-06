using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "MAX")]
    public partial class IsNullAndMaximumTests : ResetDatabaseNotRequired
    {
        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_isnull_of_credit_limit_and_max_of_quantity_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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

        [Fact]
        public void Does_selecting_max_of_isnull_of_credit_limit_and_quantity_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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


        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_isnull_of_ship_date_and_max_of_expected_delivery_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, db.fx.Max(dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .GroupBy(dbo.Purchase.ShipDate);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().BeAfter(DateTime.MinValue);
        }

        [Fact]
        public void Does_selecting_max_of_isnull_of_ship_date_and_expected_delivery_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
