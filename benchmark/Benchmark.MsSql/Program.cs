using BenchmarkDotNet.Running;
using DbExpression.MsSql.Benchmark;
using System.Linq;

//BenchmarkRunner.Run<QueryExpressionBenchmarks>();
//BenchmarkRunner.Run<QueryExecutionBenchmarks>();
//BenchmarkRunner.Run<SqlStatementAssemblyBenchmarks>();
//BenchmarkRunner.Run<MapperBenchmarks>();

new BenchmarkSwitcher(typeof(Program).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(PlatformBenchmarksBase))).ToArray()).Run(args, new Config());