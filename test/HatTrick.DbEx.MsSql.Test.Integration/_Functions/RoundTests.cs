using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Builder.Alias;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "ROUND")]
    public partial class RoundTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_round_of_product_shipping_weight_and_static_length_and_no_function_succeed(int version, decimal expected = 1m)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Round(dbo.Product.ShippingWeight, 0)
                ).From(dbo.Product)
                .Where(dbo.Product.ShippingWeight > 1.01m & dbo.Product.ShippingWeight < 1.5m);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_round_of_product_shipping_weight_and_field_for_length_and_no_function_succeed(int version, decimal expected = 1.5m)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Round(dbo.Product.ShippingWeight, dbo.Product.Id)
                ).From(dbo.Product)
                .Where(dbo.Product.Id == 1);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_round_of_product_shipping_weight_and_static_value_for_length_and_static_value_for_function_succeed(int version, decimal expected = 1m)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Round(dbo.Product.ShippingWeight, 0, 1)
                ).From(dbo.Product)
                .Where(dbo.Product.Id == 1);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_round_of_product_shipping_weight_and_field_for_length_and_static_value_for_function_succeed(int version, decimal expected = 1.5m)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Round(dbo.Product.ShippingWeight, dbo.Product.Id, 1)
                ).From(dbo.Product)
                .Where(dbo.Product.Id == 1);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_round_of_product_shipping_weight_and_field_for_length_and_field_for_function_succeed(int version, decimal expected = 1.5m)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Round(dbo.Product.ShippingWeight, dbo.Product.Id, dbo.Product.Id)
                ).From(dbo.Product)
                .Where(dbo.Product.Id == 1);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_round_of_aliased_field_succeed(int version, decimal expected = 1.5m)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Round(("_product", "ShippingWeight"), 1).As("shipping_weight")
                ).From(dbo.Product)
                .InnerJoin(
                    db.SelectOne<Product>()
                    .From(dbo.Product)
                    .Where(dbo.Product.Id == 1)
                ).As("_product").On(dbo.Product.Id == ("_product", "Id"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<decimal>().Which.Should().Be(expected);
        }
    }
}
