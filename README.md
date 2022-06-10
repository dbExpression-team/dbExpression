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

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1706 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.202
  [Host]   : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  ShortRun : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|          ORM |                                                             Method |        Return |     Mean |  StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------------- |------------------------------------------------------------------- |-------------- |---------:|--------:|---------:|-----:|-------:|-------:|----------:|
| dbExpression |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 132.9 μs | 8.25 μs | 13.86 μs |    1 | 0.7500 |      - |      6 KB |
| dbExpression |                                              &#39;Select First Record&#39; |        Person | 140.3 μs | 3.01 μs |  4.56 μs |    2 | 1.5000 | 0.2500 |     14 KB |
| dbExpression |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 147.4 μs | 1.40 μs |  2.67 μs |    3 | 1.0000 | 0.2500 |      9 KB |
| dbExpression |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 148.5 μs | 2.33 μs |  3.91 μs |    3 | 1.0000 | 0.2500 |      9 KB |
| dbExpression |                          &#39;Select First Record With Join Condition&#39; |        Person | 175.0 μs | 1.16 μs |  1.95 μs |    4 | 1.7500 | 0.2500 |     15 KB |
| dbExpression |                            &#39;Select First Record With Where Clause&#39; |        Person | 176.8 μs | 1.04 μs |  1.74 μs |    4 | 1.7500 | 0.2500 |     16 KB |
| dbExpression |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 205.3 μs | 1.01 μs |  1.52 μs |    5 | 1.0000 |      - |      9 KB |
| dbExpression |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 217.0 μs | 6.48 μs |  9.80 μs |    6 | 1.5000 | 0.5000 |     13 KB |
| dbExpression |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 225.4 μs | 9.82 μs | 18.78 μs |    6 | 1.5000 | 0.5000 |     13 KB |
| dbExpression |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 249.1 μs | 9.47 μs | 15.92 μs |    7 | 2.5000 | 0.5000 |     21 KB |
| dbExpression |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 257.9 μs | 2.49 μs |  4.18 μs |    8 | 2.5000 | 0.5000 |     22 KB |
| dbExpression | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 270.8 μs | 3.30 μs |  4.98 μs |    9 | 2.5000 | 0.5000 |     22 KB |


``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1706 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.202
  [Host]   : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  ShortRun : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|    ORM |                                                             Method |        Return |       Mean |    StdDev |       Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |-----------:|----------:|------------:|-----:|-------:|-------:|----------:|
| EFCore |                                              &#39;Select First Record&#39; |        Person |   147.2 μs |  12.78 μs |    19.32 μs |    1 | 1.0000 |      - |      8 KB |
| EFCore |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic |   162.1 μs |   2.85 μs |     4.30 μs |    2 | 1.0000 | 0.2500 |     10 KB |
| EFCore |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic |   163.3 μs |   1.83 μs |     2.77 μs |    2 | 1.0000 | 0.2500 |     10 KB |
| EFCore |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |   174.8 μs |  35.25 μs |    59.23 μs |    2 | 0.5000 |      - |      8 KB |
| EFCore |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; |   217.1 μs |   4.83 μs |     7.30 μs |    3 | 1.0000 |      - |     12 KB |
| EFCore |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; |   223.0 μs |   3.14 μs |     4.75 μs |    4 | 1.0000 |      - |     11 KB |
| EFCore |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; |   229.1 μs |   3.75 μs |     6.31 μs |    5 | 1.5000 |      - |     13 KB |
| EFCore |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; |   232.9 μs |   3.08 μs |     4.66 μs |    5 | 1.5000 |      - |     13 KB |
| EFCore |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; |   236.0 μs |   4.41 μs |     6.67 μs |    5 | 1.5000 |      - |     15 KB |
| EFCore | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; |   252.7 μs |   1.20 μs |     2.30 μs |    6 | 1.5000 |      - |     16 KB |
| EFCore |                            &#39;Select First Record With Where Clause&#39; |        Person |   438.9 μs | 144.29 μs |   218.15 μs |    7 |      - |      - |     11 KB |
| EFCore |                          &#39;Select First Record With Join Condition&#39; |        Person | 1,265.3 μs | 753.67 μs | 1,139.44 μs |    8 |      - |      - |     12 KB |


