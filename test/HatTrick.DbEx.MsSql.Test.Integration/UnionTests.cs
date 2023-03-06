using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Operation", "UNION")]
    public partial class UnionTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(50)]
        public void Can_union_two_dynamic_records_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id < 5)

                .Union()
                .SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id >= 5);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyHaveUniqueItems().And.OnlyContain(x => Enumerable.Range(1,50).Contains(x));
        }

        [Theory]
        [InlineData(100)]
        public void Can_union_all_two_dynamic_records_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)

                .UnionAll()
                .SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(82)]
        public void Can_union_two_dynamic_records_from_different_tables_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)

                .Union()
                .SelectMany(
                    dbo.Address.Id,
                    dbo.Address.Line1,
                    dbo.Address.Line2
                )
                .From(dbo.Address);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(82)]
        public void Can_union_all_two_dynamic_records_from_different_tables_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)

                .UnionAll()
                .SelectMany(
                    dbo.Address.Id,
                    dbo.Address.Line1,
                    dbo.Address.Line2
                )
                .From(dbo.Address);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(91)]
        public void Can_union_multiple_dynamic_records_from_different_tables_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)

                .Union()
                .SelectMany(
                    dbo.Address.Id,
                    dbo.Address.Line1,
                    dbo.Address.Line2
                )
                .From(dbo.Address)

                .Union()
                .SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Name,
                    dbo.Product.Description
                )
                .From(dbo.Product);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(91)]
        public void Can_union_multiple_dynamic_records_with_aliasing_from_different_tables_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id.As("CommonId"),
                    dbo.Person.FirstName.As("PrimaryIdentifier"),
                    dbo.Person.LastName.As("SecondaryIdentifier")
                )
                .From(dbo.Person)

                .Union()
                .SelectMany(
                    dbo.Address.Id,
                    dbo.Address.City,
                    dbo.Address.State
                )
                .From(dbo.Address)

                .Union()
                .SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Name,
                    dbo.Product.Description
                )
                .From(dbo.Product);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.CommonId).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
            results.Select(x => (string)x.PrimaryIdentifier).Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData(91)]
        public void Can_union_multiple_dynamic_records_with_all_fields_aliased_from_different_tables_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id.As("CommonId"),
                    dbo.Person.FirstName.As("PrimaryIdentifier"),
                    dbo.Person.LastName.As("SecondaryIdentifier")
                )
                .From(dbo.Person)

                .Union()
                .SelectMany(
                    dbo.Address.Id.As("AnotherId"),
                    dbo.Address.City.As("Locale"),
                    dbo.Address.State.As("Region")
                )
                .From(dbo.Address)

                .Union()
                .SelectMany(
                    dbo.Product.Id.As("SomeOtherId"),
                    dbo.Product.Name.As("Title"),
                    dbo.Product.Description.As("ProductDescription")
                )
                .From(dbo.Product);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.CommonId).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
            results.Select(x => (string)x.PrimaryIdentifier).Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData(91)]
        public void Can_union_all_multiple_dynamic_records_from_different_tables_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)

                .UnionAll()
                .SelectMany(
                    dbo.Address.Id,
                    dbo.Address.Line1,
                    dbo.Address.Line2
                )
                .From(dbo.Address)

                .UnionAll()
                .SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Name,
                    dbo.Product.Description
                )
                .From(dbo.Product);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(91)]
        public void Can_intermix_union_and_union_all_with_multiple_dynamic_records_from_different_tables_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)

                .Union()
                .SelectMany(
                    dbo.Address.Id,
                    dbo.Address.Line1,
                    dbo.Address.Line2
                )
                .From(dbo.Address)

                .UnionAll()
                .SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Name,
                    dbo.Product.Description
                )
                .From(dbo.Product);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(50)]
        public void Can_union_two_entities_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id < 5)

                .Union()
                .SelectMany()
                .From(dbo.Person)
                .Where(dbo.Person.Id >= 5);

            //when               
            IEnumerable<Person> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => x.Id).Should().OnlyHaveUniqueItems().And.OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(100)]
        public void Can_union_all_two_entities_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany<Person>()
                .From(dbo.Person)

                .UnionAll()
                .SelectMany()
                .From(dbo.Person);

            //when               
            IEnumerable<Person> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(50)]
        public void Can_union_two_values_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id < 5)

                .Union()
                .SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id >= 5);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().OnlyHaveUniqueItems().And.OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(100)]
        public void Can_union_all_two_values_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)

                .UnionAll()
                .SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [InlineData(1)]
        public void Can_union_two_select_one_queries_successfully(int personId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            IEnumerable<Person> persons = db.SelectOne<Person>()
             .From(dbo.Person)
             .Where(dbo.Person.Id == personId)
             .UnionAll()
             .SelectOne()
             .From(dbo.Person)
             .Where(dbo.Person.Id == personId)
             .Execute();

            //then
            persons.Count().Should().Be(2);
            persons.Should().Match(p => p.All(x => x.Id == personId));
        }

        [Theory]
        [InlineData(2)]
        public void Can_union_two_enums_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(dbo.Person.GenderType)
                .From(dbo.Person)
                .Where(dbo.Person.Id < 5)

                .Union()
                .SelectMany(dbo.Person.GenderType)
                .From(dbo.Person)
                .Where(dbo.Person.Id >= 5);

            //when               
            IEnumerable<GenderType> results = exp.Execute();

            //then
            //net462, can't compile with Enum.GetValues<GenderType>()
            var genderTypes = new List<GenderType>((GenderType[])Enum.GetValues(typeof(GenderType)));
            results.Should().HaveCount(expected);
            genderTypes.Should().HaveCount(expected);  //ensure test fails if new enum value is added
            results.Should().OnlyHaveUniqueItems().And.OnlyContain(x => ((genderTypes).Contains(x)));
        }

        [Theory]
        [InlineData(100)]
        public void Can_union_all_two_enums_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(dbo.Person.GenderType)
                .From(dbo.Person)

                .UnionAll()
                .SelectMany(dbo.Person.GenderType)
                .From(dbo.Person);

            //when               
            IEnumerable<GenderType> results = exp.Execute();

            //then
            //net462, can't compile with Enum.GetValues<GenderType>()
            var genderTypes = new List<GenderType>((GenderType[])Enum.GetValues(typeof(GenderType)));
            results.Should().HaveCount(expected);
            results.Should().AllSatisfy(x => genderTypes.Contains(x));
        }

        [Theory]
        [InlineData(9)]
        public void Can_union_two_objects_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(dbo.Product.Description)
                .From(dbo.Product)
                .Where(dbo.Product.Id < 2)

                .Union()
                .SelectMany(dbo.Product.Description)
                .From(dbo.Product)
                .Where(dbo.Product.Id >= 2);

            //when               
            IEnumerable<ProductDescription?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().OnlyHaveUniqueItems();
        }

        [Theory]
        [InlineData(18)]
        public void Can_union_all_two_objects_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(dbo.Product.Description)
                .From(dbo.Product)

                .UnionAll()
                .SelectMany(dbo.Product.Description)
                .From(dbo.Product);

            //when               
            IEnumerable<ProductDescription?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Can_union_of_value_with_ordering_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName).As("Key")
                )
                .From(dbo.Person)
                .Union()
                .SelectMany(
                    db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName)
                )
                .From(dbo.Person)
                .OrderBy(
                    dbex.Alias("Key")
                );

            //when               
            IEnumerable<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().BeInAscendingOrder();
        }

        [Theory]
        [InlineData(100)]
        public void Can_union_all_of_value_with_ordering_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName).As("Key")
                )
                .From(dbo.Person)
                .UnionAll()
                .SelectMany(
                    db.fx.Concat(dbo.Person.FirstName, "ABC", dbo.Person.LastName)
                )
                .From(dbo.Person)
                .OrderBy(
                    dbex.Alias("Key")
                );

            //when               
            IEnumerable<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().BeInAscendingOrder();
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(100)]
        public void Can_select_with_union_all_of_value_subquery_with_ordering_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbex.Alias<string>("Key")
                ).From(
                    db.SelectMany(
                        db.fx.Concat(dbo.Person.FirstName, " ", dbo.Person.LastName).As("Key")
                    )
                    .From(dbo.Person)
                    .UnionAll()
                    .SelectMany(
                        db.fx.Concat(dbo.Person.FirstName, "ABC", dbo.Person.LastName)
                    )
                    .From(dbo.Person)                    
                ).As("x")
                .OrderBy(
                    dbex.Alias("Key")
                );

            //when               
            IEnumerable<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().BeInAscendingOrder();
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(16)]
        public void Can_pivot_select_statements_using_union_all_and_aggregation_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp =

                db.SelectMany(
                    dbex.Alias<string>("Pivot", "State"),
                    db.fx.Sum(("Pivot", "ShippingCount")).As("Shipping"),
                    db.fx.Sum(("Pivot", "MailingCount")).As("Mailing"),
                    db.fx.Sum(("Pivot", "BillingCount")).As("Billing")
                ).From(
                    db.SelectMany(
                        dbo.Address.State,
                        db.fx.Count().As("ShippingCount"),
                        dbex.Null.As("MailingCount"),
                        dbex.Null.As("BillingCount")
                    ).From(dbo.Address)
                    .Where(dbo.Address.AddressType == AddressType.Shipping)
                    .GroupBy(dbo.Address.State)
                    .UnionAll()
                    .SelectMany(
                        dbo.Address.State,
                        dbex.Null,
                        db.fx.Count(),
                        dbex.Null
                    ).From(dbo.Address)
                    .Where(dbo.Address.AddressType == AddressType.Mailing)
                    .GroupBy(dbo.Address.State)
                    .UnionAll()
                    .SelectMany(
                        dbo.Address.State,
                        dbex.Null,                        
                        dbex.Null,
                        db.fx.Count()
                    ).From(dbo.Address)
                    .Where(dbo.Address.AddressType == AddressType.Billing)
                    .GroupBy(dbo.Address.State)
                ).As("Pivot")
                .GroupBy(dbex.Alias("Pivot", "State"))
                .OrderBy(dbex.Alias("Pivot", "State"));

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
