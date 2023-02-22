using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using v2005DbEx.DataService;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Platform-Version", "v2005")]
    public partial  class SelectManyTests
    {
        [Theory]
        [InlineData(5, 5, true, 5)]
        [InlineData(0, 5, true, 5)]
        [InlineData(14, 5, true, 1)]
        [InlineData(5, 5, false, 5)]
        [InlineData(0, 5, false, 5)]
        [InlineData(14, 5, false, 1)]
        public void Can_retrieve_page_of_purchase_records_using_cte_for_v2005(int offset, int limit, bool prependCommanOnSelect, int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2005MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(o => o.PrependCommaOnSelectClause = prependCommanOnSelect));

            var exp = db.SelectMany(dbo.Purchase.PersonId)
                .From(dbo.Purchase)
                .OrderBy(dbo.Purchase.PersonId)
                .Offset(offset)
                .Limit(limit);

            //when               
            IEnumerable<int> ids = exp.Execute();

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(5, 1000, true, 1)]
        [InlineData(0, 1000, true, 6)]
        [InlineData(0, 2, true, 2)]
        [InlineData(5, 1000, false, 1)]
        [InlineData(0, 1000, false, 6)]
        [InlineData(0, 2, false, 2)]
        public void Can_retrieve_page_of_purchase_records_using_distinct_and_cte_for_v2005(int offset, int limit, bool prependCommanOnSelect, int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2005MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(o => o.PrependCommaOnSelectClause = prependCommanOnSelect));

            var exp = db.SelectMany(dbo.Purchase.PersonId)
                .Distinct()
                .From(dbo.Purchase)
                .OrderBy(dbo.Purchase.PersonId)
                .Offset(offset)
                .Limit(limit);

            //when               
            IEnumerable<int> ids = exp.Execute();

            //then
            ids.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(true, 50)]
        [InlineData(false, 50)]
        public void Can_execute_ltrim_and_rtrim_functions_for_v2005(bool prependCommanOnSelect, int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2005MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(o => o.PrependCommaOnSelectClause = prependCommanOnSelect));

            //when
            IEnumerable<string> persons = db.SelectMany(db.fx.LTrim(db.fx.RTrim(dbo.Person.FirstName)))
                .From(dbo.Person)
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }
    }
}
