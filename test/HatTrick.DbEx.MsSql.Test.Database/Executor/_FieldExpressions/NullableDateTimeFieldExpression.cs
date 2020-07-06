﻿using DbEx.Data.dbo;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class NullableDateTimeFieldExpression : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Are_there_3_purchase_records_with_null_ship_date(int version, int expected = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Purchase.ShipDate)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == DBNull.Value);

            //when               
            var shipDates = exp.Execute();

            //then
            shipDates.Should().HaveCount(expected);
            shipDates.All( x => x == null).Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Are_there_3_purchase_records_with_null_ship_date_using_isnull_method(int version, int expected = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Purchase.ShipDate)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate.IsNull());

            //when               
            var shipDates = exp.Execute();

            //then
            shipDates.Should().HaveCount(expected);
            shipDates.All(x => x == null).Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Are_there_12_purchase_records_with_not_null_ship_date(int version, int expected = 12)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Purchase.ShipDate)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != DBNull.Value);

            //when               
            var shipDates = exp.Execute();

            //then
            shipDates.Should().HaveCount(expected);
            shipDates.All(x => x == null).Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Are_there_12_purchase_records_with_null_ship_date_using_isnotnull_method(int version, int expected = 12)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Purchase.ShipDate)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate.IsNotNull());

            //when               
            var shipDates = exp.Execute();

            //then
            shipDates.Should().HaveCount(expected);
            shipDates.All(x => x == null).Should().BeFalse();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public void Doas_a_purchase_record_with_null_ship_date_select_successfully(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Purchase.ShipDate)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == DBNull.Value);

            //when               
            var shipDate = exp.Execute();

            //then
            shipDate.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "UPDATE")]
        public void Can_update_a_purchase_record_with_null_ship_date_to_get_date_function(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(dbo.Purchase.ShipDate.Set(db.fx.GetDate()))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == DBNull.Value);

            //when               
            exp.Execute();

            //then
            db.SelectOne(db.fx.Count()).From(dbo.Purchase).Where(dbo.Purchase.ShipDate != DBNull.Value).Execute().Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "UPDATE")]
        public void Can_update_a_purchase_record_with_null_ship_date_to_current_date(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(dbo.Purchase.ShipDate.Set(DateTime.Now))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == DBNull.Value);

            //when               
            exp.Execute();

            //then
            db.SelectOne(db.fx.Count()).From(dbo.Purchase).Where(dbo.Purchase.ShipDate != DBNull.Value).Execute().Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "INSERT")]
        public void Can_insert_a_purchase_record_with_null_ship_date(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Insert(
                new Purchase 
                { 
                    PersonId = 1,
                    PurchaseDate = DateTime.Now,
                    ShipDate = null,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                })
                .Into(dbo.Purchase);

            //when               
            exp.Execute();
        }
    }
}
