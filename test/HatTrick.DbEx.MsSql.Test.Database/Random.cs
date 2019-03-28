using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database
{
    public class Random : ExecutorTestBase
    {
        [Theory]
        [InlineData(2012, 17)]
        [InlineData(2014, 17)]
        public void Does_select_all_for_single_field_result_in_valid_expression(int version, int count)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var persons = db.SelectAll(
                    dbo.Person.Id.As("foo"),
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    db.Count(dbo.Person_Address.Id).As("person_count")
                ).Distinct()
                .From(dbo.Person)
                .InnerJoin(dbo.Person_Address).On(dbo.Person.Id == dbo.Person_Address.PersonId)
                .GroupBy(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .Having(
                    db.Count(dbo.Person_Address.Id) > 1
                )
                .OrderBy(
                    dbo.Person.LastName,
                    dbo.Person.FirstName.Desc
                )
                .Execute();

            //then
            persons.Count().Should().Be(count);
        }
        
    }
}
