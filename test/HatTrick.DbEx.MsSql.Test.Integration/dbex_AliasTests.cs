using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using Xunit;
using System;
using HatTrick.DbEx.Sql.Builder.Alias;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class dbex_AliasTests : ResetDatabaseNotRequired
    {
        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [InlineData(3)]
        public void Does_select_many_dynamic_with_aliased_subquery_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            int year = 2019;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            IEnumerable<dynamic> vipStatistics = db.SelectMany(
                dbo.Person.Id.As("PersonId"),
                dbex.Alias<int>("vips", "PurchaseCount"),
                dbex.Alias<int>("vips", "PurchaseYear"),
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName")
            )
            .From(dbo.Person)
            .InnerJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("vips").On(dbo.Person.Id == ("vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc(),
                ("vips", "PurchaseCount").Desc()
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount);
            vipStatistics.Select(x => (int)x.PurchaseYear).Should().OnlyContain(x => x >= year);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [InlineData(3)]
        public void Does_select_many_dynamic_with_adding_PersonId_to_aliased_PurchaseCount_from_aliased_subquery_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            int year = 2019;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            IEnumerable<dynamic> vipStatistics = db.SelectMany(
                dbo.Person.Id.As("PersonId"),
                (dbex.Alias<int>("vips", "PurchaseCount") + dbo.Person.Id).As("PurchaseCount"),
                dbex.Alias<int>("vips", "PurchaseYear"),
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName")
            )
            .From(dbo.Person)
            .InnerJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("vips").On(dbo.Person.Id == ("vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc(),
                ("vips", "PurchaseCount").Desc()
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount + 1);
            vipStatistics.Select(x => (int)x.PurchaseYear).Should().OnlyContain(x => x >= year);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [InlineData(3)]
        public void Does_select_many_dynamic_with_adding_PersonYear_to_aliased_PurchaseCount_from_aliased_subquery_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            int year = 2019;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            IEnumerable<dynamic> vipStatistics = db.SelectMany(
                dbo.Person.Id.As("PersonId"),
                dbex.Alias<int>("vips", "PurchaseCount"),
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName")
            )
            .From(dbo.Person)
            .InnerJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("vips").On(dbo.Person.Id == ("vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc(),
                ("vips", "PurchaseCount").Desc()
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
            vipStatistics.Select(x => (int)x.PurchaseCount).Should().OnlyContain(x => x >= purchaseCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [Trait("Operation", "ORDER BY")]
        [InlineData(50)]
        public void Does_select_many_dynamic_with_multiple_subqueries_and_functions_result_in_correct_output(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            int year = 2017;
            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            IEnumerable<dynamic> vipStatistics = db.SelectMany(
                dbo.Person.Id.As("PersonId"),
                db.fx.Coalesce(dbex.Alias<int?>("vips", "PurchaseCount"), dbex.Alias<int?>("not_vips", "PurchaseCount"), 1).As("PurchaseCount"),
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("vips").On(dbo.Person.Id == ("vips", "PersonId"))
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )
                .Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) < purchaseCount
                    & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
                )
            ).As("not_vips").On(dbo.Person.Id == ("not_vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc(),
                ("vips", "PurchaseCount").Desc()
            )
            .Execute();

            //then
            vipStatistics.Should().HaveCount(expectedCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [Trait("Operation", "GROUP BY")]
        [InlineData(2)]
        public void Can_aliasing_an_alias_result_in_correct_output(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            dynamic? vipStatistics = db.SelectOne(
                dbo.Person.Id.As("PersonId"),
                dbex.Alias<int?>("vips", "PurchaseCount").As("Result")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId
                )
            ).As("vips").On(dbo.Person.Id == ("vips", "PersonId"))
            .Where(dbex.Alias("vips", "PurchaseCount") == expected)
            .Execute();

            //then
            ((int?)vipStatistics!.Result).Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [InlineData(50, 17)]
        public void Can_aliased_subquery_result_in_correct_counts_for_dynamic_return(int personCount, int addressCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            IEnumerable<dynamic> persons = db.SelectMany(
                dbo.Person.Id,
                (dbo.Person.FirstName + " " + dbo.Person.LastName).As("CustomerName"),
                (dbex.Alias<int?>("person_address", "Id") + 2).As("AddressId")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.PersonAddress.PersonId,
                    dbo.Address.Id
                )
                .From(dbo.Address)
                .InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
                .Where(dbo.Address.AddressType == AddressType.Mailing)
            ).As("person_address").On(dbo.Person.Id == ("person_address", "PersonId"))
            .Execute();

            //then
            persons.Should().HaveCount(personCount);
            persons.Where(x => ((int?)x.AddressId).HasValue).Should().HaveCount(addressCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [InlineData(50, 17)]
        public void Can_aliased_subquery_result_in_correct_counts_for_value_return(int personCount, int addressCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            IEnumerable<string?> persons = db.SelectMany(
                dbex.Alias<string?>("person_address", "Line1").As("Foo")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.PersonAddress.PersonId,
                    dbo.Address.Id,
                    dbo.Address.Line1
                )
                .From(dbo.Address)
                .InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
                .Where(dbo.Address.AddressType == AddressType.Mailing)
            ).As("person_address").On(dbo.Person.Id == ("person_address", "PersonId"))
            .Execute();

            //then
            persons.Should().HaveCount(personCount);
            persons.Where(x => x is not null).Should().HaveCount(addressCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [InlineData(50)]
        public void Can_aliased_subquery_result_in_correct_counts_for_entity_return(int personCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .LeftJoin(
                    db.SelectMany(
                        dbo.PersonAddress.PersonId,
                        dbo.Address.Id
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
                    .Where(dbo.Address.AddressType == AddressType.Mailing)
                ).As("person_address").On(dbo.Person.Id == ("person_address", "PersonId"))
                .Execute();

            //then
            persons.Should().HaveCount(personCount);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [InlineData(50)]
        public void Can_aliased_subqueries_result_in_correct_counts_for_coalesced_value_return(int count)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            IEnumerable<int> values = db.SelectMany(
                db.fx.Coalesce<int>(dbex.Alias<int>("vips", "PurchaseCount"), dbex.Alias<int>("not_vips", "PurchaseCount"), 1).As("PurchaseCount")
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                )
            ).As("vips").On(dbo.Person.Id == ("vips", "PersonId"))
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) < purchaseCount
                )
            ).As("not_vips").On(dbo.Person.Id == ("not_vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc(),
                ("vips", "PurchaseCount").Desc()
            )
            .Execute();

            //then
            values.Should().HaveCount(count);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [Trait("Operation", "LEFT JOIN")]
        [InlineData(50)]
        public void Can_aliased_subqueries_result_in_correct_counts_for_coalesced_value_using_custom_mapping_in_execute(int count)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            int purchaseCount = 3;  //any person making 3 or more purchases (in a calendar year are considered VIP customers

            IEnumerable<dynamic> values = db.SelectMany(
                dbo.Person.Id,
                db.fx.Coalesce(dbex.Alias<int>("vips", "PurchaseCount"), dbex.Alias<int>("not_vips", "PurchaseCount"), int.MinValue)
            )
            .From(dbo.Person)
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
                )
            ).As("vips").On(dbo.Person.Id == ("vips", "PersonId"))
            .LeftJoin(
                db.SelectMany(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear"),
                    db.fx.Count(dbo.Purchase.Id).As("PurchaseCount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PersonId,
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).Having(
                    db.fx.Count(dbo.Purchase.PurchaseDate) < purchaseCount
                )
            ).As("not_vips").On(dbo.Person.Id == ("not_vips", "PersonId"))
            .OrderBy(
                (dbo.Person.Id + dbo.Person.Id).Asc(),
                ("vips", "PurchaseCount").Desc()
            )
            .Execute(row =>
                {
                    dynamic o = new ExpandoObject();
                    o.Id = row.ReadField()!.GetValue<int>();
                    o.Count = row.ReadField()!.GetValue<int>();
                    return o;
                });

            //then
            values.Should().HaveCount(count);
        }


        [Fact]
        [Trait("Operation", "LEFT JOIN")]
        public void Can_alias_result_in_correct_conversion_for_nullable_enum_using_custom_mapping()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            dynamic? values = db.SelectOne(
                dbo.Person.Id,
                dbex.Alias<AddressType?>("MyAddress", "AddressType").As("foo")
            )
            .From(dbo.Person)
            .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
            .InnerJoin(dbo.Address.As("MyAddress")).On(dbo.PersonAddress.AddressId == ("MyAddress", nameof(dbo.Address.Id)))
            .Where(dbex.Alias<AddressType>("MyAddress", nameof(dbo.Address.AddressType)) != dbex.Null)
            .Execute(row =>
            {
                dynamic o = new ExpandoObject();
                o.Id = row.ReadField()!.GetValue<int>();
                o.AddressType = row.ReadField()!.GetValue<AddressType?>();
                return o;
            });

            //then
            ((AddressType?)values!.AddressType).Should().NotBeNull();
        }

        [Fact]
        [Trait("Operation", "LEFT JOIN")]
        public void Can_alias_result_in_correct_conversion_for_nullable_enum_using_standard_mapping()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            dynamic? values = db.SelectOne(
                dbo.Person.Id,
                dbex.Alias<AddressType?>("MyAddress", "AddressType").As("foo")
            )
            .From(dbo.Person)
            .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
            .InnerJoin(dbo.Address.As("MyAddress")).On(dbo.PersonAddress.AddressId == ("MyAddress", nameof(dbo.Address.Id)))
            .Where(dbex.Alias<AddressType>("MyAddress", nameof(dbo.Address.AddressType)) != dbex.Null)
            .Execute();

            //then
            ((AddressType?)values!.foo).Should().NotBeNull();
        }

        [Fact]
        public void Can_alias_result_in_correct_conversion_for_nullable_int_using_standard_mapping()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            int? value = db.SelectOne(
                dbex.Alias<int?>("samePerson", nameof(dbo.Person.CreditLimit))
            )
            .From(dbo.Person)
            .InnerJoin(dbo.Person.As("samePerson")).On(dbo.Person.Id == ("samePerson", nameof(dbo.Person.Id)))
            .Where(dbo.Person.CreditLimit == dbex.Null)
            .Execute();

            //then
            value.Should().BeNull();
        }

        [Fact]
        public void Can_alias_result_in_correct_conversion_for_int_using_standard_mapping()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            int value = db.SelectOne(
                dbex.Alias<int>("samePerson", nameof(dbo.Person.CreditLimit))
            )
            .From(dbo.Person)
            .InnerJoin(dbo.Person.As("samePerson")).On(dbo.Person.Id == ("samePerson", nameof(dbo.Person.Id)))
            .Where(dbo.Person.CreditLimit != dbex.Null)
            .Execute();

            //then
            value.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(52)]
        public void Can_alias_of_subquery_field_result_in_correct_conversion_for_fields_including_an_enum_and_using_delegate_mapping(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var values = db.SelectMany(
                dbo.Person.FirstName,
                dbo.Person.LastName,
                db.fx.IsNull(("type_count", "AddressType"), AddressType.Shipping),
                dbex.Alias<int>("type_count", "count")
            )
            .From(dbo.Person)
            .InnerJoin(
                db.SelectMany(
                    dbo.PersonAddress.PersonId,
                    dbo.Address.AddressType,
                    db.fx.Count().As("count")
                ).From(dbo.Address)
                .InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
                .GroupBy(
                    dbo.PersonAddress.PersonId,
                    dbo.Address.AddressType
                )
            ).As("type_count").On(dbo.Person.Id == ("type_count", "PersonId"))
            .Execute(
                row => new { 
                    Name = $"{row.ReadField()!.GetValue<string>()} {row.ReadField()!.GetValue<string>()}",
                    AddressType = row.ReadField()!.GetValue<AddressType?>(),
                    TotalCount = row.ReadField()!.GetValue<int>()
                }
            );

            //then
            values.Should().HaveCount(expected);            
        }

        [Theory]
        [InlineData(9)]
        public void Can_use_alias_of_subquery_string_field_as_right_arg_of_join_condition(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> values = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.Name,
                dbex.Alias<string?>("inner", "Name").As("inner_name")
            )
            .From(dbo.Product)
            .InnerJoin(
                db.SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Name
                ).From(dbo.Product)
            ).As("inner").On(dbo.Product.Id == ("inner", "Id"))
            .Execute();

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(9)]
        public void Can_use_alias_of_subquery_string_field_as_left_arg_of_join_condition(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<dynamic> values = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.Name,
                dbex.Alias<string?>("inner", "Name").As("inner_name")
            )
            .From(dbo.Product)
            .InnerJoin(
                db.SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Name
                ).From(dbo.Product)
            ).As("inner").On(("inner", "Id") == dbo.Product.Id)
            .Execute();

            //then
            values.Should().HaveCount(expected);
        }
    }
}
