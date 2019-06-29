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
        [Theory]
        [InlineData(2014)]
        public void Does_select_for_single_value_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;

            //when
            exp = db.SelectOne(sec.Person.Id)
               .From(sec.Person);

            expressionSet = (exp as IDbExpressionSetProvider).Expression;

            //then
            expressionSet.StatementExecutionType.Should().Be(SqlStatementExecutionType.SelectOneValue);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Item2.Equals(sec.Person.Id))
                .Which.Item2.Should().BeOfType<Int32FieldExpression<Person>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Person>>()
                .And.Equals(sec.Person);
        }

        [Theory]
        [InlineData(2014)]
        public void Does_select_for_multiple_values_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp;
            ExpressionSet expressionSet;

            //when
            exp = db.SelectOne(sec.Person.Id, sec.Person.DateCreated)
               .From(sec.Person);

            expressionSet = (exp as IDbExpressionSetProvider).Expression;

            //then
            expressionSet.StatementExecutionType.Should().Be(SqlStatementExecutionType.SelectOneDynamic);

            expressionSet.Select.Expressions.Should().HaveCount(2);

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Item2.Equals(sec.Person.Id))
                .Which.Item2.Should().BeOfType<Int32FieldExpression<Person>>();

            expressionSet.Select.Expressions.Should().ContainSingle(x => x.Item2.Equals(sec.Person.DateCreated))
                .Which.Item2.Should().BeOfType<DateTimeFieldExpression<Person>>();

            expressionSet.BaseEntity.Should().NotBeNull()
                .And.BeAssignableTo<EntityExpression<Person>>()
                .And.Equals(sec.Person);
        }
    }
}
