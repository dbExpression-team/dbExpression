using DbEx.DataService;
using DbEx.secData;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Builder
{
    [Trait("Statement", "SELECT")]
    public class SelectExpressionBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_for_single_value_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            SelectValueContinuation<int> builder;
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

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_for_multiple_values_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            SelectDynamicContinuation builder;
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
