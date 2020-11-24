using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class Aliasing : ExecutorTestBase
    {
        [Theory]
        [Trait("Operation", "INNER QUERY")]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_dynamic_with_aliased_subquery_result_in_correct_output(int version, int expectedCount = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            int year = 2017;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            var vipStatistics = db.SelectMany(
                dbo.Person.Id.As("PersonId"),
                db.alias("vips", "PurchaseCount").AsInt32(),
                db.alias("vips", "PurchaseYear").AsInt32(),
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName")
            )
            .From(dbo.Person)
            .InnerJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("vips").On(dbo.Person.Id == db.alias("vips", "PersonId").AsInt32())
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                db.alias("vips", "PurchaseCount").AsInt32().Desc
            )
            .Execute();


            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount);
            vipStatistics.Select(x => (int)x.PurchaseYear).Should().OnlyContain(x => x >= year);
        }

        [Theory]
        [Trait("Operation", "INNER QUERY")]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_dynamic_with_adding_PersonId_to_aliased_PurchaseCount_from_aliased_subquery_result_in_correct_output(int version, int expectedCount = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            int year = 2017;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            var vipStatistics = db.SelectMany(
                dbo.Person.Id.As("PersonId"),
                (db.alias("vips", "PurchaseCount").AsInt32() + dbo.Person.Id).As("PurchaseCount"),
                db.alias("vips", "PurchaseYear").AsInt32(),
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName")
            )
            .From(dbo.Person)
            .InnerJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("vips").On(dbo.Person.Id == db.alias("vips", "PersonId").AsInt32())
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                db.alias("vips", "PurchaseCount").AsInt32().Desc
            )
            .Execute();


            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount + 1);
            vipStatistics.Select(x => (int)x.PurchaseYear).Should().OnlyContain(x => x >= year);
        }

        [Theory]
        [Trait("Operation", "INNER QUERY")]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_dynamic_with_adding_PersonYear_to_aliased_PurchaseCount_from_aliased_subquery_result_in_correct_output(int version, int expectedCount = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            int year = 2017;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            var vipStatistics = db.SelectMany(
                dbo.Person.Id.As("PersonId"),
                db.alias("vips", "PurchaseCount").AsInt32(),
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName")
            )
            .From(dbo.Person)
            .InnerJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("vips").On(dbo.Person.Id == db.alias("vips", "PersonId").AsInt32())
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                db.alias("vips", "PurchaseCount").AsInt32().Desc
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount);
        }

        [Theory]
        [Trait("Operation", "INNER QUERY")]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_dynamic_with_multiple_subqueries_and_functions_result_in_correct_output(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            int year = 2017;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            var vipStatistics = db.SelectMany(
                dbo.Person.Id.As("PersonId"),
                db.fx.Coalesce(db.alias("vips", "PurchaseCount").AsNullableInt32(), db.alias("not_vips", "PurchaseCount").AsNullableInt32(), 1).As("PurchaseCount"),
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("vips").On(dbo.Person.Id == db.alias("vips", "PersonId").AsInt32())
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) < purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("not_vips").On(dbo.Person.Id == db.alias("not_vips", "PersonId").AsInt32())
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                db.alias("vips", "PurchaseCount").AsInt32().Desc
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "INNER QUERY")]
        [Trait("Operation", "GROUP BY")]
        [MsSqlVersions.AllVersions]
        public void Can_aliasing_an_alias_result_in_correct_output(int version, int expected = 2)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var vipStatistics = db.SelectOne(
                dbo.Person.Id.As("PersonId"),
                db.alias("vips", "PurchaseCount").AsInt32().As("Result")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId
                )
            ).As("vips").On(dbo.Person.Id == db.alias("vips", "PersonId").AsInt32())
            .Where(db.alias("vips", "PurchaseCount").AsInt32() == expected)
            .Execute();

            //then
            ((int)vipStatistics.Result).Should().Be(expected);
        }
    }
}
