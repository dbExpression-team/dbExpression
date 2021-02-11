using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class dbex_GetDefaultMapping : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_select_person_entity_and_map_using_default_mapping_execute_successfully(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(dbex.GetDefaultMappingFor(dbo.Person));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_use_select_all_for_person_entity_and_map_using_default_mapping_execute_successfully(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var persons = new List<Person>();
            var map = dbex.GetDefaultMappingFor(dbo.Person);

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person)
                )
                .From(dbo.Person);

            //when               
            await exp.ExecuteAsync(row =>
                {
                    var person = new Person();
                    map(row, person);
                    persons.Add(person);
                } 
            );

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_use_select_all_for_person_entity_and_additional_field_and_map_using_default_mapping_execute_successfully(int version, int expected = 52)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var persons = new List<(Person, int)>();
            var map = dbex.GetDefaultMappingFor(dbo.Person);

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person),
                    dbo.PersonAddress.AddressId
                )
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId);

            //when               
            await exp.ExecuteAsync(row =>
                {
                    var person = new Person();
                    map(row, person);
                    var addressId = row.ReadField().GetValue<int>();
                    persons.Add((person, addressId));
                }
            );

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_use_select_all_for_person_and_address_entity_and_map_using_default_mappings_execute_successfully(int version, int expected = 52)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var persons = new List<(Person, Address)>();
            var personMap = dbex.GetDefaultMappingFor(dbo.Person);
            var addressMap = dbex.GetDefaultMappingFor(dbo.Address);

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person)
                    .Concat(dbex.SelectAllFor(dbo.Address))
                )
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id);

            //when               
            await exp.ExecuteAsync(row =>
                {
                    var person = new Person();
                    personMap(row, person);
                    var address = new Address();
                    addressMap(row, address);
                    persons.Add((person, address));
                }
            );

            //then
            persons.Should().HaveCount(expected);
        }
    }
}
