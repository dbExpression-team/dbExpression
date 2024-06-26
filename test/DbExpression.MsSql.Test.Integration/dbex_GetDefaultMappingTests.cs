using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public partial class dbex_GetDefaultMappingTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(50)]
        public async Task Can_select_person_entity_and_map_using_default_mapping_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = await exp.ExecuteAsync(dbex.GetDefaultMappingFor(dbo.Person));

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(50)]
        public async Task Can_use_select_all_for_person_entity_and_map_using_default_mapping_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
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
        [InlineData(52)]
        public async Task Can_use_select_all_for_person_entity_and_additional_field_and_map_using_default_mapping_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
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
                    var addressId = row.ReadField()!.GetValue<int>();
                    persons.Add((person, addressId));
                }
            );

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(52)]
        public async Task Can_use_select_all_for_person_and_address_entity_and_map_using_default_mappings_execute_successfully(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
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
