using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Microsoft.SqlServer.Management.Smo;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database
{
    public class Random : ExecutorTestBase
    {
        [Theory]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "DISTINCT")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_result_in_valid_expression(int version, int expected = 17)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var persons = db.SelectMany(
                    dbo.Person.Id.As("foo"),
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    db.fx.Count(dbo.PersonAddress.Id).As("person_count")
                ).Distinct()
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .GroupBy(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .Having(
                    db.fx.Count(dbo.PersonAddress.Id) > 1
                )
                .OrderBy(
                    dbo.Person.LastName,
                    dbo.Person.FirstName.Desc
                )
                .Execute();

            //then
            persons.Count().Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_dynamic_objects_result_in_correct_output(int version, int expectedCount = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            int year = 2017;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            //when
            var vipStatistics = db.SelectMany(
                db.fx.Count(dbo.Purchase.PurchaseDate).As("PurchaseCount")
            )
            .From(dbo.Purchase)
            .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
            .OrderBy(
                db.fx.Count(dbo.Purchase.PurchaseDate).Asc
            )
            .GroupBy(
                dbo.Person.Id,
                (dbo.Person.FirstName + " " + dbo.Person.LastName),
                db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
            )
            .Having(
                db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Should().OnlyContain(x => x >= 3);
        }
    }
}
