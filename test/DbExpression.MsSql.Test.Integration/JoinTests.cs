using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public partial class JoinTests : ResetDatabaseNotRequired
    {
        [Theory]
        [Trait("Operation", "INNER JOIN")]
        [InlineData(14)]
        public void Does_persons_with_address_and_address_id_constrained_to_value_in_join_condition_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId & dbo.PersonAddress.AddressId == 1);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "INNER JOIN")]
        [InlineData(50)]
        public void Does_persons_joined_back_to_persons_on_firstname_and_lastname_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbex.Alias<int>("joined", "Id"))
                .From(dbo.Person)
                .InnerJoin(dbo.Person.As("joined")).On(dbo.Person.FirstName == ("joined", "FirstName") & dbo.Person.LastName == ("joined", "LastName"));

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "INNER JOIN")]
        [InlineData("Kyle", 1)]
        public void Does_persons_joined_back_to_persons_on_firstname_and_lastname_with_where_clause_succeed(string firstName, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbex.Alias<int>("joined", "Id"))
                .From(dbo.Person)
                .InnerJoin(dbo.Person.As("joined")).On(dbo.Person.FirstName == ("joined", "FirstName") & dbo.Person.LastName == ("joined", "LastName"))
                .Where(dbo.Person.FirstName == firstName);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "DISTINCT")]
        [Trait("Operation", "IN")]
        [Trait("Operation", "INNER JOIN")]
        [InlineData("Kyle", 1, 3)]
        public void Does_persons_joined_to_personaddress_joined_to_address_with_in_condition_on_addresstype_and_where_clause_succeed(string firstName, int expectedCount, int expectedId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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

        [Theory]
        [Trait("Operation", "CROSS JOIN")]
        [InlineData("Kyle", 52)]
        public void Does_persons_cross_joined_to_personaddress_with_where_clause_succeed(string firstName, int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person, "Person").Concat(dbex.SelectAllFor(dbo.PersonAddress, "PersonAddress"))
                )
                .From(dbo.Person)
                .CrossJoin(dbo.PersonAddress)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }
    }
}
