using v2019DbEx.DataService;
using v2019DbEx.secData;
using v2019DbEx.secDataService;
using FluentAssertions;
using DbExpression.Sql;
using DbExpression.Sql.Builder;
using DbExpression.Sql.Expression;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Builder
{
    [Trait("Statement", "SELECT")]
    public class SelectExpressionBuilderTests : TestBase
    {
        [Fact]
        public void Does_select_for_single_value_result_in_valid_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            SelectValueContinuation<v2019MsSqlDb, int> builder;
            SelectQueryExpression expression;

            //when
            builder = db.SelectOne(sec.Person.Id)
               .From(sec.Person);

            expression = ((builder as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;

            //then
            expression.Select.Expressions.Should().ContainSingle()
                .Which.Expression.Should().BeOfType<PersonEntity.IdField>();

            expression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
        }

        [Fact]
        public void Does_select_for_multiple_values_result_in_valid_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            SelectDynamicContinuation<v2019MsSqlDb> builder;
            SelectQueryExpression expression;

            //when
            builder = db.SelectOne(sec.Person.Id, sec.Person.DateCreated)
               .From(sec.Person);

            expression = ((builder as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;

            //then
            expression.Select.Expressions.Should().HaveCount(2);

            expression.Select.Expressions.Should().Contain(x => x.Expression.Equals(sec.Person.Id))
                .Which.Expression.Should().BeOfType<PersonEntity.IdField>();

            expression.Select.Expressions.Should().ContainSingle(x => x.Expression.Equals(sec.Person.DateCreated))
                .Which.Expression.Should().BeOfType<PersonEntity.DateCreatedField>();

            expression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
        }
    }
}
