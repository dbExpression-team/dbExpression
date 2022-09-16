using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "AVG")]
    public partial class IsNullAndAverageTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_isnull_of_average_of_quantity_and_static_value_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Person.CreditLimit, db.fx.Avg(dbo.PurchaseLine.Quantity))
                ).From(dbo.PurchaseLine)
                .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
                .InnerJoin(dbo.Person).On(dbo.Person.Id == dbo.Purchase.PersonId)
                .GroupBy(dbo.Person.CreditLimit);
            
            //when               
            int result = exp.Execute();

            //then
            result.Should().BeGreaterThan(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_average_of_isnull_of_quantity_and_static_value_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Avg(db.fx.IsNull(dbo.Person.CreditLimit, dbo.PurchaseLine.Quantity))
                ).From(dbo.PurchaseLine)
                .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
                .InnerJoin(dbo.Person).On(dbo.Person.Id == dbo.Purchase.PersonId);

            //when               
            int result = exp.Execute();

            //then
            result.Should().BeGreaterThan(0);
        }
    }
}
