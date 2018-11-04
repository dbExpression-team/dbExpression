using FluentAssertions;
using DataService;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;

using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Builder
{
    public class WhereClauseExpressionBuilderTests
    {
        [Fact]
        public void Does_select_for_single_value_with_where_clause_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;
            FilterExpression idFilter;

            //when
            exp = db.Select(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0);

            expressionSet = (exp as IExpressionProvider).GetExpression();
            idFilter = expressionSet.Where?.LeftPart.Item2 as FilterExpression;

            //then
            idFilter.Should().NotBeNull();
            idFilter.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<int>>();
            idFilter.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.RightPart.Item2.Should().Be(0);
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
            exp = db.Select(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX");

            expressionSet = (exp as IExpressionProvider).GetExpression();
            idFilter = (FilterExpression)(expressionSet.Where?.LeftPart.Item2 as FilterExpressionSet)?.LeftPart.Item2;
            ssnFilter = (FilterExpression)(expressionSet.Where?.RightPart.Item2 as FilterExpressionSet)?.LeftPart.Item2;

            //then
            expressionSet.Where.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            expressionSet.Where.LeftPart.Item1.Should().Be(typeof(FilterExpressionSet));
            expressionSet.Where.LeftPart.Item2.Should().BeAssignableTo<FilterExpressionSet>()
               .Which.LeftPart.Item1.Should().BeAssignableTo<FilterExpression>();

            idFilter.Should().NotBeNull();
            idFilter.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<int>>();
            idFilter.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.RightPart.Item2.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<string>>();
            ssnFilter.LeftPart.Item2.Should().Be(sec.Person.SSN);
            ssnFilter.RightPart.Item2.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
        }

        [Fact]
        public void Does_select_for_single_value_with_child_where_clauses_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;
            FilterExpression idFilter;
            FilterExpression ssnFilter;
            FilterExpression dateCreatedFilter;

            //when
            exp = db.Select(sec.Person.Id)
               .From(sec.Person)
               .Where(sec.Person.Id > 0 & sec.Person.SSN == "XXX" & sec.Person.DateCreated != new DateTime(2000,1,1));

            expressionSet = (exp as IExpressionProvider).GetExpression();
            idFilter = (FilterExpression)((FilterExpressionSet)(expressionSet.Where?.LeftPart.Item2 as FilterExpressionSet)?.LeftPart.Item2)?.LeftPart.Item2;
            ssnFilter = (FilterExpression)((FilterExpressionSet)(expressionSet.Where?.LeftPart.Item2 as FilterExpressionSet)?.RightPart.Item2)?.LeftPart.Item2;
            dateCreatedFilter = (FilterExpression)expressionSet.Where?.RightPart.Item2;

            //then
            expressionSet.Where.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            expressionSet.Where.LeftPart.Item1.Should().Be(typeof(FilterExpressionSet));
            expressionSet.Where.LeftPart.Item2.Should().BeAssignableTo<FilterExpressionSet>()
               .Which.LeftPart.Item1.Should().BeAssignableTo<FilterExpressionSet>();

            idFilter.Should().NotBeNull();
            idFilter.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<int>>();
            idFilter.LeftPart.Item2.Should().Be(sec.Person.Id);
            idFilter.RightPart.Item2.Should().Be(0);
            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            ssnFilter.Should().NotBeNull();
            ssnFilter.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<string>>();
            ssnFilter.LeftPart.Item2.Should().Be(sec.Person.SSN);
            ssnFilter.RightPart.Item2.Should().Be("XXX");
            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            dateCreatedFilter.Should().NotBeNull();
            dateCreatedFilter.LeftPart.Item1.Should().BeAssignableTo<FieldExpression<DateTime>>();
            dateCreatedFilter.LeftPart.Item2.Should().Be(sec.Person.DateCreated);
            dateCreatedFilter.RightPart.Item2.Should().Be(new DateTime(2000, 1, 1));
            dateCreatedFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);
        }
    }
}
