using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "MAX")]
    public partial class CastAndMaximumTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("3")]
        public void Does_selecting_cast_of_maximum_of_quantity_to_varchar_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cast(db.fx.Max(dbo.PurchaseLine.Quantity)).AsVarChar(50)
                ).From(dbo.PurchaseLine);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(2)]
        public void Does_selecting_maximum_of_cast_of_gendertype_to_int_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.Cast(dbo.Person.GenderType).AsInt())
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
