using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using JetBrains.Profiler.Api;
using Microsoft.Extensions.Configuration;
using Profiling.MsSql.DataService;
using Profiling.MsSql.Target;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

string connectionString = configuration.GetConnectionString("hattrick_dbex_mssql_test");

using IProfileTarget sut = new SelectOneQueryExpressionProfileTarget();

IServiceProvider provider = dbExpression.Configure(dbex => dbex.AddMsSql2019Database<ProfilingDatabase>(db => { db.ConnectionString.Use(connectionString); sut.Configure(db); }));

MemoryProfiler.CollectAllocations(true);
MeasureProfiler.StartCollectingData();
MemoryProfiler.GetSnapshot();

for (var i = 0; i < 10000; i++)
    sut.Execute(provider!);

MemoryProfiler.GetSnapshot();
MeasureProfiler.StopCollectingData();
