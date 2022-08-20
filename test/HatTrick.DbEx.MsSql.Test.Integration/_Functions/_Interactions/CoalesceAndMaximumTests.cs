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
    [Trait("Function", "COALESCE")]
    [Trait("Function", "MAX")]
    public partial class CoalesceAndMaximumTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_max_of_credit_limit_and_static_value_succeed(int version, int expected = 40000)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.Max(dbo.Person.CreditLimit), 1)
                ).From(dbo.Person);

            //when               
            object? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_coalesce_of_max_of_credit_limit_and_person_id_succeed(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.Max(dbo.Person.CreditLimit), dbo.Person.Id)
                ).From(dbo.Person)
                .GroupBy(dbo.Person.Id);

            //when               
            IList<object?> result = exp.Execute();

            //then
            result.Should().HaveCount(expected);
        }

        
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_max_of_coalesce_of_quantity_and_static_value_succeed(int version, int expected = 40000)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.Coalesce<int>(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_max_of_coalesce_of_quantity_and_person_id_succeed(int version, int expected = 40000)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.Coalesce<int>(dbo.Person.CreditLimit, dbo.Person.Id))
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_max_of_coalesce_of_quantity_and_year_of_last_credit_limit_review_succeed(int version, int expected = 40000)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
