using DbEx.Data;
using DbEx.Data.dbo;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System;
using Xunit;

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
            var address = db.SelectOne<Address>()
                .From(t1)
                .InnerJoin(
                    db.SelectMany(
                        db.fx.Max(dbo.Address.Id).As("identity")
                    )
                    .From(dbo.Address)
                ).As("last_insert").On(t1.Id == dbo.Address.As("last_insert").Id.As("identity"))
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
    }
}
