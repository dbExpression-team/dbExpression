using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "CAST")]
    [Trait("Function", "STDEVP")]
    public partial class CastAndStandardDeviationPopulation : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_standarddeviationpopulation_of_quantity_to_varchar_succeed(int version, string expectedStDevP = "0.6849")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(db.fx.StDevP(dbo.PurchaseLine.Quantity)).AsVarChar(50)
                ).From(dbo.PurchaseLine);

            //when               
            string result = exp.Execute();

            //then
            result.Should().StartWith(expectedStDevP);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_standarddeviationpopulation_of_cast_of_gendertype_to_int_succeed(int version, float expected = .45825f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDevP(db.fx.Cast(dbo.Person.GenderType).AsInt())
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }
    }
}
