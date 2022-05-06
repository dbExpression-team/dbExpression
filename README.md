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
	,(([dbo].[Person].[FirstName] + @P1) + [dbo].[Person].[LastName]) AS [CustomerName]
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

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1526 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100
  [Host]   : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  ShortRun : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|          ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|-------:|----------:|
| dbExpression |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 189.9 μs |  7.25 μs | 12.18 μs |    1 | 0.7500 |      - |      6 KB |
| dbExpression |                                              &#39;Select First Record&#39; |        Person | 210.8 μs |  4.59 μs |  7.71 μs |    2 | 1.7500 | 0.2500 |     14 KB |
| dbExpression |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 212.0 μs | 12.29 μs | 18.58 μs |    2 | 1.0000 | 0.2500 |      8 KB |
| dbExpression |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 222.5 μs | 11.83 μs | 17.89 μs |    2 | 1.0000 |      - |      9 KB |
| dbExpression |                          &#39;Select First Record With Join Condition&#39; |        Person | 259.8 μs | 17.02 μs | 25.73 μs |    3 | 1.7500 | 0.2500 |     15 KB |
| dbExpression |                            &#39;Select First Record With Where Clause&#39; |        Person | 265.0 μs | 20.09 μs | 30.38 μs |    3 | 1.5000 |      - |     16 KB |
| dbExpression |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 287.5 μs | 14.74 μs | 22.28 μs |    4 | 1.0000 |      - |      9 KB |
| dbExpression |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 295.7 μs | 16.54 μs | 25.00 μs |    4 | 1.5000 | 0.5000 |     13 KB |
| dbExpression |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 297.3 μs |  9.01 μs | 15.14 μs |    4 | 1.5000 | 0.5000 |     13 KB |
| dbExpression |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 361.8 μs | 23.31 μs | 35.24 μs |    5 | 2.5000 | 0.5000 |     22 KB |
| dbExpression |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 367.4 μs | 14.05 μs | 21.24 μs |    5 | 2.5000 | 0.5000 |     24 KB |
| dbExpression | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 396.1 μs | 25.93 μs | 39.20 μs |    6 | 2.5000 | 0.5000 |     23 KB |


|    ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |  Gen 0 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|----------:|
| EFCore |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 269.0 μs |  8.20 μs | 12.40 μs |    1 | 1.0000 |     10 KB |
| EFCore |                                              &#39;Select First Record&#39; |        Person | 273.8 μs |  7.96 μs | 12.03 μs |    1 | 1.0000 |      8 KB |
| EFCore |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 277.4 μs | 14.51 μs | 24.38 μs |    1 | 1.0000 |     10 KB |
| EFCore |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 278.0 μs | 10.93 μs | 16.53 μs |    1 | 0.5000 |      8 KB |
| EFCore |                            &#39;Select First Record With Where Clause&#39; |        Person | 293.3 μs |  7.24 μs | 12.17 μs |    2 | 1.0000 |     11 KB |
| EFCore |                          &#39;Select First Record With Join Condition&#39; |        Person | 328.7 μs | 16.59 μs | 25.09 μs |    3 | 1.0000 |     12 KB |
| EFCore |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 353.6 μs |  9.26 μs | 17.70 μs |    4 | 1.0000 |     12 KB |
| EFCore | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 409.6 μs | 17.54 μs | 29.47 μs |    5 | 1.0000 |     15 KB |
| EFCore |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 410.9 μs | 12.09 μs | 20.31 μs |    5 | 1.0000 |     15 KB |
| EFCore |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 431.0 μs | 18.23 μs | 30.64 μs |    6 | 1.0000 |     13 KB |
| EFCore |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 432.1 μs | 12.71 μs | 21.37 μs |    6 | 1.0000 |     11 KB |
| EFCore |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 436.7 μs | 20.32 μs | 30.73 μs |    6 | 1.0000 |     13 KB |

|                  ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|--------------------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|-------:|----------:|
| EFCore (No Tracking) |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 252.8 μs |  6.20 μs |  9.37 μs |    1 | 0.7500 |      - |      8 KB |
| EFCore (No Tracking) |                                              &#39;Select First Record&#39; |        Person | 258.6 μs | 11.26 μs | 17.02 μs |    1 | 1.0000 |      - |      9 KB |
| EFCore (No Tracking) |                            &#39;Select First Record With Where Clause&#39; |        Person | 275.5 μs | 12.27 μs | 18.56 μs |    2 | 1.0000 |      - |     12 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 284.5 μs |  4.38 μs |  6.61 μs |    3 | 1.0000 |      - |     10 KB |
| EFCore (No Tracking) |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 285.7 μs |  8.30 μs | 12.55 μs |    3 | 1.0000 |      - |     10 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Join Condition&#39; |        Person | 300.5 μs | 13.83 μs | 20.91 μs |    4 | 1.5000 | 0.5000 |     12 KB |
| EFCore (No Tracking) |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 399.0 μs | 14.64 μs | 22.13 μs |    5 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 412.2 μs | 16.87 μs | 25.50 μs |    5 | 1.0000 |      - |     13 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 412.8 μs | 23.93 μs | 36.17 μs |    5 | 1.5000 | 0.5000 |     13 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 415.3 μs | 15.76 μs | 23.83 μs |    5 | 1.0000 |      - |     11 KB |
| EFCore (No Tracking) |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 433.3 μs | 16.18 μs | 27.19 μs |    6 | 1.0000 |      - |     16 KB |
| EFCore (No Tracking) | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 465.4 μs | 28.14 μs | 42.54 μs |    7 | 1.0000 |      - |     16 KB |

|    ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |  Gen 0 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|----------:|
| Dapper |                                              &#39;Select First Record&#39; |        Person | 150.1 μs |  3.91 μs |  6.57 μs |    1 | 0.5000 |      5 KB |
| Dapper |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 162.9 μs |  5.35 μs |  8.09 μs |    2 | 0.2500 |      3 KB |
| Dapper |                          &#39;Select First Record With Join Condition&#39; |        Person | 174.7 μs |  9.24 μs | 15.53 μs |    3 | 0.5000 |      6 KB |
| Dapper |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 175.0 μs |  6.75 μs | 10.20 μs |    3 | 0.2500 |      3 KB |
| Dapper |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 177.5 μs | 10.28 μs | 15.54 μs |    3 | 0.2500 |      2 KB |
| Dapper |                            &#39;Select First Record With Where Clause&#39; |        Person | 193.6 μs | 13.11 μs | 19.81 μs |    4 | 0.5000 |      6 KB |
| Dapper |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 244.9 μs |  7.79 μs | 11.77 μs |    5 | 0.5000 |      7 KB |
| Dapper | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 262.7 μs | 12.09 μs | 18.29 μs |    6 | 1.0000 |      8 KB |
| Dapper |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 273.6 μs | 10.46 μs | 17.57 μs |    6 | 0.5000 |      5 KB |
| Dapper |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 276.6 μs | 10.39 μs | 15.72 μs |    6 | 0.5000 |      5 KB |
| Dapper |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 280.5 μs |  7.92 μs | 13.30 μs |    6 | 1.0000 |      8 KB |
| Dapper |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 314.5 μs | 22.63 μs | 34.21 μs |    7 | 0.5000 |      6 KB |

