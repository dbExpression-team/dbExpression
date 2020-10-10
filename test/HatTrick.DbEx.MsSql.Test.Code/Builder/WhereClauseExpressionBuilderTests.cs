using DbEx.DataService;
using DbEx.secData;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Builder.Syntax;
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
            QueryExpression expressionSet;
            FilterExpression idFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0);

            expressionSet = (exp as IQueryExpressionProvider).Expression;
            idFilter = (FilterExpression)expressionSet.Where.LeftArg;

            //then
            idFilter.Should().NotBeNull();
            idFilter.LeftArg.Should().BeOfType<Int32ExpressionMediator>();
            idFilter.LeftArg.Expression.Should().BeOfType<Int32FieldExpression<Person>>();
            idFilter.LeftArg.Expression.Should().Be(sec.Person.Id);
            idFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<int>>();
            idFilter.RightArg.Expression.As<LiteralExpression<int>>().Expression.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_for_single_value_with_multiple_where_clauses_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            QueryExpression expressionSet;
            FilterExpression idFilter;
            FilterExpression ssnFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX");

            expressionSet = (exp as IQueryExpressionProvider).Expression;
            idFilter = (FilterExpression)expressionSet.Where.LeftArg;
            ssnFilter = (FilterExpression)expressionSet.Where.RightArg;

            //then
            expressionSet.Where.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.Should().NotBeNull();
            idFilter.LeftArg.Should().BeOfType<Int32ExpressionMediator>();
            idFilter.LeftArg.Expression.Should().BeOfType<Int32FieldExpression<Person>>();
            idFilter.LeftArg.Expression.Should().Be(sec.Person.Id);
            idFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<int>>();
            idFilter.RightArg.Expression.As<LiteralExpression<int>>().Expression.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.LeftArg.Expression.Should().BeOfType<StringFieldExpression<Person>>();
            ssnFilter.LeftArg.Expression.Should().Be(sec.Person.SSN);
            ssnFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<string>>();
            ssnFilter.RightArg.Expression.As<LiteralExpression<string>>().Expression.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
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

            filterSet = (exp as IQueryExpressionProvider).Expression.Where;

            idFilter = (filterSet.LeftArg as FilterExpressionSet).LeftArg as FilterExpression;
            ssnFilter = (filterSet.LeftArg as FilterExpressionSet).RightArg as FilterExpression;
            dateCreatedFilter = filterSet.RightArg as FilterExpression;

            //then
            filterSet.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.Should().NotBeNull();
            idFilter.LeftArg.Should().BeOfType<Int32ExpressionMediator>();
            idFilter.LeftArg.Expression.Should().BeOfType<Int32FieldExpression<Person>>();
            idFilter.LeftArg.Expression.Should().Be(sec.Person.Id);
            idFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<int>>();
            idFilter.RightArg.Expression.As<LiteralExpression<int>>().Expression.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.LeftArg.Expression.Should().BeOfType<StringFieldExpression<Person>>();
            ssnFilter.LeftArg.Expression.Should().Be(sec.Person.SSN);
            ssnFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<string>>();
            ssnFilter.RightArg.Expression.As<LiteralExpression<string>>().Expression.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            dateCreatedFilter.Should().NotBeNull();
            dateCreatedFilter.LeftArg.Expression.Should().BeOfType<DateTimeOffsetFieldExpression<Person>>();
            dateCreatedFilter.LeftArg.Expression.Should().Be(sec.Person.DateCreated);
            dateCreatedFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<DateTimeOffset>>();
            dateCreatedFilter.RightArg.Expression.As<LiteralExpression<DateTimeOffset>>().Expression.Should().Be((DateTimeOffset)now);
            dateCreatedFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);
        }
    }
}
