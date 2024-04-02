using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.Sql.Expression;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Expression
{
    public class JoinExpressionSetEqualityTests : TestBase
    {
        [Fact]
        public void Join_expressions_of_same_values_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id == dbo.PersonAddress.PersonId));
            var exp2 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id == dbo.PersonAddress.PersonId));

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Join_expressions_of_different_values_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id == dbo.PersonAddress.PersonId));
            var exp2 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.LEFT, dbo.Person.Id == dbo.PersonAddress.PersonId));

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Join_expressions_of_same_values_and_different_operators_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id == dbo.PersonAddress.PersonId));
            var exp2 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id != dbo.PersonAddress.PersonId));

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Join_expressions_of_same_values_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id == dbo.PersonAddress.PersonId));
            var exp2 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id == dbo.PersonAddress.PersonId));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Join_expressions_of_different_values_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id == dbo.PersonAddress.PersonId));
            var exp2 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.LEFT, dbo.Person.Id != dbo.PersonAddress.PersonId));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Join_expressions_of_same_values_and_different_operators_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id == dbo.PersonAddress.PersonId));
            var exp2 = new JoinExpressionSet(new JoinExpression(dbo.Product, JoinOperationExpressionOperator.INNER, dbo.Person.Id != dbo.PersonAddress.PersonId));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
