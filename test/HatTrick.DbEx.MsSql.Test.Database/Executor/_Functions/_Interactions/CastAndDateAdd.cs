using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "CAST")]
    [Trait("Function", "DATEADD")]
    public partial class CastAndDateAdd : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_dateadd_of_shipdate_as_varchar_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_to_cast_of_personId_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, 1, db.fx.Cast(dbo.Person.Id).AsDateTime())
                ).From(dbo.Person);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_to_cast_of_credit_limit_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, db.fx.Cast(dbo.Person.CreditLimit).AsDateTime())
                ).From(dbo.Person)
                .Where(dbo.Person.CreditLimit == DBNull.Value);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().BeNull();
        }
    }
}
