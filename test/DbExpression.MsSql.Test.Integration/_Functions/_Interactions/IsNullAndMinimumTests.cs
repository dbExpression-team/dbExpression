using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "MIN")]
    public partial class IsNullAndMinimumTests : ResetDatabaseNotRequired
    {
        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_isnull_of_credit_limit_and_min_of_quantity_and_static_value_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Person.CreditLimit, db.fx.Min(dbo.PurchaseLine.Quantity))
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
        public void Does_selecting_min_of_isnull_of_credit_limit_and_quantity_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.IsNull(dbo.Person.CreditLimit, dbo.PurchaseLine.Quantity))
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
        public void Does_selecting_isnull_of_ship_date_and_min_of_expected_delivery_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, db.fx.Min(dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .GroupBy(dbo.Purchase.ShipDate);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().BeAfter(DateTime.MinValue);
        }

        [Fact]
        public void Does_selecting_min_of_isnull_of_ship_date_and_expected_delivery_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
        }
    }
}
