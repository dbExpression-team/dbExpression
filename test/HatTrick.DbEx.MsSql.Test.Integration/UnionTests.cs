using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
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
    public partial class UnionTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_two_dynamic_records_successfully(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyHaveUniqueItems().And.OnlyContain(x => Enumerable.Range(1,50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_all_two_dynamic_records_successfully(int version, int expected = 100)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_two_dynamic_records_from_different_tables_successfully(int version, int expected = 82) //50 people + 32 addresses
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_all_two_dynamic_records_from_different_tables_successfully(int version, int expected = 82) //50 people + 32 addresses
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_multiple_dynamic_records_from_different_tables_successfully(int version, int expected = 91) //50 people + 32 addresses + 9 products
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_multiple_dynamic_records_with_aliasing_from_different_tables_successfully(int version, int expected = 91) //50 people + 32 addresses + 9 products
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.CommonId).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
            results.Select(x => (string)x.PrimaryIdentifier).Should().NotBeNullOrEmpty();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_multiple_dynamic_records_with_all_fields_aliased_from_different_tables_successfully(int version, int expected = 91) //50 people + 32 addresses + 9 products
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.CommonId).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
            results.Select(x => (string)x.PrimaryIdentifier).Should().NotBeNullOrEmpty();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_all_multiple_dynamic_records_from_different_tables_successfully(int version, int expected = 91) //50 people + 32 addresses + 9 products
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_intermix_union_and_union_all_with_multiple_dynamic_records_from_different_tables_successfully(int version, int expected = 91) //50 people + 32 addresses + 9 products
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => (int)x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_two_entities_successfully(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp =

                db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id < 5)

                .Union()
                .SelectMany()
                .From(dbo.Person)
                .Where(dbo.Person.Id >= 5);

            //when               
            IList<Person> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => x.Id).Should().OnlyHaveUniqueItems().And.OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_all_two_entities_successfully(int version, int expected = 100)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp =

                db.SelectMany<Person>()
                .From(dbo.Person)

                .UnionAll()
                .SelectMany()
                .From(dbo.Person);

            //when               
            IList<Person> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Select(x => x.Id).Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_two_values_successfully(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp =

                db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id < 5)

                .Union()
                .SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id >= 5);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().OnlyHaveUniqueItems().And.OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_all_two_values_successfully(int version, int expected = 100)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp =

                db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)

                .UnionAll()
                .SelectMany(dbo.Person.Id)
                .From(dbo.Person);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().OnlyContain(x => Enumerable.Range(1, 50).Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_two_enums_successfully(int version, int expected = 2)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp =

                db.SelectMany(dbo.Person.GenderType)
                .From(dbo.Person)
                .Where(dbo.Person.Id < 5)

                .Union()
                .SelectMany(dbo.Person.GenderType)
                .From(dbo.Person)
                .Where(dbo.Person.Id >= 5);

            //when               
            IList<GenderType> results = exp.Execute();

            //then
            //net462, can't compile with Enum.GetValues<GenderType>()
            var genderTypes = new List<GenderType>((GenderType[])Enum.GetValues(typeof(GenderType)));
            results.Should().HaveCount(expected);
            genderTypes.Should().HaveCount(expected);  //ensure test fails if new enum value is added
            results.Should().OnlyHaveUniqueItems().And.OnlyContain(x => ((genderTypes).Contains(x)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_all_two_enums_successfully(int version, int expected = 100)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp =

                db.SelectMany(dbo.Person.GenderType)
                .From(dbo.Person)

                .UnionAll()
                .SelectMany(dbo.Person.GenderType)
                .From(dbo.Person);

            //when               
            IList<GenderType> results = exp.Execute();

            //then
            //net462, can't compile with Enum.GetValues<GenderType>()
            var genderTypes = new List<GenderType>((GenderType[])Enum.GetValues(typeof(GenderType)));
            results.Should().HaveCount(expected);
            results.Should().AllSatisfy(x => genderTypes.Contains(x));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_two_objects_successfully(int version, int expected = 9)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp =

                db.SelectMany(dbo.Product.Description)
                .From(dbo.Product)
                .Where(dbo.Product.Id < 2)

                .Union()
                .SelectMany(dbo.Product.Description)
                .From(dbo.Product)
                .Where(dbo.Product.Id >= 2);

            //when               
            IList<ProductDescription?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().OnlyHaveUniqueItems();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_all_two_objects_successfully(int version, int expected = 18)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp =

                db.SelectMany(dbo.Product.Description)
                .From(dbo.Product)

                .UnionAll()
                .SelectMany(dbo.Product.Description)
                .From(dbo.Product);

            //when               
            IList<ProductDescription?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_of_value_with_ordering_execute_successfully(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().BeInAscendingOrder();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_union_all_of_value_with_ordering_execute_successfully(int version, int expected = 100)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().BeInAscendingOrder();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_select_with_union_all_of_value_subquery_with_ordering_execute_successfully(int version, int expected = 100)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.Should().BeInAscendingOrder();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_pivot_select_statements_using_union_all_and_aggregation_execute_successfully(int version, int expected = 16)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
