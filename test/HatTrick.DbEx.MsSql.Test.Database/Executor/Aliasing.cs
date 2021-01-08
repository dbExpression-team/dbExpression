using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using Xunit;
using System;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class Aliasing : ExecutorTestBase
    {
        [Theory]
        [Trait("Operation", "SUBQUERY")]
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
                dbex.alias("vips", "PurchaseCount"),
                dbex.alias("vips", "PurchaseYear"),
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
            ).As("vips").On(dbo.Person.Id == dbex.alias("vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                dbex.alias("vips", "PurchaseCount").Desc
            )
            .Execute();


            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount);
            vipStatistics.Select(x => (int)x.PurchaseYear).Should().OnlyContain(x => x >= year);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
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
                (dbex.alias("vips", "PurchaseCount") + dbo.Person.Id).As("PurchaseCount"),
                dbex.alias("vips", "PurchaseYear"),
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
            ).As("vips").On(dbo.Person.Id == dbex.alias("vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                dbex.alias("vips", "PurchaseCount").Desc
            )
            .Execute();


            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount + 1);
            vipStatistics.Select(x => (int)x.PurchaseYear).Should().OnlyContain(x => x >= year);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
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
                dbex.alias("vips", "PurchaseCount"),
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
            ).As("vips").On(dbo.Person.Id == dbex.alias("vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                dbex.alias("vips", "PurchaseCount").Desc
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
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
                db.fx.Coalesce(dbex.alias("vips", "PurchaseCount"), dbex.alias("not_vips", "PurchaseCount"), 1).As("PurchaseCount"),
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
            ).As("vips").On(dbo.Person.Id == dbex.alias("vips", "PersonId"))
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
            ).As("not_vips").On(dbo.Person.Id == dbex.alias("not_vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                dbex.alias("vips", "PurchaseCount").Desc
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [Trait("Operation", "GROUP BY")]
        [MsSqlVersions.AllVersions]
        public void Can_aliasing_an_alias_result_in_correct_output(int version, int expected = 2)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var vipStatisticsq = db.SelectOne(
                dbo.Person.Id.As("PersonId"),
                dbex.alias("vips", "PurchaseCount").As("Result")
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
            ).As("vips").On(dbo.Person.Id == dbex.alias("vips", "PersonId"))
            .Where(dbex.alias("vips", "PurchaseCount") == expected);

            var vipStatistics = vipStatisticsq
            .Execute();

            //then
            ((int)vipStatistics.Result).Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [MsSqlVersions.AllVersions]
        public void Can_aliased_subquery_result_in_correct_counts_for_dynamic_return(int version, int personCount = 50, int addressCount = 17)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var persons = db.SelectMany(
                dbo.Person.Id,
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("CustomerName"),
                (dbex.alias("person_address", "Id") + 2).As("AddressId")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.PersonAddress.PersonId,
                    dbo.Address.Id
                )
                .From(dbo.Address)
                .InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
                .Where(dbo.Address.AddressType == AddressType.Mailing)
            ).As("person_address").On(dbex.alias("person_address", "PersonId") == dbo.Person.Id)
            .Execute();

            //then
            persons.Should().HaveCount(personCount);
            persons.Where(x => ((int?)x.AddressId).HasValue).Should().HaveCount(addressCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [MsSqlVersions.AllVersions]
        public void Can_aliased_subquery_result_in_correct_counts_for_value_return(int version, int personCount = 50, int addressCount = 17)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var persons = db.SelectMany(
                dbex.alias("person_address", "Id").As("Foo")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.PersonAddress.PersonId,
                    dbo.Address.Id
                )
                .From(dbo.Address)
                .InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
                .Where(dbo.Address.AddressType == AddressType.Mailing)
            ).As("person_address").On(dbex.alias("person_address", "PersonId") == dbo.Person.Id)
            .Execute();

            //then
            persons.Should().HaveCount(personCount);
            persons.Where(x => ((int?)x).HasValue).Should().HaveCount(addressCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [MsSqlVersions.AllVersions]
        public void Can_aliased_subquery_result_in_correct_counts_for_entity_return(int version, int personCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var persons = db.SelectMany<Person>()
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.PersonAddress.PersonId,
                    dbo.Address.Id
                )
                .From(dbo.Address)
                .InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
                .Where(dbo.Address.AddressType == AddressType.Mailing)
            ).As("person_address").On(dbex.alias("person_address", "PersonId") == dbo.Person.Id)
            .Execute();

            //then
            persons.Should().HaveCount(personCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [MsSqlVersions.AllVersions]
        public void Can_aliased_subqueries_result_in_correct_counts_for_coalesced_value_return(int version, int count = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            IList<object> values = db.SelectMany(
                db.fx.Coalesce(dbex.alias("vips", "PurchaseCount"), dbex.alias("not_vips", "PurchaseCount"), 1).As("PurchaseCount")
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
                ).Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                )
            ).As("vips").On(dbo.Person.Id == dbex.alias("vips", "PersonId"))
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
                ).Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) < purchaseCount
                )
            ).As("not_vips").On(dbo.Person.Id == dbex.alias("not_vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                dbex.alias("vips", "PurchaseCount").Desc
            )
            .Execute();

            //then
            values.Should().HaveCount(count);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [MsSqlVersions.AllVersions]
        public void Can_aliased_subqueries_result_in_correct_counts_for_coalesced_value_using_custom_mapping_in_execute(int version, int count = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            var values = db.SelectMany(
                dbo.Person.Id,
                db.fx.Coalesce(dbex.alias("vips", "PurchaseCount"), dbex.alias("not_vips", "PurchaseCount"), int.MinValue)
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
                ).Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                )
            ).As("vips").On(dbo.Person.Id == dbex.alias("vips", "PersonId"))
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
                ).Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) < purchaseCount
                )
            ).As("not_vips").On(dbo.Person.Id == dbex.alias("not_vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc,
                dbex.alias("vips", "PurchaseCount").Desc
            )
            .Execute(row =>
                {
                    dynamic o = new ExpandoObject();
                    o.Id = row.ReadField().GetValue<int>();
                    o.Count = row.ReadField().GetValue<int>();
                    return o;
                });

            //then
            values.Should().HaveCount(count);
        }
    }
}
