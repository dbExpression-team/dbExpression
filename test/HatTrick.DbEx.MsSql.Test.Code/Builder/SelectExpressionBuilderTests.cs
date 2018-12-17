using FluentAssertions;
using DataService;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Builder
{
    [Trait("Statement", "SELECT")]
    public class SelectExpressionBuilderTests : TestBase
    {
        [Fact]
        public void Does_select_for_single_value_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person);

            expressionSet = (exp as IExpressionProvider).GetExpression();

            //then
            expressionSet.ExecutionContext.Should().Be(ExecutionContext.GetValue);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Item2.Equals(sec.Person.Id))
                .Which.Item2.Should().BeOfType<FieldExpression<int>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Data.sec.Person>>()
                .And.Equals(sec.Person);
        }

        [Fact]
        public void Does_select_for_multiple_values_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;

            //when
            exp = db.SelectOne(sec.Person.Id, sec.Person.DateCreated)
               .From(sec.Person);

            expressionSet = (exp as IExpressionProvider).GetExpression();

            //then
            expressionSet.ExecutionContext.Should().Be(ExecutionContext.GetDynamic);

            expressionSet.Select.Expressions.Should().HaveCount(2);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Item2.Equals(sec.Person.Id))
                .Which.Item2.Should().BeOfType<FieldExpression<int>>();

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Item2.Equals(sec.Person.DateCreated))
                .Which.Item2.Should().BeOfType<FieldExpression<DateTime>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Data.sec.Person>>()
                .And.Equals(sec.Person);
        }
    }
}
