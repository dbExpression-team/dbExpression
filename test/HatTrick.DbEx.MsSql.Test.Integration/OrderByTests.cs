
using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Operation", "ORDER BY")]
    public partial class OrderByTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_value_list_with_order_by_asc_succeed(int version, int expectedCount = 50, int expectedId = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            persons.First().Should().Be(expectedId);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_value_list_with_order_by_desc_succeed(int version, int expectedCount = 50, int expectedId = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            persons.First().Should().NotBe(expectedId);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_value_with_order_by_asc_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_value_with_order_by_desc_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().NotBe(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dynamic_value_list_with_order_by_asc_succeed(int version, int expectedCount = 50, int expectedId = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            ((int)persons.First().Id).Should().Be(expectedId);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dynamic_value_list_with_order_by_desc_succeed(int version, int expectedCount = 50, int expectedId = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            ((int)persons.First().Id).Should().NotBe(expectedId);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dynamic_value_with_order_by_asc_succeed(int version, int expectedId = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc);

            //when               
            var person = exp.Execute();

            //then
            ((int)person!.Id).Should().Be(expectedId);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dynamic_value_with_order_by_desc_succeed(int version, int expectedId = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc);

            //when               
            var person = exp.Execute();

            //then
            ((int)person!.Id).Should().NotBe(expectedId);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_entity_list_with_order_by_asc_succeed(int version, int expectedCount = 50, int expectedId = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            persons.First().Id.Should().Be(expectedId);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_entity_list_with_order_by_desc_succeed(int version, int expectedCount = 50, int expectedId = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
            persons.First().Should().NotBe(expectedId);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_entity_with_order_by_asc_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Asc);

            //when               
            var person = exp.Execute();

            //then
            person!.Id.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_entity_with_order_by_desc_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.Id.Desc);

            //when               
            var person = exp.Execute();

            //then
            person!.Id.Should().NotBe(expected);
        }
    }
}
