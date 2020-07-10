using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class NullableGuidFieldExpression : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Are_there_3_purchase_records_with_null_tracking_identifier(int version, int expected = 11)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Purchase.TrackingIdentifier)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.TrackingIdentifier == DBNull.Value);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
            purchases.All( x => x == null).Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Doas_a_purchase_record_with_null_tracking_identifier_select_successfully(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Purchase.TrackingIdentifier)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.TrackingIdentifier == DBNull.Value);

            //when               
            var purchase = exp.Execute();

            //then
            purchase.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "UPDATE")]
        public void Can_update_a_purchase_record_with_null_tracking_identifier_to_new_id_function(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(dbo.Purchase.TrackingIdentifier.Set(db.fx.NewId()))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.TrackingIdentifier == DBNull.Value);

            //when               
            exp.Execute();

            //then
            db.SelectOne(db.fx.Count()).From(dbo.Purchase).Where(dbo.Purchase.TrackingIdentifier != DBNull.Value).Execute().Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "UPDATE")]
        public void Can_update_a_purchase_record_with_null_tracking_identifier_to_generated_guid(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(dbo.Purchase.TrackingIdentifier.Set(Guid.NewGuid()))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.TrackingIdentifier == DBNull.Value);

            //when               
            exp.Execute();

            //then
            db.SelectOne(db.fx.Count()).From(dbo.Purchase).Where(dbo.Purchase.TrackingIdentifier != DBNull.Value).Execute().Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "INSERT")]
        public void Can_insert_a_purchase_record_with_null_tracking_identifier(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Insert(
                new Purchase 
                { 
                    PersonId = 1,
                    PurchaseDate = DateTime.Now,
                    ShipDate = DateTime.Now,
                    TrackingIdentifier = null,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                })
                .Into(dbo.Purchase);

            //when               
            exp.Execute();
        }
    }
}
