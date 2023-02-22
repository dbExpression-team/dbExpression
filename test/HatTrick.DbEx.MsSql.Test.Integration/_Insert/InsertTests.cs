using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "INSERT")]
    public partial class InsertTests : ResetDatabaseAfterEveryTest
    {
        [Fact]
        public void Can_an_address_be_inserted()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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

        [Fact]
        public void Can_an_address_be_inserted_and_identity_id_set()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("INSERT")]
        public void Can_an_person_be_inserted_and_identity_id_set(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("O'Conner")]
        public void Can_a_person_with_string_delimiter_in_last_name_be_inserted_successfully(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData(10)]
        public void Can_many_persons_be_inserted_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData(2.99)]
        public void Can_a_product_be_inserted_successfully(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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

        [Fact]
        public void Can_empty_list_of_persons_execute_without_exception()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.InsertMany(new List<Person>()).Into(dbo.Person);

            //when & then         
            exp.Execute();
        }

        [Fact]
        public void Can_null_value_for_list_of_persons_execute_and_fail_as_expected()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.InsertMany((IEnumerable<Person>)null!)
                .Into(dbo.Person)
                .Execute();

            //when & then
            execute.Should().Throw<ArgumentNullException>();
        }
    }
}
