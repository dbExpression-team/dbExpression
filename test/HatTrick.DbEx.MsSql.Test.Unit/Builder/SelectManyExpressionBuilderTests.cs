using v2019DbEx.DataService;
using v2019DbEx.secData;
using v2019DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Builder
{
    [Trait("Statement", "SELECT")]
    public class SelectManyExpressionBuilderTests : TestBase
    {
        [Fact]
        public void Does_select_many_for_single_field_result_in_valid_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            SelectValuesContinuation<v2019MsSqlDb, int> builder;
            SelectQueryExpression expressionSet;

            //when
            builder = db.SelectMany(sec.Person.Id)
               .From(sec.Person);

            expressionSet = ((builder as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;

            //then
            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Equals(sec.Person.Id))
                .Which.Expression.Should().BeOfType<PersonEntity.IdField>();

            expressionSet.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
        }

        [Fact]
        public void Does_select_many_for_multiple_values_result_in_valid_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            SelectDynamicsContinuation<v2019MsSqlDb> builder;
            SelectQueryExpression expressionSet;

            //when
            builder = db.SelectMany(sec.Person.Id, sec.Person.DateCreated)
               .From(sec.Person);

            expressionSet = ((builder as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;

            //then
            expressionSet.Select.Expressions.Should().HaveCount(2);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Equals(sec.Person.Id))
                .Which.Expression.Should().BeOfType<PersonEntity.IdField>();

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Equals(sec.Person.DateCreated))
                .Which.Expression.Should().BeOfType<PersonEntity.DateCreatedField>();

            expressionSet.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
        }
    }
}
