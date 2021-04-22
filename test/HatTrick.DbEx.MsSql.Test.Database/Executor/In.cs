using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Operation", "IN")]
    public class In : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_persons_using_empty_enumerable_result_in_no_output(int version, int expectedCount = 0)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var personIds = Enumerable.Empty<int>();

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id.In(personIds))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_addresses_using_a_null_value_as_first_element_in_the_enumerable_result_in_no_output(int version, int expectedCount = 2)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var lines = new List<string> { null, "Box 13", "Apt. 42" };

            //when
            var addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .Where(dbo.Address.Line2.In(lines))
                .Execute();

            //then
            addresses.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_addresses_using_a_null_value_in_the_enumerable_result_in_correct_output(int version, int expectedCount = 2)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var lines = new List<string> { "Box 13", null, "Apt. 42" };

            //when
            var addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .Where(dbo.Address.Line2.In(lines))
                .Execute();

            //then
            addresses.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_addresses_using_a_null_values_for_every_element_of_the_enumerable_result_in_no_output(int version, int expectedCount = 0)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var lines = new List<string> { null, null, null, null };

            //when
            var addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .Where(dbo.Address.Line2.In(lines))
                .Execute();

            //then
            addresses.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_persons_using_enumerable_of_ids_result_in_correct_output(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var personIds = Enumerable.Range(1, 15);

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id.In(personIds))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_persons_using_params_of_ids_result_in_correct_output(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id.In(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_persons_using_enumerable_of_ids_exclusive_result_in_correct_output(int version, int expectedCount = 35)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var personIds = Enumerable.Range(1, 15);

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(!dbo.Person.Id.In(personIds))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_persons_using_params_of_ids_exclusive_result_in_correct_output(int version, int expectedCount = 35)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(!dbo.Person.Id.In(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15))
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_persons_using_enumerable_of_ids_appended_to_before_execution_result_in_correct_output(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var personIds = Enumerable.Range(1, 15).ToList();

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id.In(personIds));

            //when
            personIds.AddRange(Enumerable.Range(16, 35));
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }
    }
}
