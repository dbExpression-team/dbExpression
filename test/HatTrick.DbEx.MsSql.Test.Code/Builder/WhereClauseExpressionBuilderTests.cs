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
        [Fact]
        public void Does_select_for_single_value_with_where_clause_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;
            FilterExpression idFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0);

            expressionSet = (exp as IDbExpressionSetProvider).Expression;
            idFilter = (FilterExpression)expressionSet.Where.LeftArg.Object;

            //then
            idFilter.Should().NotBeNull();
            idFilter.LeftArg.Should().BeOfType<Int32ExpressionMediator>();
            idFilter.LeftArg.Expression.Should().BeOfType<Int32FieldExpression<Person>>();
            idFilter.LeftArg.Expression.Should().Be(sec.Person.Id);
            idFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<int>>();
            idFilter.RightArg.Expression.As<LiteralExpression<int>>().Expression.Object.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);
        }

        [Fact]
        public void Does_select_for_single_value_with_multiple_where_clauses_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;
            FilterExpression idFilter;
            FilterExpression ssnFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX");

            expressionSet = (exp as IDbExpressionSetProvider).Expression;
            idFilter = (FilterExpression)expressionSet.Where.LeftArg.Object;
            ssnFilter = (FilterExpression)expressionSet.Where.RightArg.Object;

            //then
            expressionSet.Where.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.Should().NotBeNull();
            idFilter.LeftArg.Should().BeOfType<Int32ExpressionMediator>();
            idFilter.LeftArg.Expression.Should().BeOfType<Int32FieldExpression<Person>>();
            idFilter.LeftArg.Expression.Should().Be(sec.Person.Id);
            idFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<int>>();
            idFilter.RightArg.Expression.As<LiteralExpression<int>>().Expression.Object.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.LeftArg.Expression.Should().BeOfType<StringFieldExpression<Person>>();
            ssnFilter.LeftArg.Expression.Should().Be(sec.Person.SSN);
            ssnFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<string>>();
            ssnFilter.RightArg.Expression.As<LiteralExpression<string>>().Expression.Object.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
        }

        [Fact]
        public void Does_select_for_single_value_with_child_where_clauses_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            FilterExpressionSet filterSet;
            FilterExpression idFilter;
            FilterExpression ssnFilter;
            FilterExpression dateCreatedFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX" & sec.Person.DateCreated != new DateTime(2000,1,1));

            filterSet = (exp as IDbExpressionSetProvider).Expression.Where;

            idFilter = (filterSet.LeftArg.Object as FilterExpressionSet).LeftArg.Object as FilterExpression;
            ssnFilter = (filterSet.LeftArg.Object as FilterExpressionSet).RightArg.Object as FilterExpression;
            dateCreatedFilter = filterSet.RightArg.Object as FilterExpression;

            //then
            filterSet.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.Should().NotBeNull();
            idFilter.LeftArg.Should().BeOfType<Int32ExpressionMediator>();
            idFilter.LeftArg.Expression.Should().BeOfType<Int32FieldExpression<Person>>();
            idFilter.LeftArg.Expression.Should().Be(sec.Person.Id);
            idFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<int>>();
            idFilter.RightArg.Expression.As<LiteralExpression<int>>().Expression.Object.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.LeftArg.Expression.Should().BeOfType<StringFieldExpression<Person>>();
            ssnFilter.LeftArg.Expression.Should().Be(sec.Person.SSN);
            ssnFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<string>>();
            ssnFilter.RightArg.Expression.As<LiteralExpression<string>>().Expression.Object.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            dateCreatedFilter.Should().NotBeNull();
            dateCreatedFilter.LeftArg.Expression.Should().BeOfType<DateTimeFieldExpression<Person>>();
            dateCreatedFilter.LeftArg.Expression.Should().Be(sec.Person.DateCreated);
            dateCreatedFilter.RightArg.Expression.Should().BeOfType<LiteralExpression<DateTime>>();
            dateCreatedFilter.RightArg.Expression.As<LiteralExpression<DateTime>>().Expression.Object.Should().Be(new DateTime(2000, 1, 1));
            dateCreatedFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);
        }
    }
}
