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
    .Where(dbo.Purchase.ShipDate != DBNull.Value)
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

dbExpression was designed to work in two distinct modes, singleton or instance based.  The decision for which mode to use is typically based on the type of project, the team environment, and just what works best for you - it's your choice!
* Statically using startup configuration and a static database accessor to fluently build and execute queries.  This is great for environments or projects where this is all that is needed.
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
| dbExpression |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  97.04 μs | 1.166 μs | 1.762 μs |    1 | 0.8750 |      - |      8 KB |
| dbExpression |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 109.90 μs | 2.091 μs | 3.162 μs |    2 | 1.2500 | 0.3750 |     10 KB |
| dbExpression |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 114.28 μs | 3.266 μs | 4.937 μs |    3 | 1.2500 | 0.3750 |     10 KB |
| dbExpression |                                              &#39;Select First Record&#39; |        Person | 153.03 μs | 1.581 μs | 2.390 μs |    4 | 2.0000 | 0.5000 |     17 KB |
| dbExpression |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 161.48 μs | 0.276 μs | 0.464 μs |    5 | 1.2500 |      - |     10 KB |
| dbExpression |                            &#39;Select First Record With Where Clause&#39; |        Person | 168.59 μs | 1.454 μs | 2.198 μs |    6 | 2.2500 | 0.5000 |     19 KB |
| dbExpression |                          &#39;Select First Record With Join Condition&#39; |        Person | 171.27 μs | 1.927 μs | 3.238 μs |    6 | 2.2500 | 0.5000 |     19 KB |
| dbExpression |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 178.52 μs | 2.319 μs | 3.506 μs |    7 | 1.7500 | 0.5000 |     14 KB |
| dbExpression |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 180.90 μs | 1.973 μs | 2.982 μs |    7 | 1.7500 | 0.5000 |     14 KB |
| dbExpression |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 213.48 μs | 1.297 μs | 2.180 μs |    8 | 2.5000 | 0.5000 |     24 KB |
| dbExpression |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 232.84 μs | 3.445 μs | 5.208 μs |    9 | 3.0000 | 0.5000 |     26 KB |
| dbExpression | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 243.83 μs | 1.638 μs | 2.753 μs |   10 | 3.0000 | 0.5000 |     25 KB |


``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|    ORM |                                                             Method |        Return |     Mean |  StdDev |   Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|--------:|--------:|-----:|-------:|-------:|----------:|
| EFCore |                                              &#39;Select First Record&#39; |        Person | 137.2 μs | 2.44 μs | 3.69 μs |    1 | 1.0000 |      - |      8 KB |
| EFCore |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 143.7 μs | 1.26 μs | 1.91 μs |    2 | 0.7500 |      - |      8 KB |
| EFCore |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 157.3 μs | 2.64 μs | 3.98 μs |    3 | 1.0000 | 0.2500 |     10 KB |
| EFCore |                            &#39;Select First Record With Where Clause&#39; |        Person | 157.3 μs | 1.44 μs | 2.42 μs |    3 | 1.2500 |      - |     12 KB |
| EFCore |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 158.0 μs | 3.14 μs | 4.75 μs |    3 | 1.0000 | 0.2500 |     10 KB |
| EFCore |                          &#39;Select First Record With Join Condition&#39; |        Person | 185.1 μs | 6.16 μs | 9.31 μs |    4 | 1.2500 |      - |     12 KB |
| EFCore |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 208.4 μs | 1.74 μs | 2.63 μs |    5 | 1.2500 |      - |     12 KB |
| EFCore |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 210.2 μs | 1.26 μs | 2.12 μs |    5 | 1.2500 |      - |     11 KB |
| EFCore |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 225.2 μs | 1.83 μs | 2.76 μs |    6 | 1.5000 |      - |     14 KB |
| EFCore |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 225.7 μs | 3.47 μs | 5.24 μs |    6 | 1.5000 |      - |     13 KB |
| EFCore |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 229.8 μs | 3.30 μs | 4.99 μs |    6 | 1.5000 |      - |     13 KB |
| EFCore | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 249.5 μs | 2.28 μs | 3.45 μs |    7 | 1.5000 |      - |     15 KB |


