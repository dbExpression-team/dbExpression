using Data;
using Data.dbo;
using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using System.Linq;
using Xunit;
using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectMany : ExecutorTestBase
    {
        [Theory]
        [InlineData(2012, 50)]
        [InlineData(2014, 50)]
        public void Are_there_50_person_records(int version, int expectedCount)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Person>()
                .From(dbo.Person);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(2012, 15)]
        [InlineData(2014, 15)]
        public void Are_there_15_purchase_records(int version, int expectedCount)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<Purchase>()
               .From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(2012, 1)]
        [InlineData(2014, 1)]
        public void Can_retrieve_page_of_purchase_records(int version, int expectedCount)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(dbo.Purchase.PersonId)
                .Distinct()
                .From(dbo.Purchase)
                .Skip(5)
                .Limit(1000)
                .OrderBy(dbo.Purchase.PersonId);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }
}
