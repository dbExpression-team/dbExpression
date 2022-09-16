using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class StringEnumValueConverterTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [Trait("Configuration", "StringEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_purchase_entities_where_paymentmethodtype_is_paypal_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<Purchase> purchases = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentMethodType == PaymentMethodType.PayPal)
                .Execute();

            //then
            purchases.Should().OnlyContain(x => x.PaymentMethodType == PaymentMethodType.PayPal);
        }

        [Theory]
        [Trait("Configuration", "StringEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_paymentmethodtype_for_purchases_where_paymentmethodtype_is_paypal_succeed(int version, int expectedCount = 5)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<PaymentMethodType> purchases = db.SelectMany(dbo.Purchase.PaymentMethodType)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentMethodType == PaymentMethodType.PayPal)
                .Execute();

            //then
            purchases.Cast<PaymentMethodType>().Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Configuration", "StringEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_paymentmethodtype_to_varchar_for_purchases_where_paymentmethodtype_is_paypal_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<string> purchases = db.SelectMany(db.fx.Cast(dbo.Purchase.PaymentMethodType).AsVarChar(20))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentMethodType == PaymentMethodType.PayPal)
                .Execute();

            //then
            purchases.Should().OnlyContain(x => x == PaymentMethodType.PayPal.ToString());
        }

        [Theory]
        [Trait("Configuration", "StringEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_paymentmethodtype_for_purchases_where_cast_of_paymentmethodtype_as_varchar_is_paypal_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<PaymentMethodType> purchases = db.SelectMany(dbo.Purchase.PaymentMethodType)
                .From(dbo.Purchase)
                .Where(db.fx.Cast(dbo.Purchase.PaymentMethodType).AsVarChar(20) == PaymentMethodType.PayPal.ToString())
                .Execute();

            //then
            purchases.Should().OnlyContain(x => x == PaymentMethodType.PayPal);
        }

        [Theory]
        [Trait("Configuration", "StringEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_update_paymentmethodtype_for_purchases_where_paymentmethodtype_is_paypal_succeed(int version, int expectedCount = 9)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            db.Update(dbo.Purchase.PaymentMethodType.Set(PaymentMethodType.ACH))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentMethodType == PaymentMethodType.PayPal)
                .Execute();

            //then
            var current = db.SelectOne(db.fx.Count(dbo.Purchase.Id)).From(dbo.Purchase).Where(dbo.Purchase.PaymentMethodType == PaymentMethodType.ACH).Execute();

            current.Should().Be(expectedCount);
        }


        [Theory]
        [Trait("Configuration", "StringEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_paymentsourcetype_where_paymentsourcetype_is_null_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<PaymentSourceType> sources = db.SelectMany(db.fx.Coalesce(dbo.Purchase.PaymentSourceType, PaymentSourceType.Web))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentSourceType == dbex.Null)
                .Execute();

            //then
            sources.Should().OnlyContain(x => x == PaymentSourceType.Web);
        }

        [Theory]
        [Trait("Configuration", "StringEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_paymentsourcetype_where_paymentsourcetype_is_null_or_in_web_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<PaymentSourceType> sources = db.SelectMany(db.fx.Coalesce(dbo.Purchase.PaymentSourceType, PaymentSourceType.Web))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentSourceType == dbex.Null | dbo.Purchase.PaymentSourceType.In(PaymentSourceType.Web))
                .Execute();

            //then
            sources.Should().OnlyContain(x => x == PaymentSourceType.Web);
        }

        [Theory]
        [Trait("Configuration", "StringEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_paymentsourcetype_where_paymentsourcetype_is_null_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            IList<PaymentSourceType> sources = db.SelectMany(db.fx.IsNull(dbo.Purchase.PaymentSourceType, PaymentSourceType.Web))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentSourceType == dbex.Null)
                .Execute();

            //then
            sources.Should().OnlyContain(x => x == PaymentSourceType.Web);
        }
    }
}
