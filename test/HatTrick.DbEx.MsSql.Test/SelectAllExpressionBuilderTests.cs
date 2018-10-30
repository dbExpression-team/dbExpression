using Generated.DataService;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;
using Xunit;

using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test
{
    public class SelectAllExpressionBuilderTests : ExpressionBuilderTests
    {
        [Fact]
        public void Does_select_all_for_single_field_result_in_valid_expression()
        {
            //given

            //when
            var exp = db.SelectAll(sec.Person.Id)
               .From(sec.Person);

            var provider = exp as IExpressionProvider;

            //then
            var select = provider.GetExpression().Select.Expressions;
            Assert.Equal(1, select.Count);
            Assert.True(select.First().Expression.Item1.IsAssignableFrom(typeof(FieldExpression<int>)));
            Assert.IsType<FieldExpression<int>>(select.First().Expression.Item2);
            Assert.Equal(sec.Person, provider.GetExpression().BaseEntity);
        }
    }
}
