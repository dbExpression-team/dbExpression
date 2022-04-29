using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Platform-Version", "v2005")]
    public partial  class SelectMany
    {
        [Theory]
        [InlineData(2005, 5, 5, 5)]
        [InlineData(2005, 0, 5, 5)]
        [InlineData(2005, 14, 5, 1)]
        public void Can_retrieve_page_of_purchase_records_using_cte_for_v2005(int version, int offset, int limit, int expectedCount)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Purchase.PersonId)
                .From(dbo.Purchase)
                .OrderBy(dbo.Purchase.PersonId)
                .Offset(offset)
                .Limit(limit);

            //when               
            IList<int> ids = exp.Execute();

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(2005, 5, 1000, 1)]
        [InlineData(2005, 0, 1000, 6)]
        [InlineData(2005, 0, 2, 3)]
        public void Can_retrieve_page_of_purchase_records_using_distinct_and_cte_for_v2005(int version, int offset, int limit, int expectedCount)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(dbo.Purchase.PersonId)
                .Distinct()
                .From(dbo.Purchase)
                .OrderBy(dbo.Purchase.PersonId)
                .Offset(offset)
                .Limit(limit);

            //when               
            IList<int> ids = exp.Execute();

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(2005, 50)]
        public void Can_execute_trim_function_for_v2005(int version, int expectedCount)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            IList<string> persons = db.SelectMany(db.fx.Trim(dbo.Person.FirstName))
                .From(dbo.Person)
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }
    }
}
