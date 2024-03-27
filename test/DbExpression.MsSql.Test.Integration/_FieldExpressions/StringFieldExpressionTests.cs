using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public class StringFieldExpressionTests : ResetDatabaseNotRequired
    {
        [Theory]
        [Trait("Operation", "LIKE")]
        [InlineData(3)]
        public void Does_selecting_like_firstname_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.FirstName
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName.Like("Bill%"));

            //when               
            IEnumerable<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "LIKE")]
        [InlineData(1)]
        public void Does_selecting_like_firstname_concatenated_with_lastname_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.FirstName
                ).From(dbo.Person)
                .Where((dbo.Person.FirstName + " " + dbo.Person.LastName).Like("David W%"));

            //when               
            IEnumerable<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "LIKE")]
        [InlineData(1)]
        public void Does_selecting_like_of_address_line2_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbo.Address.Line2.Like("Box%"));

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "LIKE")]
        [InlineData(1)]
        public void Does_selecting_like_address_line1_concatenated_with_address_line2_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where((dbo.Address.Line1 + " " + dbo.Address.Line2).Like("US Highway 285 Box%"));

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_concatenated_address_fields_succeed(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    dbo.Address.Line1 + " " + db.fx.IsNull(dbo.Address.Line2, string.Empty)
                    + Environment.NewLine
                    + dbo.Address.City + ", " + dbo.Address.State + " " + dbo.Address.Zip
                ).From(dbo.Address)
                .Where(dbo.Address.Id == id);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be($"100 1st St Principal's office{Environment.NewLine}South Park, CO 80456");
        }

        [Theory]
        [InlineData(27)]
        public void Does_selecting_many_address_line2_where_null_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(27)]
        public void Does_selecting_many_address_line2_where_null_reversed_filter_order_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbex.Null == dbo.Address.Line2);

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(5)]
        public void Does_selecting_many_address_line2_where_not_null_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 != dbex.Null);

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(5)]
        public void Does_selecting_many_address_line2_where_not_null_reversed_filter_order_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbex.Null != dbo.Address.Line2);

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Fact]
        public void Does_selecting_one_address_line2_where_not_null_reversed_filter_order_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbex.Null != dbo.Address.Line2);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().NotBeNull();
        }

        [Fact]
        public void Does_selecting_one_address_line1_where_not_null_reversed_filter_order_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    dbo.Address.Line1.As("foo")
                ).From(dbo.Address)
                .Where(dbex.Null != dbo.Address.Line1);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().NotBeNull();
        }
    }
}
