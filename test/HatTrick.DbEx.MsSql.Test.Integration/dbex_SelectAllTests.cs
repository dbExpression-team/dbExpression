using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public partial class dbex_SelectAllTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_use_select_all_for_person_entity_successfully(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person)
                )
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_use_select_all_for_multiple_entities_successfully(int version, int expected = 52)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var expectedFieldCount = 0;
            var rowCount = 0;
            var fieldCount = 0;

            expectedFieldCount += (dbo.Person as Table).Fields.Count();
            expectedFieldCount += (dbo.Address as Table).Fields.Count();
            expectedFieldCount += (dbo.PersonAddress as Table).Fields.Count();

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person)
                    .Concat(dbex.SelectAllFor(dbo.Address))
                    .Concat(dbex.SelectAllFor(dbo.PersonAddress))
                )
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id);

            //when               
            await exp.ExecuteAsync(reader =>
            {
                if (rowCount == 0)
                    fieldCount = reader.FieldCount;
                rowCount++;
            });

            //then
            rowCount.Should().Be(expected);
            fieldCount.Should().Be(expectedFieldCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_use_select_all_for_multiple_entities_and_additional_field_successfully(int version, int expected = 52)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var expectedFieldCount = 1;
            var rowCount = 0;
            var fieldCount = 0;

            expectedFieldCount += (dbo.Person as Table).Fields.Count();
            expectedFieldCount += (dbo.Address as Table).Fields.Count();
            expectedFieldCount += (dbo.PersonAddress as Table).Fields.Count();

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person)
                    .Concat(dbex.SelectAllFor(dbo.Address))
                    .Concat(dbex.SelectAllFor(dbo.PersonAddress)),
                    dbo.PersonAddress.AddressId.As("foo")
                )
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id);

            //when               
            await exp.ExecuteAsync(reader =>
                {
                    if (rowCount == 0)
                        fieldCount = reader.FieldCount;
                    rowCount++;
                });

            //then
            rowCount.Should().Be(expected);
            fieldCount.Should().Be(expectedFieldCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_use_select_all_for_multiple_entities_and_alias_each_with_static_prefix_execute_successfully(int version, int expected = 52)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person, "Person_")
                    .Concat(dbex.SelectAllFor(dbo.Address, "Address_"))
                    .Concat(dbex.SelectAllFor(dbo.PersonAddress, "PersonAddress_"))
                )
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id);

            //when               
            var persons = await exp.ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
            ((int)persons.First().Person_Id).Should().BeGreaterThan(0);
            ((int)persons.First().Address_Id).Should().BeGreaterThan(0);
            ((int)persons.First().PersonAddress_Id).Should().BeGreaterThan(0);
            ((string)persons.First().Person_FirstName).Should().NotBeNull();
            ((int)persons.First().PersonAddress_PersonId).Should().BeGreaterThan(0);
            ((string)persons.First().Address_Line1).Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_use_select_all_for_multiple_entities_and_alias_only_id_fields_with_prefix_execute_successfully(int version, int expected = 52)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            static string aliasPerson(string name) => new List<string> { nameof(dbo.Person.Id), nameof(dbo.Person.DateCreated), nameof(dbo.Person.DateUpdated) }.Contains(name) ? $"{nameof(dbo.Person)}_{name}" : name;
            static string aliasAddress(string name) => new List<string> { nameof(dbo.Address.Id), nameof(dbo.Address.DateCreated), nameof(dbo.Address.DateUpdated) }.Contains(name) ? $"{nameof(dbo.Address)}_{name}" : name;
            static string aliasPersonAddress(string name) => new List<string> { nameof(dbo.PersonAddress.Id), nameof(dbo.PersonAddress.DateCreated) }.Contains(name) ? $"{nameof(dbo.PersonAddress)}_{name}" : name;

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person, aliasPerson)
                    .Concat(dbex.SelectAllFor(dbo.Address, aliasAddress)
                    .Concat(dbex.SelectAllFor(dbo.PersonAddress, aliasPersonAddress)))
                )
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id);

            //when               
            var persons = await exp.ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
            ((int)persons.First().Person_Id).Should().BeGreaterThan(0);
            ((int)persons.First().Address_Id).Should().BeGreaterThan(0);
            ((int)persons.First().PersonAddress_Id).Should().BeGreaterThan(0);
            ((string)persons.First().FirstName).Should().NotBeNull();
            ((int)persons.First().PersonId).Should().BeGreaterThan(0);
            ((string)persons.First().Line1).Should().NotBeNull();
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_use_select_all_for_multiple_entities_and_alias_successfully_with_overriden_data_type(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            static string alias(string entity, string name)
            {
                switch (name)
                {
                    case nameof(dbo.Person.Id):
                    case nameof(dbo.Person.DateCreated):
                    case nameof(dbo.Person.DateUpdated):
                    case nameof(dbo.Purchase.PersonId): return $"{entity}{name}";
                    default: return name;
                }
            };

            //when
            var persons = db.SelectMany(
                dbex.SelectAllFor(dbo.Person, name => alias(nameof(Person), name))
                .Concat(dbex.SelectAllFor(dbo.Purchase, name => alias(nameof(Purchase), name)))
            )
            .From(dbo.Person)
            .InnerJoin(dbo.Purchase).On(dbo.Person.Id == dbo.Purchase.PersonId)
            .Execute();

            //then
            persons.Should().HaveCount(expected);
        }
    }
}
