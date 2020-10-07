using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Operation", "IN")]
    public class In : ExecutorTestBase
    {
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
