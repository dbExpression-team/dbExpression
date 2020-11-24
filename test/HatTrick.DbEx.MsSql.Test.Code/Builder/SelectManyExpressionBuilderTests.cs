using DbEx.DataService;
using DbEx.secData;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Builder
{
    [Trait("Statement", "SELECT")]
    public class SelectManyExpressionBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_for_single_field_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            SelectQueryExpression expressionSet;
            //when
            exp = db.SelectMany(sec.Person.Id)
               .From(sec.Person);

            expressionSet = exp.Expression as SelectQueryExpression;

            //then
            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Equals(sec.Person.Id))
                .Which.Expression.Should().BeOfType<Int32FieldExpression<Person>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Person>>()
                .And.Equals(sec.Person);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_many_for_multiple_values_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            SelectQueryExpression expressionSet;

            //when
            exp = db.SelectMany(sec.Person.Id, sec.Person.DateCreated)
               .From(sec.Person);

            expressionSet = exp.Expression as SelectQueryExpression;

            //then
            expressionSet.Select.Expressions.Should().HaveCount(2);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Equals(sec.Person.Id))
                .Which.Expression.Should().BeOfType<Int32FieldExpression<Person>>();

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Equals(sec.Person.DateCreated))
                .Which.Expression.Should().BeOfType<DateTimeOffsetFieldExpression<Person>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Person>>()
                .And.Equals(sec.Person);
        }
    }
}
