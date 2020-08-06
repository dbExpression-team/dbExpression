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
    [Trait("Statement", "UPDATE")]
    public partial class Update : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname(int version, int id = 1, string expectedFirstName = "Foo")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(dbo.Person.FirstName.Set(expectedFirstName))
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            exp.Execute();

            //then
            var firstName = db.SelectOne(dbo.Person.FirstName).From(dbo.Person).Where(dbo.Person.Id == id).Execute();
            firstName.Should().Be(expectedFirstName);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_and_result_in_correct_records_affected(int version, int id = 1, string expectedFirstName = "Foo", int expectedRecordsAffected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(dbo.Person.FirstName.Set(expectedFirstName))
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expectedRecordsAffected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_and_lastname(int version, int id = 1, string expectedFirstName = "Foo", string expectedLastName = "Bar")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(
                    dbo.Person.FirstName.Set(expectedFirstName), 
                    dbo.Person.LastName.Set(expectedLastName)
                )
               .From(dbo.Person)
               .Where(dbo.Person.Id == id);

            //when               
            exp.Execute();

            //then
            var person = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == id).Execute();
            person.FirstName.Should().Be(expectedFirstName);
            person.LastName.Should().Be(expectedLastName);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_where_lastname(int version, string lastName = "Broflovski", string appendToFirstName = "]")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(
                    dbo.Person.FirstName.Set(dbo.Person.FirstName + appendToFirstName)
                )
               .From(dbo.Person)
               .Where(dbo.Person.LastName == lastName);

            //when               
            exp.Execute();

            //then
            var persons = db.SelectMany<Person>().From(dbo.Person).Where(dbo.Person.LastName == lastName).Execute();
            persons.Should().Match(x => x.All(y => y.FirstName.EndsWith(appendToFirstName)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Can_update_persons_firstname_where_lastname_result_in_correct_records_affected(int version, string lastName = "Broflovski", string appendToFirstName = "]", int expectedRecordsAffected = 4)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.Update(
                    dbo.Person.FirstName.Set(dbo.Person.FirstName + appendToFirstName)
                )
               .From(dbo.Person)
               .Where(dbo.Person.LastName == lastName);

            //when               
            var recordsAffected = exp.Execute();

            //then
            recordsAffected.Should().Be(expectedRecordsAffected);
        }
    }
}
