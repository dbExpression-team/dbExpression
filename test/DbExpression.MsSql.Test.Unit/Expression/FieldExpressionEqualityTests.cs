using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Expression
{
    public class FieldExpressionEqualityTests : TestBase
    {
        [Fact]
        public void Field_expressions_of_same_field_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.FirstName;
            var exp2 = dbo.Person.FirstName;

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Field_expressions_of_different_fields_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.FirstName;
            var exp2 = dbo.Person.LastName;

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Field_expressions_of_same_field_with_one_aliased_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.FirstName;
            var exp2 = dbo.Person.FirstName.As("alias");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Field_expressions_of_different_entities_with_same_field_name_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.Id;
            var exp2 = dbo.Address.Id;

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Field_expressions_of_same_fields_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.FirstName;
            var exp2 = dbo.Person.FirstName;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Field_expressions_of_different_fields_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.FirstName;
            var exp2 = dbo.Person.LastName;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Field_expressions_of_same_fields_with_one_aliased_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.FirstName;
            var exp2 = dbo.Person.FirstName.As("alias");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Field_expressions_of_different_entities_with_same_field_names_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = dbo.Person.Id;
            var exp2 = dbo.Address.Id;

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
