using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "CAST")]
    [Trait("Function", "VARP")]
    public partial class CastAndPopulationVariance : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_populationvariance_of_quantity_to_varchar_succeed(int version, string expected = "0.4691")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(db.fx.VarP(dbo.PurchaseLine.Quantity)).AsVarChar(50)
                ).From(dbo.PurchaseLine);

            //when               
            string result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_populationvariance_of_cast_of_gendertype_to_int_succeed(int version, float expected = 0.21f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.Cast(dbo.Person.GenderType).AsInt())
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .001f);
        }
    }
}
