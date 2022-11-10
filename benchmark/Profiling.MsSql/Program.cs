using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using JetBrains.Profiler.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profiling.MsSql.DataService;
using Profiling.MsSql.Target;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

string connectionString = configuration.GetConnectionString("hattrick_dbex_mssql_test")!;

using IProfileTarget sut = new SelectOneQueryExpressionProfileTarget();

var services = new ServiceCollection();
services.AddDbExpression(dbex =>
{
    dbex.AddDatabase<ProfilingDatabase>(db => { db.ConnectionString.Use(connectionString); sut.Configure(db); });
});
var provider = services.BuildServiceProvider();
provider.UseStaticRuntimeFor<ProfilingDatabase>();


MemoryProfiler.CollectAllocations(true);
MeasureProfiler.StartCollectingData();
MemoryProfiler.GetSnapshot();

for (var i = 0; i < 10000; i++)
    sut.Execute(provider!);

MemoryProfiler.GetSnapshot();
MeasureProfiler.StopCollectingData();
