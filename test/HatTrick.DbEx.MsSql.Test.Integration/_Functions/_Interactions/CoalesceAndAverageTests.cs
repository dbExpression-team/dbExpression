using DbEx.Data;
using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "COALESCE")]
    [Trait("Function", "AVG")]
    public partial class CoalesceAndAverageTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_average_of_credit_limit_and_static_value_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce<int>(db.fx.Avg(dbo.Person.CreditLimit), 1)
                ).From(dbo.Person);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_coalesce_of_average_of_credit_limit_and_credit_limit_succeed(int version, int expected = 5)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce<int?>(db.fx.Avg(dbo.Person.CreditLimit), dbo.Person.CreditLimit)
                ).From(dbo.Person)
                .GroupBy(dbo.Person.CreditLimit);

            //when               
            IList<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_coalesce_of_average_of_credit_limit_and_person_id_succeed(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce<int?>(db.fx.Avg(dbo.Person.CreditLimit), dbo.Person.Id)
                ).From(dbo.Person)
                .GroupBy(dbo.Person.Id);

            //when               
            IList<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_average_of_coalesce_of_credit_limit_and_credit_limit_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Avg(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, dbo.Person.CreditLimit))
                ).From(dbo.Person);

            //when               
            IList<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
