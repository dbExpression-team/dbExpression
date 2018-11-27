using Data;
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
    public partial class SelectAll : ExecutorTestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Are_there_50_person_records(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectAll(dbo.Person.Id)
               .From(dbo.Person);

            //when               
            var persons = exp.Execute();

            //then
            persons.Should().HaveCount(50);
        }

        [Theory]
        [InlineData(2014)]
        public void Are_there_15_purchase_records(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectAll(dbo.Purchase.Id)
               .From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(15);
        }
    }
}
