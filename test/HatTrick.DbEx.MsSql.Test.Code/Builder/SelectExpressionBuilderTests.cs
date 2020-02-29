using FluentAssertions;
using DbEx.DataService;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;
using Xunit;
using DbEx.Data.sec;

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

            expressionSet = (exp as IDbExpressionSetProvider).Expression;

            //then
            expressionSet.StatementExecutionType.Should().Be(SqlStatementExecutionType.SelectOneValue);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Object.Equals(sec.Person.Id))
                .Which.Expression.Object.Should().BeOfType<Int32FieldExpression<Person>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Person>>()
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

            expressionSet = (exp as IDbExpressionSetProvider).Expression;

            //then
            expressionSet.StatementExecutionType.Should().Be(SqlStatementExecutionType.SelectOneDynamic);

            expressionSet.Select.Expressions.Should().HaveCount(2);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Object.Equals(sec.Person.Id))
                .Which.Expression.Object.Should().BeOfType<Int32FieldExpression<Person>>();

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Expression.Object.Equals(sec.Person.DateCreated))
                .Which.Expression.Object.Should().BeOfType<DateTimeFieldExpression<Person>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Person>>()
                .And.Equals(sec.Person);
        }
    }
}