``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1706 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.202
  [Host]   : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  ShortRun : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                  ORM |                                                             Method |        Return |     Mean |  StdDev |   Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|--------------------- |------------------------------------------------------------------- |-------------- |---------:|--------:|--------:|-----:|-------:|-------:|----------:|
| EFCore (No Tracking) |                                              &#39;Select First Record&#39; |        Person | 141.2 μs | 1.39 μs | 2.34 μs |    1 | 1.0000 | 0.2500 |      9 KB |
| EFCore (No Tracking) |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 150.4 μs | 2.02 μs | 3.05 μs |    2 | 0.7500 |      - |      8 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 157.9 μs | 2.74 μs | 4.61 μs |    3 | 1.0000 | 0.2500 |     10 KB |
| EFCore (No Tracking) |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 160.8 μs | 2.02 μs | 3.05 μs |    3 | 1.0000 | 0.2500 |     10 KB |
| EFCore (No Tracking) |                            &#39;Select First Record With Where Clause&#39; |        Person | 161.8 μs | 2.25 μs | 3.79 μs |    3 | 1.2500 | 0.2500 |     12 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Join Condition&#39; |        Person | 180.3 μs | 1.69 μs | 2.55 μs |    4 | 1.5000 | 0.5000 |     12 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 216.9 μs | 2.64 μs | 3.99 μs |    5 | 1.5000 | 0.5000 |     13 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 218.0 μs | 3.25 μs | 5.46 μs |    5 | 1.0000 |      - |     11 KB |
| EFCore (No Tracking) |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 230.0 μs | 4.36 μs | 6.59 μs |    6 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 231.0 μs | 4.28 μs | 6.46 μs |    6 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 235.2 μs | 4.14 μs | 6.25 μs |    6 | 1.5000 | 0.5000 |     16 KB |
| EFCore (No Tracking) | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 251.4 μs | 3.26 μs | 4.92 μs |    7 | 1.5000 | 0.5000 |     16 KB |


``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1706 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.202
  [Host]   : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  ShortRun : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|    ORM |                                                             Method |        Return |      Mean |   StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |----------:|---------:|---------:|-----:|-------:|-------:|----------:|
| Dapper |                                              &#39;Select First Record&#39; |        Person |  82.64 μs | 1.410 μs | 2.132 μs |    1 | 0.5000 | 0.1250 |      5 KB |
| Dapper |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  85.46 μs | 1.186 μs | 1.993 μs |    2 | 0.2500 |      - |      2 KB |
| Dapper |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic |  87.61 μs | 0.663 μs | 1.115 μs |    3 | 0.3750 |      - |      3 KB |
| Dapper |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic |  88.12 μs | 1.754 μs | 2.651 μs |    3 | 0.3750 |      - |      3 KB |
| Dapper |                          &#39;Select First Record With Join Condition&#39; |        Person |  92.61 μs | 1.269 μs | 2.132 μs |    4 | 0.6250 | 0.1250 |      6 KB |
| Dapper |                            &#39;Select First Record With Where Clause&#39; |        Person |  93.34 μs | 1.275 μs | 1.928 μs |    4 | 0.6250 | 0.1250 |      6 KB |
| Dapper |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 140.14 μs | 1.209 μs | 1.828 μs |    5 | 0.7500 |      - |      7 KB |
| Dapper |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 141.13 μs | 2.390 μs | 3.613 μs |    5 | 0.5000 |      - |      5 KB |
| Dapper |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 149.61 μs | 1.446 μs | 2.430 μs |    6 | 0.5000 |      - |      6 KB |
| Dapper |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 149.77 μs | 1.646 μs | 2.488 μs |    6 | 0.5000 |      - |      5 KB |
| Dapper | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 149.91 μs | 2.545 μs | 3.847 μs |    6 | 1.0000 | 0.2500 |      8 KB |
| Dapper |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 152.44 μs | 2.190 μs | 3.680 μs |    6 | 1.0000 | 0.2500 |      8 KB |
