using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using DbExpression.MsSql.Configuration;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration.Experimental.Batch
{
    public partial class BatchTests : ResetDatabaseAfterEveryTest
    {
        [Fact]
        [Trait("EXPERIMENTAL", "Batch")]
        public void Can_successfully_remove_person_using_batch()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => (c as MsSqlSqlDatabaseRuntimeConfigurationBuilder<v2019MsSqlDb>)!.Services.AddTransient<IBatchBuilder<v2019MsSqlDb>, BatchBuilder<v2019MsSqlDb>>());
            var builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IBatchBuilder<v2019MsSqlDb>>();

            var d1 = db.Delete().From(dbo.PurchaseLine).InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id).Where(dbo.Purchase.PersonId == 3);
            var d2 = db.Delete().From(dbo.Purchase).Where(dbo.Purchase.PersonId == 3);
            var d3 = db.Delete().From(dbo.PersonAddress).Where(dbo.PersonAddress.PersonId == 3);
            var d4 = db.Delete().From(dbo.Address).InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId).Where(dbo.PersonAddress.PersonId == 3);
            var d5 = db.Delete().From(dbo.Person).Where(dbo.Person.Id == 3);

            builder.Add(d1, d2, d3, d4, d5).Execute();
        }

        [Fact]
        [Trait("EXPERIMENTAL", "Batch")]
        public async Task Can_successfully_remove_person_using_batch_async()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => (c as MsSqlSqlDatabaseRuntimeConfigurationBuilder<v2019MsSqlDb>)!.Services.AddTransient<IBatchBuilder<v2019MsSqlDb>, BatchBuilder<v2019MsSqlDb>>());
            var builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IBatchBuilder<v2019MsSqlDb>>();

            var d1 = db.Delete().From(dbo.PurchaseLine).InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id).Where(dbo.Purchase.PersonId == 3);
            var d2 = db.Delete().From(dbo.Purchase).Where(dbo.Purchase.PersonId == 3);
            var d3 = db.Delete().From(dbo.PersonAddress).Where(dbo.PersonAddress.PersonId == 3);
            var d4 = db.Delete().From(dbo.Address).InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId).Where(dbo.PersonAddress.PersonId == 3);
            var d5 = db.Delete().From(dbo.Person).Where(dbo.Person.Id == 3);

            await builder.Add(d1, d2, d3, d4, d5).ExecuteAsync();
        }
    }
}
