![dbExpression](https://dbexpressionpublic.blob.core.windows.net/web/dbex-logo.png)

dbExpression is a Microsoft SQL Server database connector that enables fluent composition and execution of type safe SQL queries directly within compiled code.

**dbExpression supports Microsoft SQL Server versions 2005+.**  

## Build Status

[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)
[![Code Coverage](https://img.shields.io/azure-devops/coverage/hattricklabs/DbEx/2/master)](https://img.shields.io/azure-devops/coverage/hattricklabs/DbEx/2/master?style=plastic)

Using linux versions of Microsoft SQL Server on Docker images, integration tests are executed against the following versions:

| Platform            	| Status 					|
| :---------------------| :---------------------------------------------|
|	MSSQL 2017	|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202017)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)	|
|	MSSQL 2019	|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202019)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)	|

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
* Statically using a static database accessor to fluently build and execute queries.  This is great for environments or projects where this works best.
* Instance based via dependency injection where an instance of the database accessor is used to fluently build and execute queries.  Perfect for environments that use dependency injection.

## Use dbExpression
dbExpression is quick and easy to get up and running using two packages available on NuGet:
1) [dbExpression Microsoft SQL Server package](https://www.nuget.org/packages/HatTrick.DbEx.MsSql/)
2) [dbExpression dotnet CLI tool](https://www.nuget.org/packages/HatTrick.DbEx.Tools/)

Jump to the [docs](https://github.com/HatTrickLabs/dbExpression/wiki) for installation and configuration instructions and how to author and execute beautiful queries.

## Performance
As dbExpression progresses towards version 1.0, performance is our primary focus.  The following shows how we're doing compared to [EF Core](https://github.com/dotnet/efcore) and [Dapper](https://github.com/DapperLib/Dapper).  The benchmarks
used are included in the [HatTrick.DbEx.MsSql.Benchmark](https://github.com/HatTrickLabs/dbExpression/tree/master/benchmark/HatTrick.DbEx.MsSql.Benchmark) project.

Output from the latest:

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|          ORM |                                                             Method |        Return |      Mean |   StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------------- |------------------------------------------------------------------- |-------------- |----------:|---------:|---------:|-----:|-------:|-------:|----------:|
| dbExpression |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  98.97 μs | 1.198 μs | 1.811 μs |    1 | 0.8750 |      - |      8 KB |
| dbExpression |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 112.33 μs | 1.291 μs | 2.169 μs |    2 | 1.2500 | 0.3750 |     10 KB |
| dbExpression |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 112.35 μs | 1.344 μs | 2.258 μs |    2 | 1.2500 | 0.3750 |     10 KB |
| dbExpression |                                              &#39;Select First Record&#39; |        Person | 134.41 μs | 2.384 μs | 3.605 μs |    3 | 2.0000 | 0.5000 |     17 KB |
| dbExpression |                            &#39;Select First Record With Where Clause&#39; |        Person | 150.70 μs | 2.076 μs | 3.139 μs |    4 | 2.2500 | 0.5000 |     19 KB |
| dbExpression |                          &#39;Select First Record With Join Condition&#39; |        Person | 160.09 μs | 2.869 μs | 4.337 μs |    5 | 2.0000 | 0.5000 |     18 KB |
| dbExpression |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 176.99 μs | 5.136 μs | 7.764 μs |    6 | 1.0000 |      - |     10 KB |
| dbExpression |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 177.38 μs | 0.461 μs | 0.774 μs |    6 | 1.5000 | 0.5000 |     14 KB |
| dbExpression |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 181.04 μs | 1.331 μs | 2.013 μs |    7 | 1.5000 | 0.5000 |     14 KB |
| dbExpression |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 193.33 μs | 1.588 μs | 2.669 μs |    8 | 2.7500 | 0.5000 |     23 KB |
| dbExpression |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 211.89 μs | 1.100 μs | 1.848 μs |    9 | 3.0000 | 0.5000 |     25 KB |
| dbExpression | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 228.12 μs | 5.688 μs | 8.599 μs |   10 | 3.0000 | 0.5000 |     24 KB |


``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|    ORM |                                                             Method |        Return |     Mean |  StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|--------:|---------:|-----:|-------:|-------:|----------:|
| EFCore |                                              &#39;Select First Record&#39; |        Person | 138.6 μs | 2.70 μs |  4.07 μs |    1 | 1.0000 |      - |      8 KB |
| EFCore |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 149.8 μs | 0.83 μs |  1.59 μs |    2 | 0.7500 |      - |      8 KB |
| EFCore |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 151.7 μs | 2.03 μs |  3.07 μs |    2 | 1.0000 | 0.2500 |     10 KB |
| EFCore |                            &#39;Select First Record With Where Clause&#39; |        Person | 161.0 μs | 5.18 μs |  7.83 μs |    3 | 1.2500 |      - |     12 KB |
| EFCore |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 161.5 μs | 1.59 μs |  2.67 μs |    3 | 1.0000 | 0.2500 |     10 KB |
| EFCore |                          &#39;Select First Record With Join Condition&#39; |        Person | 179.6 μs | 7.44 μs | 11.25 μs |    4 | 1.2500 |      - |     12 KB |
| EFCore |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 209.1 μs | 1.02 μs |  1.71 μs |    5 | 1.0000 |      - |     12 KB |
| EFCore |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 217.7 μs | 1.57 μs |  2.63 μs |    6 | 1.0000 |      - |     11 KB |
| EFCore |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 229.1 μs | 1.80 μs |  3.45 μs |    7 | 1.5000 |      - |     13 KB |
| EFCore |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 229.9 μs | 1.03 μs |  1.73 μs |    7 | 1.5000 |      - |     13 KB |
| EFCore |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 231.4 μs | 1.79 μs |  3.42 μs |    7 | 1.5000 |      - |     14 KB |
| EFCore | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 254.3 μs | 1.37 μs |  2.31 μs |    8 | 1.5000 |      - |     15 KB |



``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|                  ORM |                                                             Method |        Return |     Mean |  StdDev |   Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|--------------------- |------------------------------------------------------------------- |-------------- |---------:|--------:|--------:|-----:|-------:|-------:|----------:|
| EFCore (No Tracking) |                                              &#39;Select First Record&#39; |        Person | 143.8 μs | 1.22 μs | 2.05 μs |    1 | 1.0000 | 0.2500 |      9 KB |
| EFCore (No Tracking) |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 146.9 μs | 4.92 μs | 7.44 μs |    1 | 0.7500 |      - |      8 KB |
| EFCore (No Tracking) |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 159.3 μs | 3.54 μs | 5.36 μs |    2 | 1.0000 | 0.2500 |     10 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 161.3 μs | 0.57 μs | 0.86 μs |    2 | 1.0000 | 0.2500 |     10 KB |
| EFCore (No Tracking) |                            &#39;Select First Record With Where Clause&#39; |        Person | 165.2 μs | 1.90 μs | 2.88 μs |    3 | 1.2500 | 0.2500 |     12 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Join Condition&#39; |        Person | 191.3 μs | 1.13 μs | 1.70 μs |    4 | 1.5000 | 0.5000 |     13 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 210.0 μs | 1.39 μs | 2.34 μs |    5 | 1.2500 | 0.2500 |     12 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 217.5 μs | 1.76 μs | 2.67 μs |    6 | 1.0000 |      - |     11 KB |
| EFCore (No Tracking) |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 229.5 μs | 0.89 μs | 1.49 μs |    7 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 229.7 μs | 1.47 μs | 2.22 μs |    7 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 232.8 μs | 0.60 μs | 0.91 μs |    7 | 1.7500 | 0.5000 |     15 KB |
| EFCore (No Tracking) | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 255.6 μs | 2.66 μs | 4.47 μs |    8 | 1.5000 | 0.5000 |     16 KB |



``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|    ORM |                                                             Method |        Return |      Mean |   StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |----------:|---------:|---------:|-----:|-------:|-------:|----------:|
| Dapper |                                              &#39;Select First Record&#39; |        Person |  87.41 μs | 0.666 μs | 1.007 μs |    1 | 0.5000 | 0.1250 |      5 KB |
| Dapper |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  89.92 μs | 0.560 μs | 0.846 μs |    2 | 0.2500 |      - |      2 KB |
| Dapper |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic |  93.19 μs | 0.681 μs | 1.145 μs |    3 | 0.3750 |      - |      3 KB |
| Dapper |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic |  93.52 μs | 0.426 μs | 0.716 μs |    3 | 0.3750 |      - |      3 KB |
| Dapper |                          &#39;Select First Record With Join Condition&#39; |        Person |  96.97 μs | 0.525 μs | 0.794 μs |    4 | 0.6250 | 0.1250 |      6 KB |
| Dapper |                            &#39;Select First Record With Where Clause&#39; |        Person |  97.48 μs | 0.520 μs | 0.994 μs |    4 | 0.6250 | 0.1250 |      6 KB |
| Dapper |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 141.66 μs | 0.773 μs | 1.169 μs |    5 | 0.7500 |      - |      7 KB |
| Dapper | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 151.86 μs | 1.644 μs | 2.486 μs |    6 | 1.0000 | 0.2500 |      8 KB |
| Dapper |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 160.52 μs | 1.977 μs | 2.990 μs |    7 | 0.5000 |      - |      5 KB |
| Dapper |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 164.77 μs | 1.813 μs | 3.047 μs |    8 | 0.5000 |      - |      5 KB |
| Dapper |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 168.03 μs | 4.451 μs | 6.730 μs |    8 | 1.0000 | 0.2500 |      8 KB |
| Dapper |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 172.28 μs | 1.683 μs | 2.544 μs |    8 | 0.5000 |      - |      6 KB |


