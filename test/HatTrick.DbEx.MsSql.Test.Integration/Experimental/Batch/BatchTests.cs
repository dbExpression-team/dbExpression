using DbEx.DataService;
using DbEx.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration.Experimental.Batch
{
    public partial class BatchTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("EXPERIMENTAL", "Batch")]
        public void Can_successfully_remove_person_using_batch(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => (c as MsSqlSqlDatabaseRuntimeConfigurationBuilder<MsSqlDb>)!.Services.AddTransient<IBatchBuilder<MsSqlDb>, BatchBuilder<MsSqlDb>>());
            var builder = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IBatchBuilder<MsSqlDb>>();

            var d1 = db.Delete().From(dbo.PurchaseLine).InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id).Where(dbo.Purchase.PersonId == 3);
            var d2 = db.Delete().From(dbo.Purchase).Where(dbo.Purchase.PersonId == 3);
            var d3 = db.Delete().From(dbo.PersonAddress).Where(dbo.PersonAddress.PersonId == 3);
            var d4 = db.Delete().From(dbo.Address).InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId).Where(dbo.PersonAddress.PersonId == 3);
            var d5 = db.Delete().From(dbo.Person).Where(dbo.Person.Id == 3);

            builder.Add(d1, d2, d3, d4, d5).Execute();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("EXPERIMENTAL", "Batch")]
        public async Task Can_successfully_remove_person_using_batch_async(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version, c => (c as MsSqlSqlDatabaseRuntimeConfigurationBuilder<MsSqlDb>)!.Services.AddTransient<IBatchBuilder<MsSqlDb>, BatchBuilder<MsSqlDb>>());
            var builder = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<IBatchBuilder<MsSqlDb>>();

            var d1 = db.Delete().From(dbo.PurchaseLine).InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id).Where(dbo.Purchase.PersonId == 3);
            var d2 = db.Delete().From(dbo.Purchase).Where(dbo.Purchase.PersonId == 3);
            var d3 = db.Delete().From(dbo.PersonAddress).Where(dbo.PersonAddress.PersonId == 3);
            var d4 = db.Delete().From(dbo.Address).InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId).Where(dbo.PersonAddress.PersonId == 3);
            var d5 = db.Delete().From(dbo.Person).Where(dbo.Person.Id == 3);

            await builder.Add(d1, d2, d3, d4, d5).ExecuteAsync();
        }
    }
}
