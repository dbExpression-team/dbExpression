![dbExpression](https://dbexpressionpublic.blob.core.windows.net/web/dbex-logo.png)

# Microsoft SQL Server. Simplified.

dbExpression is a Microsoft SQL Server database connector that enables fluent composition and execution of type safe SQL queries directly within compiled code.

**dbExpression supports Microsoft SQL Server versions 2005+.**

The docs can be found at [dbexpression.com/docs](https://dbexpression.com/docs).  

## Build Status

[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)
[![Code Coverage](https://img.shields.io/azure-devops/coverage/hattricklabs/DbEx/2/master)](https://img.shields.io/azure-devops/coverage/hattricklabs/DbEx/2/master?style=plastic)

Using linux versions of Microsoft SQL Server on Docker images, integration tests are executed against the following versions:

| Platform            	| Status 					|
| :---------------------| :---------------------------------------------|
|	MSSQL 2017	|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202017)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)	|
|	MSSQL 2019	|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202019)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)	|
|	MSSQL 2022	|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202022)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)	|

## Get dbExpression

| Package            															|  												|
| :-----------------------------------------------------------------------------| :---------------------------------------------------------------------------------------------|
| [HatTrick.DbEx.MsSql](https://www.nuget.org/packages/HatTrick.DbEx.MsSql/)	| ![Nuget](https://img.shields.io/nuget/v/HatTrick.DbEx.MsSql)					|
| [HatTrick.DbEx.Tools](https://www.nuget.org/packages/HatTrick.DbEx.Tools/)	| ![Nuget](https://img.shields.io/nuget/v/HatTrick.DbEx.Tools)					|
| [HatTrick.DbEx.MsSql.Extensions.DependencyInjection](https://www.nuget.org/packages/HatTrick.DbEx.MsSql.Extensions.DependencyInjection/)	| ![Nuget](https://img.shields.io/nuget/v/HatTrick.DbEx.MsSql.Extensions.DependencyInjection)	|

## Why dbExpression?

dbExpression was created to close the gap between application code and raw SQL, bringing Microsoft SQL Server functionality into .NET.  dbExpression isn't centered around object relational mapping (ORM) concepts, but instead focuses on allowing you to write powerful type-checked SQL queries comparable to queries written directly in TSQL.

* **Extensible by design**
* **Fluent** query builder using natural SQL syntax
* **WYSIWYG** - What you write looks like SQL, what we execute looks like SQL
* **Compile-time checking** of SQL queries
* Build queries **without magic strings** or string interpolation
* Tooling to easily keep **application code in sync with database schema**
* **ORM features without the ORM handcuffs**

With dbExpression, the code that handles the basics of pushing and pulling data in and out of your target database is generated via a CLI tool.  The code contains all of the classes and functional plumbing necessary to insert, update, delete and query your data with expressions that live directly within your application code.  When you modify your database in any way, regenerating the code exposes those changes to your application, keeping schema changes in sync with your application code.

With dbExpression, you can easily write queries in code like this:
```c#
//query composed and compiled in c#

IList<dynamic> purchases_shipped_by_year = await db.SelectMany(
        dbo.Person.Id,
        (dbo.Person.FirstName + " " + dbo.Person.LastName).As("CustomerName"),
        db.fx.Count(dbo.Purchase.ShipDate).As("ShippedCount"),
        db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate).As("ShippedYear")
    )
    .From(dbo.Purchase)
    .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
    .Where(dbo.Purchase.ShipDate != dbex.Null)
    .GroupBy(
        dbo.Person.Id,
        dbo.Person.FirstName,
        dbo.Person.LastName,
        db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate)
    )
    .ExecuteAsync();
```
And here's the SQL statement dbExpression assembled and executed against the target database:
```sql
exec sp_executesql N'SELECT
	[dbo].[Person].[Id]
	,([dbo].[Person].[FirstName] + @P1 + [dbo].[Person].[LastName]) AS [CustomerName]
	,COUNT([dbo].[Purchase].[ShipDate]) AS [ShippedCount]
	,DATEPART(year, [dbo].[Purchase].[ShipDate]) AS [ShippedYear]
FROM
	[dbo].[Purchase]
	INNER JOIN [dbo].[Person] ON [dbo].[Purchase].[PersonId] = [dbo].[Person].[Id]
WHERE
	[dbo].[Purchase].[ShipDate] IS NOT NULL
GROUP BY
	[dbo].[Person].[Id]
	,[dbo].[Person].[FirstName]
	,[dbo].[Person].[LastName]
	,DATEPART(year, [dbo].[Purchase].[ShipDate])
;',N'@P1 char(1)',@P1=' '
```

dbExpression was designed to work in either static or instance required scenarios.  The decision for which to use is typically based on the type of project, the team environment, and just what works best for you - it's your choice!
* Statically using a static database accessor to fluently build and execute queries.
* Instance based via dependency injection where an instance of the database accessor is used to fluently build and execute queries.  Perfect for environments that use dependency injection.

## Use dbExpression

dbExpression is quick and easy to get up and running using two packages available on NuGet:
1) [dbExpression Microsoft SQL Server package](https://www.nuget.org/packages/HatTrick.DbEx.MsSql/)
2) [dbExpression dotnet CLI tool](https://www.nuget.org/packages/HatTrick.DbEx.Tools/)

Jump to the [docs](https://dbexpression.com/docs) for installation and configuration instructions and how to author and execute beautiful queries.

## Performance

The following shows how we're doing compared to [EF Core](https://github.com/dotnet/efcore) and [Dapper](https://github.com/DapperLib/Dapper).  The benchmarks
used are included in the [HatTrick.DbEx.MsSql.Benchmark](https://github.com/HatTrickLabs/dbExpression/tree/master/benchmark/HatTrick.DbEx.MsSql.Benchmark) project.

Output from the latest:


``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2130/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|          ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |   Gen0 |   Gen1 | Allocated |
|------------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|-------:|----------:|
| dbExpression |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 110.1 μs |  5.62 μs |  8.50 μs |    1 | 0.8750 |      - |   7.54 KB |
| dbExpression |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 126.1 μs |  3.32 μs |  5.02 μs |    2 | 1.1250 | 0.3750 |  10.15 KB |
| dbExpression |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 131.5 μs |  8.38 μs | 12.67 μs |    2 | 1.0000 | 0.2500 |  10.04 KB |
| dbExpression |                                              &#39;Select First Record&#39; |        Person | 164.9 μs |  8.01 μs | 12.11 μs |    3 | 2.0000 | 0.5000 |   16.7 KB |
| dbExpression |                            &#39;Select First Record With Where Clause&#39; |        Person | 170.1 μs |  8.64 μs | 13.06 μs |    3 | 2.2500 | 0.5000 |  18.54 KB |
| dbExpression |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 184.2 μs | 15.20 μs | 25.54 μs |    4 | 1.0000 |      - |    9.8 KB |
| dbExpression |                          &#39;Select First Record With Join Condition&#39; |        Person | 232.8 μs |  7.28 μs | 11.00 μs |    5 | 2.0000 | 0.5000 |  17.89 KB |
| dbExpression |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 236.5 μs | 15.93 μs | 24.08 μs |    5 | 3.0000 | 0.5000 |  24.75 KB |
| dbExpression |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 242.0 μs | 20.93 μs | 31.64 μs |    5 | 1.5000 | 0.5000 |  13.91 KB |
| dbExpression |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 247.1 μs | 20.39 μs | 30.83 μs |    5 | 2.0000 | 0.5000 |  18.97 KB |
| dbExpression |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 253.7 μs | 26.23 μs | 39.65 μs |    5 | 1.5000 | 0.5000 |   13.8 KB |
| dbExpression | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 300.1 μs | 15.89 μs | 24.03 μs |    6 | 2.0000 | 0.5000 |  20.16 KB |


``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2130/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|    ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |   Gen0 |   Gen1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|-------:|----------:|
| EFCore |                                              &#39;Select First Record&#39; |        Person | 154.4 μs | 16.91 μs | 25.57 μs |    1 | 1.0000 |      - |   8.33 KB |
| EFCore |                          &#39;Select First Record With Join Condition&#39; |        Person | 180.4 μs | 14.69 μs | 22.21 μs |    2 | 1.2500 |      - |  12.06 KB |
| EFCore |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 181.1 μs | 14.17 μs | 21.43 μs |    2 | 0.7500 |      - |   7.61 KB |
| EFCore |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 182.3 μs |  7.38 μs | 11.16 μs |    2 | 1.0000 | 0.2500 |  10.02 KB |
| EFCore |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 183.9 μs | 10.68 μs | 16.14 μs |    2 | 1.0000 | 0.2500 |   9.98 KB |
| EFCore |                            &#39;Select First Record With Where Clause&#39; |        Person | 186.6 μs |  8.72 μs | 13.18 μs |    2 | 1.2500 |      - |  11.95 KB |
| EFCore |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 243.2 μs | 26.05 μs | 43.78 μs |    3 | 1.0000 |      - |  11.72 KB |
| EFCore |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 248.3 μs | 17.04 μs | 25.76 μs |    3 | 1.5000 |      - |  12.95 KB |
| EFCore |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 249.9 μs | 15.36 μs | 25.82 μs |    3 | 1.5000 |      - |  14.65 KB |
| EFCore |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 250.7 μs | 13.46 μs | 25.74 μs |    3 | 1.5000 |      - |  12.99 KB |
| EFCore |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 259.6 μs | 17.83 μs | 26.95 μs |    3 | 1.0000 |      - |  10.85 KB |
| EFCore | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 269.8 μs | 11.81 μs | 17.86 μs |    3 | 1.5000 |      - |  15.63 KB |


``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2130/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                  ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |   Gen0 |   Gen1 | Allocated |
|--------------------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|-------:|----------:|
| EFCore (No Tracking) |                                              &#39;Select First Record&#39; |        Person | 150.2 μs | 12.33 μs | 18.63 μs |    1 | 1.0000 | 0.2500 |   8.62 KB |
| EFCore (No Tracking) |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 171.5 μs | 12.75 μs | 19.27 μs |    2 | 0.7500 |      - |   7.61 KB |
| EFCore (No Tracking) |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 180.9 μs |  5.73 μs | 10.95 μs |    2 | 1.0000 |      - |  10.02 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 181.2 μs |  7.38 μs | 12.40 μs |    2 | 1.0000 | 0.2500 |   9.98 KB |
| EFCore (No Tracking) |                            &#39;Select First Record With Where Clause&#39; |        Person | 190.5 μs | 16.90 μs | 25.56 μs |    2 | 1.0000 |      - |  11.55 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Join Condition&#39; |        Person | 197.8 μs | 21.81 μs | 32.97 μs |    2 | 1.5000 | 0.5000 |  12.53 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 228.7 μs |  8.71 μs | 14.63 μs |    3 | 1.0000 |      - |  11.94 KB |
| EFCore (No Tracking) |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 248.4 μs |  2.99 μs |  5.71 μs |    4 | 1.5000 |      - |  13.13 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 252.5 μs |  9.22 μs | 15.49 μs |    4 | 1.0000 |      - |  11.02 KB |
| EFCore (No Tracking) |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 280.0 μs | 23.76 μs | 35.92 μs |    5 | 1.5000 |      - |  13.17 KB |
| EFCore (No Tracking) |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 292.8 μs | 14.93 μs | 22.58 μs |    5 | 1.5000 | 0.5000 |  14.87 KB |
| EFCore (No Tracking) | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 309.5 μs | 25.30 μs | 38.25 μs |    5 | 1.5000 | 0.5000 |  15.96 KB |



``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2130/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|    ORM |                                                             Method |        Return |      Mean |    StdDev |     Error | Rank |   Gen0 |   Gen1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |----------:|----------:|----------:|-----:|-------:|-------:|----------:|
| Dapper |                                              &#39;Select First Record&#39; |        Person |  96.25 μs |  3.830 μs |  5.791 μs |    1 | 0.5000 | 0.1250 |   4.52 KB |
| Dapper |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  99.05 μs |  4.975 μs |  8.361 μs |    1 | 0.2500 |      - |   2.35 KB |
| Dapper |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 102.45 μs |  4.540 μs |  6.864 μs |    1 | 0.3750 |      - |   3.13 KB |
| Dapper |                          &#39;Select First Record With Join Condition&#39; |        Person | 105.80 μs |  2.127 μs |  3.215 μs |    1 | 0.6250 | 0.1250 |   5.61 KB |
| Dapper |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 108.50 μs |  5.077 μs |  7.676 μs |    1 | 0.3750 |      - |   3.09 KB |
| Dapper |                            &#39;Select First Record With Where Clause&#39; |        Person | 110.55 μs |  6.871 μs | 10.388 μs |    1 | 0.6250 | 0.1250 |   5.51 KB |
| Dapper |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 152.29 μs |  6.240 μs | 10.487 μs |    2 | 0.7500 |      - |   7.16 KB |
| Dapper | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 165.19 μs |  8.799 μs | 13.303 μs |    3 | 1.0000 | 0.2500 |   8.25 KB |
| Dapper |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 174.40 μs | 12.227 μs | 18.486 μs |    4 | 0.5000 |      - |   4.74 KB |
| Dapper |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 177.56 μs |  5.409 μs |  8.177 μs |    4 | 0.5000 |      - |   5.84 KB |
| Dapper |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 184.51 μs |  9.453 μs | 15.885 μs |    4 | 0.5000 |      - |   5.06 KB |
| Dapper |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 204.80 μs | 19.120 μs | 28.906 μs |    5 | 1.0000 | 0.2500 |   8.21 KB |



