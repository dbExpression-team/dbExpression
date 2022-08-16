using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class LikeExpressionEqualityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Like_expressions_of_same_values_should_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new LikeExpression("hello");
            var exp2 = new LikeExpression("hello");

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Like_expressions_of_different_values_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new LikeExpression("hello");
            var exp2 = new LikeExpression("goodbye");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Like_expressions_of_same_values_should_have_same_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new LikeExpression("hello");
            var exp2 = new LikeExpression("hello");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Like_expressions_of_different_values_with_one_distinct_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new LikeExpression("hello");
            var exp2 = new LikeExpression("world");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
