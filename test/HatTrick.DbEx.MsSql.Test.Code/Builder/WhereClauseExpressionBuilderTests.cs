using DbEx.DataService;
using DbEx.secData;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Builder
{
    [Trait("Statement", "SELECT")]
    [Trait("Clause", "WHERE")]
    public class WhereClauseExpressionBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_for_single_value_with_where_clause_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            FilterExpressionSet filterSet;
            FilterExpression idFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0);

            filterSet = ((exp as IQueryExpressionProvider).Expression as SelectQueryExpression).Where;

            idFilter = filterSet.LeftArg as FilterExpression;

            //then
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            idFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<PersonEntity.IdField>()
                .And.Be(sec.Person.Id);

            idFilter.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_for_single_value_with_multiple_where_clauses_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            FilterExpressionSet filterSet;
            FilterExpression idFilter;
            FilterExpression ssnFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX");

            filterSet = ((exp as IQueryExpressionProvider).Expression as SelectQueryExpression).Where;

            idFilter = filterSet.LeftArg as FilterExpression;
            ssnFilter = filterSet.RightArg as FilterExpression;

            //then
            filterSet.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            idFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<PersonEntity.IdField>()
                .And.Be(sec.Person.Id);

            idFilter.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            ssnFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<PersonEntity.SSNField>()
                .And.Be(sec.Person.SSN);

            ssnFilter.RightArg
                .Should().BeOfType<LiteralExpression<string>>()
                .Which.Expression.Should().Be("XXX");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_for_single_value_with_child_where_clauses_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            FilterExpressionSet filterSet;
            FilterExpression idFilter;
            FilterExpression ssnFilter;
            FilterExpression dateCreatedFilter;

            var now = DateTime.UtcNow;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX" & sec.Person.DateCreated != now);

            filterSet = ((exp as IQueryExpressionProvider).Expression as SelectQueryExpression).Where;

            idFilter = (filterSet.LeftArg as FilterExpressionSet).LeftArg as FilterExpression;
            ssnFilter = (filterSet.LeftArg as FilterExpressionSet).RightArg as FilterExpression;
            dateCreatedFilter = filterSet.RightArg as FilterExpression;

            //then
            filterSet.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            idFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<PersonEntity.IdField>()
                .And.Be(sec.Person.Id);

            idFilter.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            ssnFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<PersonEntity.SSNField>()
                .And.Be(sec.Person.SSN);

            ssnFilter.RightArg
                .Should().BeOfType<LiteralExpression<string>>()
                .Which.Expression.Should().Be("XXX");

            dateCreatedFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            dateCreatedFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<PersonEntity.DateCreatedField>()
                .And.Be(sec.Person.DateCreated);

            dateCreatedFilter.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(now);
        }
    }
}
