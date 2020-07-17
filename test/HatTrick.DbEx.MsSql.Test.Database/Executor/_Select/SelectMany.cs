using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectMany : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Are_there_50_person_records(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Are_there_50_person_records_async(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Are_there_15_purchase_records(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Purchase>()
               .From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_retrieve_page_of_purchase_records(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Purchase.PersonId)
                .Distinct()
                .From(dbo.Purchase)
                .Skip(5)
                .Limit(1000)
                .OrderBy(dbo.Purchase.PersonId);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "DISTINCT")]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_for_single_field_result_in_valid_expression(int version, int expected = 17)
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
            persons.Count(p => p.person_count == 2).Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_multiple_fields_and_mapping_to_dynamic_fail_when_alias_is_not_provided(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            Action execute = () => db.SelectMany(
                    dbo.Purchase.Id,
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .Execute();

            //when & then
            execute.Should().Throw<DbExpressionException>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Does_selecting_multiple_fields_and_mapping_to_dynamic_fail_when_alias_is_not_provided_using_async(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            Func<Task> execute = () => db.SelectMany(
                    dbo.Purchase.Id,
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .ExecuteAsync();

            //when & then
            await execute.Should().ThrowAsync<DbExpressionException>();
        }
    }
}
