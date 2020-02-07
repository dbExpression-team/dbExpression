using FluentAssertions;
using DbEx.DataService;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;
using DbEx.Data.sec;

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
            ExpressionSet expressionSet;
            FilterExpression idFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0);

            expressionSet = (exp as IDbExpressionSetProvider).Expression;
            idFilter = expressionSet.Where?.Expression?.LeftPart.Item2 as FilterExpression;

            //then
            idFilter.Should().NotBeNull();
            idFilter.Expression.LeftPart.Item1.Should().Be<Int32FieldExpression<Person>>();
            idFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.Expression.RightPart.Item1.Should().Be<LiteralExpression<int>>();
            idFilter.Expression.RightPart.Item2.As<LiteralExpression<int>>().Expression.Item2.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_for_single_value_with_multiple_where_clauses_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;
            FilterExpression idFilter;
            FilterExpression ssnFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX");

            expressionSet = (exp as IDbExpressionSetProvider).Expression;
            idFilter = (FilterExpression)(expressionSet.Where?.Expression as DbExpressionPair)?.LeftPart.Item2;
            ssnFilter = (FilterExpression)(expressionSet.Where?.Expression as DbExpressionPair)?.RightPart.Item2;

            //then
            expressionSet.Where.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.Should().NotBeNull();
            idFilter.Expression.LeftPart.Item1.Should().Be<Int32FieldExpression<Person>>();
            idFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.Expression.RightPart.Item1.Should().Be<LiteralExpression<int>>();
            idFilter.Expression.RightPart.Item2.As<LiteralExpression<int>>().Expression.Item2.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.Expression.LeftPart.Item1.Should().Be<StringFieldExpression<Person>>();
            ssnFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.SSN);
            ssnFilter.Expression.RightPart.Item1.Should().Be<LiteralExpression<string>>();
            ssnFilter.Expression.RightPart.Item2.As<LiteralExpression<string>>().Expression.Item2.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_for_single_value_with_child_where_clauses_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;
            FilterExpression idFilter;
            FilterExpression ssnFilter;
            FilterExpression dateCreatedFilter;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX" & sec.Person.DateCreated != new DateTime(2000,1,1));

            expressionSet = (exp as IDbExpressionSetProvider).Expression;
            var where = expressionSet.Where.Expression as DbExpressionPair;

            idFilter = (FilterExpression)((FilterExpressionSet)where?.LeftPart.Item2).Expression.LeftPart.Item2;
            ssnFilter = (FilterExpression)((FilterExpressionSet)where?.LeftPart.Item2).Expression.RightPart.Item2;
            dateCreatedFilter = (FilterExpression)where?.RightPart.Item2;

            //then
            expressionSet.Where.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.Should().NotBeNull();
            idFilter.Expression.LeftPart.Item1.Should().Be<Int32FieldExpression<Person>>();
            idFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.Expression.RightPart.Item1.Should().Be<LiteralExpression<int>>();
            idFilter.Expression.RightPart.Item2.As<LiteralExpression<int>>().Expression.Item2.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.Expression.LeftPart.Item1.Should().Be<StringFieldExpression<Person>>();
            ssnFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.SSN);
            ssnFilter.Expression.RightPart.Item1.Should().Be<LiteralExpression<string>>();
            ssnFilter.Expression.RightPart.Item2.As<LiteralExpression<string>>().Expression.Item2.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            dateCreatedFilter.Should().NotBeNull();
            dateCreatedFilter.Expression.LeftPart.Item1.Should().Be<DateTimeFieldExpression<Person>>();
            dateCreatedFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.DateCreated);
            dateCreatedFilter.Expression.RightPart.Item1.Should().Be<LiteralExpression<DateTime>>();
            dateCreatedFilter.Expression.RightPart.Item2.As<LiteralExpression<DateTime>>().Expression.Item2.Should().Be(new DateTime(2000, 1, 1));
            dateCreatedFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);
        }
    }
}
