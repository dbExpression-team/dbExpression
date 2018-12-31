using FluentAssertions;
using DataService;
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
        [InlineData(2014)]
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

            expressionSet = (exp as IExpressionProvider).GetExpression();
            idFilter = expressionSet.Where?.Expression?.LeftPart.Item2 as FilterExpression;

            //then
            idFilter.Should().NotBeNull();
            idFilter.Expression.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<int>>();
            idFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.Expression.RightPart.Item2.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);
        }

        [Theory]
        [InlineData(2014)]
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

            expressionSet = (exp as IExpressionProvider).GetExpression();
            idFilter = (FilterExpression)(expressionSet.Where?.Expression as DbExpressionPair)?.LeftPart.Item2;
            ssnFilter = (FilterExpression)(expressionSet.Where?.Expression as DbExpressionPair)?.RightPart.Item2;

            //then
            expressionSet.Where.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.Should().NotBeNull();
            idFilter.Expression.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<int>>();
            idFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.Expression.RightPart.Item2.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.Expression.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<string>>();
            ssnFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.SSN);
            ssnFilter.Expression.RightPart.Item2.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
        }

        [Theory]
        [InlineData(2014)]
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

            expressionSet = (exp as IExpressionProvider).GetExpression();
            var where = expressionSet.Where.Expression as DbExpressionPair;

            idFilter = (FilterExpression)((FilterExpressionSet)where?.LeftPart.Item2).Expression.LeftPart.Item2;
            ssnFilter = (FilterExpression)((FilterExpressionSet)where?.LeftPart.Item2).Expression.RightPart.Item2;
            dateCreatedFilter = (FilterExpression)where?.RightPart.Item2;

            //then
            expressionSet.Where.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.Should().NotBeNull();
            idFilter.Expression.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<int>>();
            idFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.Expression.RightPart.Item2.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.Expression.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<string>>();
            ssnFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.SSN);
            ssnFilter.Expression.RightPart.Item2.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            dateCreatedFilter.Should().NotBeNull();
            dateCreatedFilter.Expression.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<DateTime>>();
            dateCreatedFilter.Expression.LeftPart.Item2.Should().Be(sec.Person.DateCreated);
            dateCreatedFilter.Expression.RightPart.Item2.Should().Be(new DateTime(2000, 1, 1));
            dateCreatedFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);
        }
    }
}
