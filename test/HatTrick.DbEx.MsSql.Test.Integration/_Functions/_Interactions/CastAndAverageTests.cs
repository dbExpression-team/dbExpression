using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "AVG")]
    public partial class CastAndAverageTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_average_of_quantity_to_varchar_succeed(int version, string expected = "1")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(db.fx.Avg(dbo.PurchaseLine.Quantity)).AsVarChar(50)
                ).From(dbo.PurchaseLine);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_average_of_cast_of_gendertype_to_int_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Avg(db.fx.Cast(dbo.Person.GenderType).AsInt())
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_average_of_cast_of_addresstype_to_int_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Avg(db.fx.Cast(dbo.Address.AddressType).AsInt())
                ).From(dbo.Address);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
