using DbEx.DataService;
using DbEx.dboDataService;
using DbEx.secDataService;
using FluentAssertions;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class SchemaExpressionEqualityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Schema_expressions_of_same_schema_should_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new dboSchemaExpression(1);
            var exp2 = new dboSchemaExpression(1);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Schema_expressions_of_same_schema_with_different_identifiers_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new dboSchemaExpression(1);
            var exp2 = new dboSchemaExpression(2);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Schema_expressions_of_different_schemas_with_same_identifier_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new dboSchemaExpression(1);
            var exp2 = new secSchemaExpression(1);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Schema_expressions_of_different_schemas_with_different_identifier_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new dboSchemaExpression(1);
            var exp2 = new secSchemaExpression(2);

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Schema_expressions_of_same_schemas_should_have_same_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new dboSchemaExpression(1);
            var exp2 = new dboSchemaExpression(1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Schema_expressions_of_same_schemas_with_different_identifier_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new dboSchemaExpression(1);
            var exp2 = new dboSchemaExpression(2);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Schema_expressions_of_different_schemas_with_same_identifier_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new dboSchemaExpression(1);
            var exp2 = new secSchemaExpression(1);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Schema_expressions_of_different_schemas_with_different_identifier_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new dboSchemaExpression(1);
            var exp2 = new secSchemaExpression(2);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
