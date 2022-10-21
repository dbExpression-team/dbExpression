using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    [Trait("Statement", "SELECT")]
    [Trait("Clause", "WHERE")]
    public class ArithmeticExpressionTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_expression_of_a_field_added_to_an_int_literal_value_construct_correctly(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            Int32ExpressionMediator exp = dbo.Person.Id + 0;

            //then
            ArithmeticExpression.ArithmeticExpressionElements ae = exp.Expression!.Should().BeOfType<ArithmeticExpression>()
                .Which.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;
                
            ae.Should().NotBeNull();
            ae.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Add);
            ae.Args.Should().HaveCount(2);
            
            // dbo.Person.Id
            ae.Args.First().Should().BeOfType<PersonEntity.IdField>();

            // 0
            ae.Args.Last().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_expression_of_an_int_literal_value_added_to_a_field_construct_correctly(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            Int32ExpressionMediator exp = 0 + dbo.Person.Id;

            //then
            ArithmeticExpression.ArithmeticExpressionElements ae = exp.Expression!.Should().BeOfType<ArithmeticExpression>()
                .Which.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            ae.Should().NotBeNull();
            ae.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Add);
            ae.Args.Should().HaveCount(2);

            // 0
            ae.Args.First().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            // dbo.Person.id
            ae.Args.Last().Should().BeOfType<PersonEntity.IdField>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_expression_of_an_int_literal_value_added_to_a_field_and_another_int_literal_value_construct_correctly(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            Int32ExpressionMediator exp = 0 + dbo.Person.Id + 3;

            //then
            ArithmeticExpression.ArithmeticExpressionElements ae = exp.Expression!.Should().BeOfType<ArithmeticExpression>()
                .Which.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            ae.Should().NotBeNull();
            ae.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Add);
            ae.Args.Should().HaveCount(3);

            // 0
            ae.Args.First().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            // dbo.Person.Id
            ae.Args.Skip(1).First().Should().BeOfType<PersonEntity.IdField>();

            // 3
            ae.Args.Last().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(3);
            ae.Args.Last().Should().BeOfType<LiteralExpression<int>>()
                .Which.Field.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_expression_of_an_int_literal_value_added_to_an_int_literal_value_added_to_a_field_result_in_compiler_addition_then_arithmetic_expression_with_two_args(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            Int32ExpressionMediator exp = 0 + 3 + dbo.Person.Id;

            //then
            ArithmeticExpression.ArithmeticExpressionElements ae = exp.Expression!.Should().BeOfType<ArithmeticExpression>()
                .Which.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            ae.Should().NotBeNull();
            ae.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Add);
            ae.Args.Should().HaveCount(2);

            // 0 + 3
            ae.Args.First().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(3);

            // dbo.Person.Id
            ae.Args.First().Should().BeOfType<LiteralExpression<int>>();
            ae.Args.Last().Should().BeOfType<PersonEntity.IdField>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_expression_of_an_int_literal_value_added_to_a_field_value_and_subtracting_an_int_literal_value_result_in_correct_arithmetic_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            Int32ExpressionMediator exp = 0 + dbo.Person.Id - 3;

            //then
            ArithmeticExpression.ArithmeticExpressionElements ae = exp.Expression!.Should().BeOfType<ArithmeticExpression>()
                .Which.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            ae.Should().NotBeNull();
            ae.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Subtract);
            ae.Args.Should().HaveCount(2);

            // 0 + dbo.Person.Id
            var add = ae.Args.First().Should().BeOfType<Int32ExpressionMediator>()
                .Which.Expression.Should().BeOfType<ArithmeticExpression>()
                .Subject.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            add.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Add);

            // 0
            add.Args.First().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            // dbo.Person.Id
            ae.Args.Last().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(3);

            // 3
            ae.Args.Last().Should().BeOfType<LiteralExpression<int>>()
               .Which.Expression.Should().Be(3);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_expression_of_an_int_literal_value_added_to_a_precedence_declared_field_value_subtracting_an_int_literal_value_result_in_correct_arithmetic_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            Int32ExpressionMediator exp = 0 + (dbo.Person.Id - 3);

            //then
            ArithmeticExpression.ArithmeticExpressionElements ae = exp.Expression!.Should().BeOfType<ArithmeticExpression>()
                .Which.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            ae.Should().NotBeNull();
            ae.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Add);
            ae.Args.Should().HaveCount(2);

            // 0
            ae.Args.First().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            // dbo.Person.Id - 3
            var subtract = ae.Args.Last().Should().BeOfType<Int32ExpressionMediator>()
                .Which.Expression.Should().BeOfType<ArithmeticExpression>()
                .Subject.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            subtract.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Subtract);

            // dbo.Person.Id
            subtract.Args.First().Should().BeOfType<PersonEntity.IdField>();

            // 3
            subtract.Args.Last().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(3);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_expression_of_an_int_literal_value_added_to_a_precedence_declared_field_value_subtracting_an_int_literal_value_than_multiplied_by_int_literal_value_result_in_correct_arithmetic_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            Int32ExpressionMediator exp = 0 + (dbo.Person.Id - 3) * 20;

            //then
            ArithmeticExpression.ArithmeticExpressionElements ae = exp.Expression!.Should().BeOfType<ArithmeticExpression>()
                .Which.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            // 0 + (inner)
            ae.Should().NotBeNull();
            ae.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Add);
            ae.Args.Should().HaveCount(2);

            // 0
            ae.Args.First().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            // inner
            // (dbo.Person.Id - 3) * 20
            var multiply = ae.Args.Last().Should().BeOfType<Int32ExpressionMediator>()
                .Which.Expression.Should().BeOfType<ArithmeticExpression>()
                .Subject.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            multiply.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Multiply);

            // dbo.Person.Id - 3
            var subtract = multiply.Args.First().Should().BeOfType<Int32ExpressionMediator>()
                .Which.Expression.Should().BeOfType<ArithmeticExpression>()
                .Subject.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            subtract.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Subtract);

            // dbo.Person.Id
            subtract.Args.First().Should().BeOfType<PersonEntity.IdField>();

            // 3
            subtract.Args.Last().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(3);

            // 20
            multiply.Args.Last().Should().BeOfType<LiteralExpression<int>>();
            multiply.Args.Last().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(20);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_expression_of_an_int_literal_value_added_to_a_precedence_declared_field_value_subtracting_a_double_literal_value_than_multiplied_by_int_literal_value_result_in_correct_arithmetic_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            //when
            DoubleExpressionMediator exp = 0 + (dbo.Person.Id - 3.25d) * 20;

            //then
            ArithmeticExpression.ArithmeticExpressionElements ae = exp.Expression!.Should().BeOfType<ArithmeticExpression>()
                .Which.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            // 0 + (inner)
            ae.Should().NotBeNull();
            ae.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Add);
            ae.Args.Should().HaveCount(2);

            // 0
            ae.Args.First().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            // inner
            // (dbo.Person.Id - 3.25) * 20
            var multiply = ae.Args.Last().Should().BeOfType<DoubleExpressionMediator>()
                .Which.Expression.Should().BeOfType<ArithmeticExpression>()
                .Subject.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            multiply.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Multiply);

            // dbo.Person.Id - 3.25
            var subtract = multiply.Args.First().Should().BeOfType<DoubleExpressionMediator>()
                .Which.Expression.Should().BeOfType<ArithmeticExpression>()
                .Subject.As<IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>>()
                .Expression!;

            subtract.ArithmeticOperator.Should().Be(ArithmeticExpressionOperator.Subtract);

            // dbo.Person.Id
            subtract.Args.First().Should().BeOfType<PersonEntity.IdField>();

            // 3.25
            subtract.Args.Last().Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(3.25d);

            // 20
            multiply.Args.Last().Should().BeOfType<LiteralExpression<int>>();
            multiply.Args.Last().Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(20);
        }
    }
}
