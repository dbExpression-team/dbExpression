using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Platform-Version", "v2005")]
    public partial  class SelectManyTests
    {
        [Theory]
        [InlineData(2005, 5, 5, true, 5)]
        [InlineData(2005, 0, 5, true, 5)]
        [InlineData(2005, 14, 5, true, 1)]
        [InlineData(2005, 5, 5, false, 5)]
        [InlineData(2005, 0, 5, false, 5)]
        [InlineData(2005, 14, 5, false, 1)]
        public void Can_retrieve_page_of_purchase_records_using_cte_for_v2005(int version, int offset, int limit, bool prependCommanOnSelect, int expectedCount)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ConfigureOutputSettings(o => o.PrependCommaOnSelectClause = prependCommanOnSelect));

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
        [InlineData(2005, 5, 1000, true, 1)]
        [InlineData(2005, 0, 1000, true, 6)]
        [InlineData(2005, 0, 2, true, 3)]
        [InlineData(2005, 5, 1000, false, 1)]
        [InlineData(2005, 0, 1000, false, 6)]
        [InlineData(2005, 0, 2, false, 3)]
        public void Can_retrieve_page_of_purchase_records_using_distinct_and_cte_for_v2005(int version, int offset, int limit, bool prependCommanOnSelect, int expectedCount)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ConfigureOutputSettings(o => o.PrependCommaOnSelectClause = prependCommanOnSelect));

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
        [InlineData(2005, true, 50)]
        [InlineData(2005, false, 50)]
        public void Can_execute_trim_function_for_v2005(int version, bool prependCommanOnSelect, int expectedCount)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.SqlStatements.Assembly.ConfigureOutputSettings(o => o.PrependCommaOnSelectClause = prependCommanOnSelect));

            //when
            IList<string> persons = db.SelectMany(db.fx.Trim(dbo.Person.FirstName))
                .From(dbo.Person)
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }
    }
}
