using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Operation", "INNER JOIN")]
    [Trait("Clause", "WHERE")]
    public partial class SelectManyTests
    {
        [Theory]
        [InlineData(35)]
        public void Does_filtering_by_billing_addresstype_equal_to_billing_have_35_records(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                .Where(dbo.Address.AddressType == AddressType.Billing);

            //when               
            IEnumerable<int> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(14)]
        public void Does_filtering_by_address_id_equal_to_1_have_14_records(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                .Where(dbo.Address.Id == 1);

            //when               
            IEnumerable<int> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(35)]
        public void Does_filtering_by_addresstype_equal_to_billing_and_address_id_not_equal_to_1_have_35_records(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Person.Id)
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                .Where(dbo.Address.AddressType == AddressType.Billing & dbo.Address.Id != 1);

            //when               
            IEnumerable<int> persons = exp.Execute();

            //then
            persons.Should().HaveCount(expected);
        }
    }
}
