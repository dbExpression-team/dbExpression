using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using Xunit;
using DbExpression.Sql.Expression;
using DbExpression.Sql.Builder;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "COALESCE")]
    public partial class CastAndCoalesceTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_cast_of_coalesce_of_ship_date_and_static_value_to_varchar_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.Coalesce(dbo.Purchase.ShipDate, DateTime.Parse("1/1/2010"))).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_selecting_coalesce_of_cast_of_credit_limit_and_person_id_to_int_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<int>(db.fx.Cast(dbo.Person.CreditLimit).AsInt(), dbo.Person.Id)
                ).From(dbo.Person);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_cast_of_coalesce_of_ship_date_and_null_static_value_to_varchar_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.Coalesce(dbo.Purchase.ShipDate, (DateTime?)null!)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_selecting_coalesce_of_cast_of_credit_limit_and_null_static_value_to_int_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<int?>(db.fx.Cast(dbo.Person.CreditLimit).AsInt(), (int?)null!)
                ).From(dbo.Person);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
