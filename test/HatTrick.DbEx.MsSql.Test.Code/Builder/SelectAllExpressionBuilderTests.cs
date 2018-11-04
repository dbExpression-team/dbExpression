using DataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;

using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Builder
{
    public class SelectAllExpressionBuilderTests : TestBase
    {
        [Fact]
        public void Does_select_all_for_single_field_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;
            //when
            exp = db.SelectAll(sec.Person.Id)
               .From(sec.Person);

            expressionSet = (exp as IExpressionProvider).GetExpression();

            //then
            expressionSet.ExecutionContext.Should().Be(ExecutionContext.GetValueList);

            expressionSet.Select.Expressions.Should().ContainSingle()
                .Which.Should().BeOfType<SelectExpression>()
                    .Which.Expression.Should().BeOfType<(Type, object)>()
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
        public void Does_select_all_for_multiple_values_result_in_valid_expression()
        {
            //given
            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;

            //when
            exp = db.SelectAll(sec.Person.Id, sec.Person.DateCreated)
               .From(sec.Person);

            expressionSet = (exp as IExpressionProvider).GetExpression();

            //then
            expressionSet.ExecutionContext.Should().Be(ExecutionContext.GetDynamicList);

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
