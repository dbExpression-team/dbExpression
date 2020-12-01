using DbEx.Data;
using DbEx.dboDataService;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;
using DbEx.dboData;
using System.Linq;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "INSERT")]
    public partial class Insert : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_address_be_inserted(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
            var last_insert = db.alias("last_insert", "identity");
            var address = db.SelectOne<Address>()
                .From(t1)
                .InnerJoin(
                    db.SelectMany(
                        db.fx.Max(dbo.Address.Id).As("identity")
                    )
                    .From(dbo.Address)
                ).As("last_insert").On(t1.Id == last_insert)
                .Execute();

            address.Should().NotBeNull();
            address.Line1.Should().Be("123 Main St");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_an_address_be_inserted_and_identity_id_set(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
            ConfigureForMsSqlVersion(version);

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

            Person retrieved = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == person.Id).Execute();

            //then
            retrieved.Id.Should().BeGreaterThan(0);
            retrieved.FirstName.Should().Be(expected);
            retrieved.FirstName.Should().Be(expected);
            retrieved.GenderType.Should().Be(GenderType.Female);
            retrieved.CreditLimit.Should().BeNull();
            retrieved.BirthDate.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_a_person_with_string_delimiter_in_last_name_be_inserted_successfully(int version, string expected = "O'Conner")
        {
            //given
            ConfigureForMsSqlVersion(version);

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

            Person retrieved = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == person.Id).Execute();

            //then
            retrieved.LastName.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersionsExcept(2005)]
        public void Can_many_persons_be_inserted_successfully(int version, int expected = 10)
        {
            //given
            ConfigureForMsSqlVersion(version);

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

        [Fact]
        public void Does_inserting_multiple_persons_fail_for_v2005()
        {
            //given
            ConfigureForMsSqlVersion(2005);

            var firstNames = Enumerable.Range(0, 2).Select(x => $"FirstName_{x}");
            var lastNames = Enumerable.Range(0, 2).Select(x => $"LastName_{x}");
            var persons = Enumerable.Range(0, 2).Select(x =>
                new Person
                {
                    FirstName = firstNames.ElementAt(x),
                    LastName = lastNames.ElementAt(x),
                    GenderType = x % 2 == 0 ? GenderType.Female : GenderType.Male,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }
            ).ToList();

            Action execute = () => db.InsertMany(persons)
                .Into(dbo.Person)
                .Execute();

            //when & then
            execute.Should().Throw<DbExpressionException>().And.Message.Should().Be("MsSql version 2005 does not support inserting multiple records in a single statement.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_a_product_be_inserted_successfully(int version, double expected = 2.99)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
                .From(t1)
                .InnerJoin(
                    db.SelectMany(
                        db.fx.Max(dbo.Product.Id).As("identity")
                    )
                    .From(dbo.Product)
                ).As("last_insert").On(t1.Id == db.alias("last_insert","identity"))
                .Execute();

            product.Should().NotBeNull();
            product.ListPrice.Should().Be(expected);
        }
    }
}
