using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "AVG")]
    [Trait("Function", "DATEPART")]
    public partial class AverageAndPartDiffTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(2019)]
        public void Does_selecting_average_of_datedpart_of_purchasedate_and_shipdate_and_datepart_of_purchasedate_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
