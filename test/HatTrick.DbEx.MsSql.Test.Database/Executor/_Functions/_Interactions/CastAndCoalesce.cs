using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Builder;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "CAST")]
    [Trait("Function", "COALESCE")]
    public partial class CastAndCoalesce : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_coalesce_of_ship_date_and_static_value_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.Coalesce(dbo.Purchase.ShipDate, DateTime.Parse("1/1/2010"))).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_cast_of_credit_limit_and_person_id_to_int_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce<int>(db.fx.Cast(dbo.Person.CreditLimit).AsInt(), dbo.Person.Id)
                ).From(dbo.Person);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_coalesce_of_ship_date_and_null_static_value_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.Coalesce(dbo.Purchase.ShipDate, (DateTime?)null!)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_cast_of_credit_limit_and_null_static_value_to_int_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce<int?>(db.fx.Cast(dbo.Person.CreditLimit).AsInt(), (int?)null!)
                ).From(dbo.Person);

            //when               
            IList<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
