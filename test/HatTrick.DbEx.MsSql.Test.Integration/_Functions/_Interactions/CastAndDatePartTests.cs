using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "DATEPART")]
    public partial class CastAndDatePartTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_year_datepart_of_shipdate_as_varchar_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_year_datepart_of_and_cast_of_personId_succeed(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DatePart(DateParts.Year, db.fx.Cast(dbo.Person.Id).AsDateTime())
                ).From(dbo.Person);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
