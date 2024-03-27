using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.Sql.Expression;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Unit
{
    public class AliasTupleFilterExpressionTests : TestBase
    {
        [Fact]
        public void Int_field_expression_equal_to_tuple_alias_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = dbo.Person.Id == ("foo", "bar");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg.Should().Be(dbo.Person.Id);

            exp.RightArg.Should().BeOfType<AliasExpression<int>>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Int_field_expression_not_equal_to_tuple_alias_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = dbo.Person.Id != ("foo", "bar");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg.Should().Be(dbo.Person.Id);

            exp.RightArg.Should().BeOfType<AliasExpression<int>>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Alias_tuple_expression_equal_to_int_field_expression_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = ("foo", "bar") == dbo.Person.Id;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.RightArg.Should().Be(dbo.Person.Id);

            exp.LeftArg.Should().BeOfType<AliasExpression<int>>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Alias_tuple_expression_not_equal_to_int_field_expression_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = ("foo", "bar") != dbo.Person.Id;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.RightArg.Should().Be(dbo.Person.Id);

            exp.LeftArg.Should().BeOfType<AliasExpression<int>>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void String_field_expression_equal_to_tuple_alias_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = dbo.Person.FirstName == ("foo", "bar");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg.Should().Be(dbo.Person.FirstName);

            exp.RightArg.Should().BeOfType<AliasExpression<string>>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void String_field_expression_not_equal_to_tuple_alias_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = dbo.Person.FirstName != ("foo", "bar");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg.Should().Be(dbo.Person.FirstName);

            exp.RightArg.Should().BeOfType<AliasExpression<string>>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Alias_tuple_expression_equal_to_string_field_expression_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = ("foo", "bar") == dbo.Person.FirstName;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.RightArg.Should().Be(dbo.Person.FirstName);

            exp.LeftArg.Should().BeOfType<AliasExpression<string>>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Alias_tuple_expression_not_equal_to_string_field_expression_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = ("foo", "bar") != dbo.Person.FirstName;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.RightArg.Should().Be(dbo.Person.FirstName);

            exp.LeftArg.Should().BeOfType<AliasExpression<string>>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Int_function_expression_equal_to_tuple_alias_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = db.fx.Abs(dbo.Person.Id) == ("foo", "bar");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg.Should().BeOfType<Int32AbsFunctionExpression>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<IExpressionElement>>()
                .Which?.Expression?.Should().Be(dbo.Person.Id);

            exp.RightArg.Should().BeOfType<AliasExpression<int>>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Int_function_expression_not_equal_to_tuple_alias_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = db.fx.Abs(dbo.Person.Id) != ("foo", "bar");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg.Should().BeOfType<Int32AbsFunctionExpression>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<IExpressionElement>>()
                .Which?.Expression?.Should().Be(dbo.Person.Id);

            exp.RightArg.Should().BeOfType<AliasExpression<int>>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Alias_tuple_expression_equal_to_int_function_expression_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = ("foo", "bar") == db.fx.Abs(dbo.Person.Id);

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.RightArg.Should().BeOfType<Int32AbsFunctionExpression>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<IExpressionElement>>()
                .Which?.Expression?.Should().Be(dbo.Person.Id);

            exp.LeftArg.Should().BeOfType<AliasExpression<int>>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Alias_tuple_expression_not_equal_to_int_function_expression_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = ("foo", "bar") != db.fx.Abs(dbo.Person.Id);

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.RightArg.Should().BeOfType<Int32AbsFunctionExpression>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<IExpressionElement>>()
                .Which?.Expression?.Should().Be(dbo.Person.Id);

            exp.LeftArg.Should().BeOfType<AliasExpression<int>>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void String_function_expression_equal_to_tuple_alias_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = db.fx.Concat(dbo.Person.FirstName, "") == ("foo", "bar");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg.Should().BeOfType<StringConcatFunctionExpression>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionListProvider<IExpressionElement>>()
                .Which?.Expressions?.First().Should().Be(dbo.Person.FirstName);

            exp.RightArg.Should().BeOfType<AliasExpression<string>>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void String_function_expression_not_equal_to_tuple_alias_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = db.fx.Concat(dbo.Person.FirstName, "") != ("foo", "bar");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg.Should().BeOfType<StringConcatFunctionExpression>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionListProvider<IExpressionElement>>()
                .Which?.Expressions?.First().Should().Be(dbo.Person.FirstName);

            exp.RightArg.Should().BeOfType<AliasExpression<string>>();
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.RightArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Alias_tuple_expression_equal_to_string_function_expression_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = ("foo", "bar") == db.fx.Concat(dbo.Person.FirstName, "");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.RightArg.Should().BeOfType<StringConcatFunctionExpression>();
            exp.RightArg.Should().BeAssignableTo<IExpressionListProvider<IExpressionElement>>()
                .Which?.Expressions?.First().Should().Be(dbo.Person.FirstName);

            exp.LeftArg.Should().BeOfType<AliasExpression<string>>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }

        [Fact]
        public void Alias_tuple_expression_not_equal_to_string_function_expression_create_valid_filter_expression()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = ("foo", "bar") != db.fx.Concat(dbo.Person.FirstName, "");

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.RightArg.Should().BeOfType<StringConcatFunctionExpression>();
            exp.RightArg.Should().BeAssignableTo<IExpressionListProvider<IExpressionElement>>()
                .Which?.Expressions?.First().Should().Be(dbo.Person.FirstName);

            exp.LeftArg.Should().BeOfType<AliasExpression<string>>();
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.TableAlias.Should().Be("foo");
            exp.LeftArg.Should().BeAssignableTo<IExpressionProvider<AliasExpression.AliasExpressionElements>>()
                .Which?.Expression?.FieldAlias.Should().Be("bar");
        }
    }
}
