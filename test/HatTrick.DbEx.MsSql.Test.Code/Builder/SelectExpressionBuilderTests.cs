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
    public class SelectExpressionBuilderTests : TestBase
    {
        [Fact]
        public void Does_select_for_single_value_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;

            //when
            exp = db.Select(sec.Person.Id)
               .From(sec.Person);

            expressionSet = (exp as IExpressionProvider).GetExpression();

            //then
            expressionSet.ExecutionContext.Should().Be(ExecutionContext.GetValue);

            expressionSet.Select.Expressions.Should().ContainSingle()
                .Which.Should().BeOfType<SelectExpression>()
                    .Which.Expression.Should().BeOfType<(Type,object)>()
                        .Which.Item1.Should().BeAssignableTo<FieldExpression<int>>();

            expressionSet.Select.Expressions.Should().ContainSingle()
                .Which.Should().BeOfType<SelectExpression>()
                    .Which.Expression.Should().BeOfType<(Type, object)>()
                        .Which.Item2.Should().Equals(sec.Person.Id);

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
            exp = db.Select(sec.Person.Id, sec.Person.DateCreated)
               .From(sec.Person);

            expressionSet = (exp as IExpressionProvider).GetExpression();

            //then
            expressionSet.ExecutionContext.Should().Be(ExecutionContext.GetDynamic);

            expressionSet.Select.Expressions.Should().HaveCount(2);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Item2.Equals(sec.Person.Id))
                .Which.Should().BeOfType<SelectExpression>()
                    .Which.Expression.Item1.Should().BeAssignableTo<FieldExpression<int>>();

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Item2.Equals(sec.Person.DateCreated))
                .Which.Should().BeOfType<SelectExpression>()
                    .Which.Expression.Item1.Should().BeAssignableTo<FieldExpression<DateTime>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Data.sec.Person>>()
                .And.Equals(sec.Person);
        }
    }
}
