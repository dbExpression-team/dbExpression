using DbEx.Data;
using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class Join : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "INNER JOIN")]
        public void Does_persons_with_address_and_address_id_constrained_to_value_in_join_condition_succeed(int version, int expected = 14)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId & dbo.PersonAddress.AddressId == 1);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "INNER JOIN")]
        public void Does_persons_joined_back_to_persons_on_firstname_and_lastname_succeed(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(db.alias("joined", "Id").AsInt32())
                .From(dbo.Person)
                .InnerJoin(dbo.Person.As("joined")).On(dbo.Person.FirstName == db.alias("joined", "FirstName").AsString() & dbo.Person.LastName == db.alias("joined", "LastName").AsString());

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "INNER JOIN")]
        public void Does_persons_joined_back_to_persons_on_firstname_and_lastname_with_where_clause_succeed(int version, string firstName = "Kyle", int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(db.alias("joined", "Id").AsInt32())
                .From(dbo.Person)
                .InnerJoin(dbo.Person.As("joined")).On(dbo.Person.FirstName == db.alias("joined", "FirstName").AsString() & dbo.Person.LastName == db.alias("joined", "LastName").AsString())
                .Where(dbo.Person.FirstName == firstName);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "DISTINCT")]
        [Trait("Operation", "IN")]
        [Trait("Operation", "INNER JOIN")]
        public void Does_persons_joined_to_personaddress_joined_to_address_with_in_condition_on_addresstype_and_where_clause_succeed(int version, string firstName = "Kyle", int expectedCount = 1, int expectedId = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Address.Id)
                .Distinct()
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.AddressId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id & dbo.Address.AddressType.In(AddressType.Billing, AddressType.Mailing))
                .Where(dbo.Person.FirstName == firstName);

            //when               
            var addressIds = exp.Execute();

            //then
            addressIds.Should().HaveCount(expectedCount);
            ((int)addressIds.First()).Should().Be(expectedId);
        }
    }
}
