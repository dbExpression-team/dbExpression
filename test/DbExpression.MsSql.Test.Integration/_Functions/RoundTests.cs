using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Builder.Alias;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "ROUND")]
    public partial class RoundTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(1)]
        public void Does_round_of_product_shipping_weight_and_static_length_and_no_function_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData(1.5)]
        public void Does_round_of_product_shipping_weight_and_field_for_length_and_no_function_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData(1)]
        public void Does_round_of_product_shipping_weight_and_static_value_for_length_and_static_value_for_function_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData(1.5)]
        public void Does_round_of_product_shipping_weight_and_field_for_length_and_static_value_for_function_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData(1.5)]
        public void Does_round_of_product_shipping_weight_and_field_for_length_and_field_for_function_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "SUBQUERY")]
        [InlineData(1.5)]
        public void Does_round_of_aliased_field_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
