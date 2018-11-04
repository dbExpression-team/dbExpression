using DataService;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Extensions.Builder;
using Xunit;

using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    public class SelectAllPersonTests : ExecutorTestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Does_select_all_for_single_field_have_results(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectAll(dbo.Person.Id)
               .From(dbo.Person);               

            //when               
            var persons = exp.Execute();

            //then
            Assert.NotNull(persons);
        }
    }
}
