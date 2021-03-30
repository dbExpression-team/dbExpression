using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
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
                .OrderBy(dbo.Purchase.PersonId)
                .Offset(5)
                .Limit(1000);

            //when               
            var ids = exp.Execute();

            //then
            ids.Should().HaveCount(expected);
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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public async Task Can_a_order_by_select_async_when_table_name_is_aliased_execute_successfully(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var table = dbo.Person.As("dboPerson");

            var names = await db.SelectMany(table.FirstName)
                .From(table)
                .OrderBy(table.FirstName)
                .ExecuteAsync();

            //then
            names.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        public async Task Can_a_group_by_with_having_select_async_when_table_name_is_aliased_execute_successfully(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var table = dbo.Person.As("dboPerson");

            var counts = await db.SelectMany(db.fx.Count(table.FirstName))
                .From(table)
                .GroupBy(table.FirstName)
                .Having(table.FirstName > "U")
                .ExecuteAsync();

            //then
            counts.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        public async Task Can_a_group_by_with_having_select_async_when_table_name_and_field_are_aliased_execute_successfully(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var table = dbo.Person.As("dboPerson");
            var field = table.FirstName;

            var counts = await db.SelectMany(
                    field.As("dboPersonFirstName"), 
                    db.fx.Count().As("NameGreaterThanUCount")
                )
                .From(table)
                .GroupBy(field)
                .Having(field > "U")
                .ExecuteAsync();

            //then
            counts.Should().HaveCount(expected);
        }

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

            int year = 2019;
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

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_an_overriden_property_name_return_the_overridden_property_name_when_retrieved_as_a_dynamic(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var persons = await db.SelectMany(
                    sec.Person.Id,
                    sec.Person.SocialSecurityNumber
                )
                .From(sec.Person).ExecuteAsync();

            //then
            ((string)persons.First().SocialSecurityNumber).Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_an_overriden_property_name_be_used_in_join_condition_and_return_the_overridden_property_name_when_retrieved_as_a_dynamic(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var persons = await db.SelectMany(
                    sec.Person.Id,
                    sec.Person.DateCreated,
                    sec.Person.SocialSecurityNumber
                )
                .From(sec.Person)
                .InnerJoin(
                    db.SelectMany(
                        sec.Person.Id,
                        sec.Person.SocialSecurityNumber
                    )
                    .From(sec.Person)
                ).As("secPerson").On(sec.Person.SocialSecurityNumber == dbex.Alias("secPerson", "SocialSecurityNumber"))
                .ExecuteAsync();

            //then
            ((string)persons.First().SocialSecurityNumber).Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_an_overriden_property_name_be_used_in_join_condition_where_aliased_and_return_the_overridden_property_name_when_retrieved_as_a_dynamic(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var persons = await db.SelectMany(
                    sec.Person.Id,
                    sec.Person.DateCreated,
                    sec.Person.SocialSecurityNumber
                )
                .From(sec.Person)
                .InnerJoin(
                    db.SelectMany(
                        sec.Person.Id,
                        sec.Person.SocialSecurityNumber.As("foo")
                    )
                    .From(sec.Person)
                ).As("secPerson").On(sec.Person.SocialSecurityNumber == dbex.Alias("secPerson", "foo"))
                .ExecuteAsync();

            //then
            ((string)persons.First().SocialSecurityNumber).Should().NotBeNull();
        }
    }
}
