using Generated.DataService;
using HatTrick.DbEx.Sql.Builder;
using Xunit;

using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class SelectAllPersonTests : IntegrationTestBase
    {
        [Fact]
        public void Does_select_all_for_single_field_result_in_valid_expression()
        {
            //given

            //when
            var exp = db.SelectAll(dbo.Person.Id)
               .From(dbo.Person);               
               
            var persons = exp.Execute();

            //then
            Assert.NotNull(persons);
        }
    }
}
