using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using v2019DbEx.secDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public partial class SelectManyTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(50)]
        public void Are_there_50_person_records(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            IEnumerable<Person> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Are_there_50_person_records_async(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            IEnumerable<Person> persons = await exp.ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Are_there_50_person_records_async_enumerable(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            List<Person> persons = new();
            await foreach (var person in exp.ExecuteAsyncEnumerable().ConfigureAwait(false))
                persons.Add(person);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Are_there_15_purchase_records(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Purchase>()
               .From(dbo.Purchase);

            //when               
            IEnumerable<Purchase> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Can_retrieve_page_of_purchase_records(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.PersonId)
                .Distinct()
                .From(dbo.Purchase)
                .OrderBy(dbo.Purchase.PersonId)
                .Offset(5)
                .Limit(1000);

            //when               
            IEnumerable<int> ids = exp.Execute();

            //then
            ids.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Can_retrieve_page_of_purchase_records_with_aliased_field(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.PersonId.As("person_id"))
                .Distinct()
                .From(dbo.Purchase)
                .OrderBy(dbo.Purchase.PersonId)
                .Offset(5)
                .Limit(1000);

            //when               
            IEnumerable<int> ids = exp.Execute();

            //then
            ids.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Can_retrieve_a_list_of_ship_dates_from_purchase(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.ShipDate)
                .From(dbo.Purchase);

            //when               
            IEnumerable<DateTime?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Can_retrieve_a_list_of_ship_dates_from_purchase_using_custom_reader(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var dates = new List<DateTime?>();
            var exp = db.SelectMany(dbo.Purchase.ShipDate)
                .From(dbo.Purchase);

            //when               
            exp.Execute(v => dates.Add(v));

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Can_retrieve_a_list_of_ids_from_purchase(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase);

            //when               
            IEnumerable<int> ids = exp.Execute();

            //then
            ids.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Can_retrieve_a_list_of_ids_from_purchase_using_custom_reader(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var ids = new List<int>();
            var exp = db.SelectMany(dbo.Purchase.Id)
                .From(dbo.Purchase);

            //when               
            exp.Execute(v => ids.Add(v));

            //then
            ids.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [Trait("Operation", "DISTINCT")]
        [InlineData(17)]
        public void Does_select_many_for_single_field_result_in_valid_expression(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> persons = db.SelectMany(
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
                    dbo.Person.FirstName.Desc()
                )
                .Execute();

            //then
            persons.Count().Should().Be(expected);
            persons.Count(p => p.person_count == 2).Should().Be(expected);
        }

        [Fact]
        public void Does_selecting_multiple_fields_and_mapping_to_dynamic_fail_when_alias_is_not_provided()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectMany(
                    dbo.Purchase.Id,
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .Execute();

            //when & then
            execute.Should().Throw<DbExpressionMappingException>();
        }

        [Fact]
        public async Task Does_selecting_multiple_fields_and_mapping_to_dynamic_fail_when_alias_is_not_provided_using_async()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Func<Task> execute = () => db.SelectMany(
                    dbo.Purchase.Id,
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .ExecuteAsync();

            //when & then
            await execute.Should().ThrowAsync<DbExpressionMappingException>();
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(50)]
        public async Task Can_a_order_by_select_async_when_table_name_is_aliased_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var table = dbo.Person.As("dboPerson");

            var names = await db.SelectMany(table.FirstName)
                .From(table)
                .OrderBy(table.FirstName)
                .ExecuteAsync();

            //then
            names.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [InlineData(1)]
        public async Task Can_a_group_by_with_having_select_async_when_table_name_is_aliased_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var table = dbo.Person.As("dboPerson");

            IEnumerable<int> counts = await db.SelectMany(db.fx.Count(table.FirstName))
                .From(table)
                .GroupBy(table.FirstName)
                .Having(table.FirstName > "U")
                .ExecuteAsync();

            //then
            counts.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [InlineData(1)]
        public async Task Can_a_group_by_with_having_select_async_when_table_name_and_field_are_aliased_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var table = dbo.Person.As("dboPerson");
            var field = table.FirstName;

            IEnumerable<dynamic> counts = await db.SelectMany(
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
        [InlineData(17)]
        public void Does_select_many_result_in_valid_expression(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> persons = db.SelectMany(
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
                    dbo.Person.FirstName.Desc()
                )
                .Execute();

            //then
            persons.Count().Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [InlineData(3)]
        public void Does_select_many_dynamic_objects_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            int year = 2019;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            //when
            IEnumerable<int> vipStatistics = db.SelectMany(
                db.fx.Count(dbo.Purchase.PurchaseDate).As("PurchaseCount")
            )
            .From(dbo.Purchase)
            .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
            .OrderBy(
                db.fx.Count(dbo.Purchase.PurchaseDate).Asc()
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

        [Fact]
        public async Task Can_an_overriden_property_name_return_the_overridden_property_name_when_retrieved_as_a_dynamic()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            IEnumerable<dynamic> persons = await db.SelectMany(
                    sec.Person.Id,
                    sec.Person.SocialSecurityNumber
                )
                .From(sec.Person).ExecuteAsync();

            //then
            ((string)persons.First().SocialSecurityNumber).Should().NotBeNull();
        }

        [Fact]
        public async Task Can_an_overriden_property_name_be_used_in_join_condition_and_return_the_overridden_property_name_when_retrieved_as_a_dynamic()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            IEnumerable<dynamic> persons = await db.SelectMany(
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
                ).As("secPerson").On(sec.Person.SocialSecurityNumber == ("secPerson", "SocialSecurityNumber"))
                .ExecuteAsync();

            //then
            ((string)persons.First().SocialSecurityNumber).Should().NotBeNull();
        }

        [Fact]
        public async Task Can_an_overriden_property_name_be_used_in_join_condition_where_aliased_and_return_the_overridden_property_name_when_retrieved_as_a_dynamic()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            IEnumerable<dynamic> persons = await db.SelectMany(
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
                ).As("secPerson").On(sec.Person.SocialSecurityNumber == ("secPerson", "foo"))
                .ExecuteAsync();

            //then
            ((string)persons.First().SocialSecurityNumber).Should().NotBeNull();
        }

        [Theory]
        [Trait("Operation", "TOP")]
        [Trait("Operation", "ORDER BY")]
        [InlineData(5)]
        public void Can_top_person_records_select_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .Top(expected)
                .From(dbo.Person)
                .OrderBy(dbo.Person.LastName.Asc(), dbo.Person.FirstName.Asc());

            //when               
            IEnumerable<dynamic> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "TOP")]
        [Trait("Operation", "ORDER BY")]
        [InlineData(5)]
        public void Can_top_distinct_person_records_select_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .Top(expected)
                .Distinct()
                .From(dbo.Person)
                .OrderBy(dbo.Person.LastName.Asc(), dbo.Person.FirstName.Asc());

            //when               
            IEnumerable<dynamic> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Fact]
        public async Task Can_select_dynamic_by_providing_list_of_any_element()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            IEnumerable<dynamic> persons = await db.SelectMany(
                    new List<AnyElement>() {
                        dbo.Person.Id,
                        dbo.Person.FirstName,
                        dbo.Person.LastName,
                        dbo.Person.CreditLimit
                    }
                )
                .From(dbo.Person).ExecuteAsync();

            //then
            persons.Should().HaveCount(50);
        }

        [Fact]
        public async Task Can_select_dynamic_by_providing_list_of_any_element_and_additional_fields_as_params()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            IEnumerable<dynamic> persons = await db.SelectMany(
                    new List<AnyElement>() {
                        dbo.Person.Id,
                        dbo.Person.FirstName,
                        dbo.Person.LastName,
                        dbo.Person.CreditLimit
                    },
                    dbo.Person.BirthDate,
                    dbo.Person.DateCreated,
                    dbo.Person.DateUpdated
                )
                .From(dbo.Person).ExecuteAsync();

            //then
            persons.Should().HaveCount(50);
        }

        [Theory]
        [InlineData(44)]
        public async Task Can_select_person_by_left_join_of_casted_null(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<Person> persons = await db.SelectMany<Person>()
                .From(dbo.Person)
                .LeftJoin(dbo.Purchase).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .Where(dbo.Purchase.Id == (int?)null)
                .ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
        }
    }
}
