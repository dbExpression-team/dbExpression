using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "INSERT")]
    public partial class InsertTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_address_be_inserted(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.Insert(
                new Address
                {
                    Id = -1,
                    AddressType = AddressType.Mailing,
                    Line1 = "123 Main St",
                    City = "Anywhere",
                    State = "TX",
                    Zip = "65432",
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                })
                .Into(dbo.Address);

            //when               
            exp.Execute();

            //then
            var t1 = dbo.Address.As("a");
            var address = db.SelectOne<Address>()
                .From(dbo.Address)
                .InnerJoin(
                    db.SelectMany(
                        db.fx.Max(t1.Id).As("identity")
                    )
                    .From(t1)
                ).As("last_insert").On(dbo.Address.Id == ("last_insert", "identity"))
                .Execute();

            address.Should().NotBeNull();
            address!.Line1.Should().Be("123 Main St");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_address_be_inserted_and_identity_id_set(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var address = new Address
            {
                Line1 = "123 Main St",
                City = "Anywhere",
                State = "TX",
                Zip = "65432",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            var exp = db.Insert(address)
                .Into(dbo.Address);

            //when               
            exp.Execute();

            //then
            address.Id.Should().BeGreaterThan(0);
            address.AddressType.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_person_be_inserted_and_identity_id_set(int version, string expected = "INSERT")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var person = new Person
            {
                FirstName = expected,
                LastName = expected,
                GenderType = GenderType.Female,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            var exp = db.Insert(person)
                .Into(dbo.Person);

            //when               
            exp.Execute();

            Person? retrieved = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == person.Id).Execute();

            //then
            retrieved.Should().NotBeNull();
            retrieved!.Id.Should().BeGreaterThan(0);
            retrieved!.FirstName.Should().Be(expected);
            retrieved!.FirstName.Should().Be(expected);
            retrieved!.GenderType.Should().Be(GenderType.Female);
            retrieved!.CreditLimit.Should().BeNull();
            retrieved!.BirthDate.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_a_person_with_string_delimiter_in_last_name_be_inserted_successfully(int version, string expected = "O'Conner")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var person = new Person
            {
                FirstName = expected,
                LastName = expected,
                GenderType = GenderType.Female,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            var exp = db.Insert(person)
                .Into(dbo.Person);

            //when               
            exp.Execute();

            Person? retrieved = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == person.Id).Execute();

            //then
            retrieved.Should().NotBeNull();
            retrieved!.LastName.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersionsExcept(2005)]
        public void Can_many_persons_be_inserted_successfully(int version, int expected = 10)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var firstNames = Enumerable.Range(0, expected).Select(x => $"FirstName_{x}");
            var lastNames = Enumerable.Range(0, expected).Select(x => $"LastName_{x}");
            var persons = Enumerable.Range(0, expected).Select(x =>
                new Person
                {
                    FirstName = firstNames.ElementAt(x),
                    LastName = lastNames.ElementAt(x),
                    GenderType = x % 2 == 0 ? GenderType.Female : GenderType.Male,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }
            ).ToList();

            var exp = db.InsertMany(persons)
                .Into(dbo.Person);

            //when               
            exp.Execute();

            var retrieved = db.SelectMany<Person>().From(dbo.Person).Where(dbo.Person.FirstName.Like("FirstName_%")).Execute();

            //then
            retrieved.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_a_product_be_inserted_successfully(int version, double expected = 2.99)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.Insert(
                new Product
                {
                    Id = -1,
                    ProductCategoryType = ProductCategoryType.ToysAndGames,
                    Name = "Yo-Yo",
                    ListPrice = expected,
                    Price = 2.75,
                    Quantity = 100,
                    ShippingWeight = .5m,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                })
                .Into(dbo.Product);

            //when               
            exp.Execute();

            //then
            var t1 = dbo.Product.As("p");
            var product = db.SelectOne<Product>()
                .From(dbo.Product)
                .InnerJoin(
                    db.SelectMany(
                        db.fx.Max(t1.Id).As("identity")
                    )
                    .From(t1)
                ).As("last_insert").On(dbo.Product.Id == ("last_insert", "identity"))
                .Execute();

            product.Should().NotBeNull();
            product!.ListPrice.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_empty_list_of_persons_execute_without_exception(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.InsertMany(new List<Person>()).Into(dbo.Person);

            //when & then         
            exp.Execute();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_null_value_for_list_of_persons_execute_and_fail_as_expected(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.InsertMany((IEnumerable<Person>)null!)
                .Into(dbo.Person)
                .Execute();

            //when & then
            execute.Should().Throw<ArgumentNullException>();
        }
    }
}
