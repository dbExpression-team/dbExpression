using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "AVG")]
    public partial class IsNullAndAverageTests : ResetDatabaseNotRequired
    {
        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_isnull_of_average_of_quantity_and_static_value_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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

        [Fact]
        public void Does_selecting_average_of_isnull_of_quantity_and_static_value_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