``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|                  ORM |                                                             Method |        Return |     Mean |  StdDev |   Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|--------------------- |------------------------------------------------------------------- |-------------- |---------:|--------:|--------:|-----:|-------:|-------:|----------:|
| EFCore (No Tracking) |                                              &#39;Select First Record&#39; |        Person | 135.4 μs | 2.00 μs | 3.36 μs |    1 | 1.0000 | 0.2500 |      9 KB |
| EFCore (No Tracking) |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 144.7 μs | 6.38 μs | 9.65 μs |    2 | 0.7500 |      - |      8 KB |
| EFCore (No Tracking) |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 153.6 μs | 1.72 μs | 2.89 μs |    3 | 1.0000 | 0.2500 |     10 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 154.9 μs | 2.28 μs | 3.84 μs |    3 | 1.0000 | 0.2500 |     10 KB |
| EFCore (No Tracking) |                            &#39;Select First Record With Where Clause&#39; |        Person | 155.0 μs | 1.90 μs | 2.87 μs |    3 | 1.2500 | 0.2500 |     12 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Join Condition&#39; |        Person | 177.9 μs | 1.37 μs | 2.07 μs |    4 | 1.5000 | 0.5000 |     13 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 209.6 μs | 3.73 μs | 5.64 μs |    5 | 1.2500 | 0.2500 |     12 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 213.9 μs | 1.94 μs | 3.26 μs |    5 | 1.0000 |      - |     11 KB |
| EFCore (No Tracking) |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 228.5 μs | 1.05 μs | 2.00 μs |    6 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 229.5 μs | 2.45 μs | 3.70 μs |    6 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 231.3 μs | 1.37 μs | 2.07 μs |    6 | 1.5000 | 0.5000 |     15 KB |
| EFCore (No Tracking) | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 257.5 μs | 1.97 μs | 2.98 μs |    7 | 1.5000 | 0.5000 |     16 KB |


``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|    ORM |                                                             Method |        Return |      Mean |   StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |----------:|---------:|---------:|-----:|-------:|-------:|----------:|
| Dapper |                                              &#39;Select First Record&#39; |        Person |  82.25 μs | 1.227 μs | 2.062 μs |    1 | 0.5000 | 0.1250 |      5 KB |
| Dapper |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  85.37 μs | 2.847 μs | 4.304 μs |    2 | 0.2500 |      - |      2 KB |
| Dapper |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic |  86.80 μs | 0.973 μs | 1.471 μs |    2 | 0.3750 |      - |      3 KB |
| Dapper |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic |  87.63 μs | 1.498 μs | 2.264 μs |    2 | 0.3750 |      - |      3 KB |
| Dapper |                          &#39;Select First Record With Join Condition&#39; |        Person |  92.10 μs | 2.105 μs | 3.182 μs |    3 | 0.6250 | 0.1250 |      6 KB |
| Dapper |                            &#39;Select First Record With Where Clause&#39; |        Person |  92.54 μs | 1.371 μs | 2.072 μs |    3 | 0.6250 | 0.1250 |      6 KB |
| Dapper |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 137.43 μs | 0.331 μs | 0.633 μs |    4 | 0.5000 |      - |      5 KB |
| Dapper |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 140.93 μs | 0.850 μs | 1.624 μs |    5 | 0.7500 |      - |      7 KB |
| Dapper |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 149.34 μs | 1.034 μs | 1.563 μs |    6 | 0.5000 |      - |      6 KB |
| Dapper | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 149.46 μs | 0.889 μs | 1.345 μs |    6 | 1.0000 | 0.2500 |      8 KB |
| Dapper |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 151.75 μs | 1.977 μs | 2.988 μs |    6 | 0.5000 |      - |      5 KB |
| Dapper |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 151.96 μs | 0.466 μs | 0.892 μs |    6 | 1.0000 | 0.2500 |      8 KB |
