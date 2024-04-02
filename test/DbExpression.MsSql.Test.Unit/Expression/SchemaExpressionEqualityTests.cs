using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using v2019DbEx.secDataService;
using FluentAssertions;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Expression
{
    public class SchemaExpressionEqualityTests : TestBase
    {
        [Fact]
        public void Schema_expressions_of_same_schema_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));
            var exp2 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void Schema_expressions_of_same_schema_with_different_identifiers_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));
            var exp2 = new dboSchemaExpression(2, "dbo", typeof(dboSchemaExpression));

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Schema_expressions_of_different_schemas_with_same_identifier_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));
            var exp2 = new secSchemaExpression(1, "sec", typeof(secSchemaExpression));

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Schema_expressions_of_different_schemas_with_different_identifier_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));
            var exp2 = new secSchemaExpression(2, "sec", typeof(secSchemaExpression));

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void Schema_expressions_of_same_schemas_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));
            var exp2 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void Schema_expressions_of_same_schemas_with_different_identifier_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));
            var exp2 = new dboSchemaExpression(2, "dbo", typeof(dboSchemaExpression));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Schema_expressions_of_different_schemas_with_same_identifier_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));
            var exp2 = new secSchemaExpression(1, "sec", typeof(secSchemaExpression));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Fact]
        public void Schema_expressions_of_different_schemas_with_different_identifier_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression));
            var exp2 = new secSchemaExpression(2, "sec", typeof(secSchemaExpression));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
