using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class StringFieldExpressionTests : ExecutorTestBase
    {
        [Theory]
        [Trait("Operation", "LIKE")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_like_firstname_succeed(int version, int expected = 3)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    dbo.Person.FirstName
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName.Like("Bill%"));

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "LIKE")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_like_firstname_concatenated_with_lastname_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    dbo.Person.FirstName
                ).From(dbo.Person)
                .Where((dbo.Person.FirstName + " " + dbo.Person.LastName).Like("David W%"));

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "LIKE")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_like_of_address_line2_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbo.Address.Line2.Like("Box%"));

            //when               
            IList<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "LIKE")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_like_address_line1_concatenated_with_address_line2_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where((dbo.Address.Line1 + " " + dbo.Address.Line2).Like("US Highway 285 Box%"));

            //when               
            IList<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_concatenated_address_fields_succeed(int version, int id = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_selecting_many_address_line2_where_null_succeed(int version, int expected = 27)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            IList<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_many_address_line2_where_null_reversed_filter_order_succeed(int version, int expected = 27)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbex.Null == dbo.Address.Line2);

            //when               
            IList<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_many_address_line2_where_not_null_succeed(int version, int expected = 5)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 != dbex.Null);

            //when               
            IList<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_many_address_line2_where_not_null_reversed_filter_order_succeed(int version, int expected = 5)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbex.Null != dbo.Address.Line2);

            //when               
            IList<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_one_address_line2_where_not_null_reversed_filter_order_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    dbo.Address.Line2
                ).From(dbo.Address)
                .Where(dbex.Null != dbo.Address.Line2);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_one_address_line1_where_not_null_reversed_filter_order_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
