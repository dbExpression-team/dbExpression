using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class AverageFunctionExpressionEqualityTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Average_functions_of_person_id_should_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Average_functions_of_person_id_with_one_aliased_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id).As("foo");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Average_functions_of_person_id_should_have_same_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Average_functions_of_person_id_with_one_aliased_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id).As("foo");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Average_functions_of_person_id_with_one_distinct_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id).Distinct();

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
