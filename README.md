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

With dbExpression, the code that handles the basics of pushing and pulling data in and out of your database is generated via a CLI tool.  The code contains all of the classes and functional plumbing necessary to insert, update, delete and query your data with expressions that live directly within your application code.  When you modify your database in any way, regenerating the code exposes those changes to your application, keeping schema changes in sync with your application code.

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
And here's the SQL statement dbExpression assembled and executed against the database:
```sql
exec sp_executesql N'SELECT
	[dbo].[Person].[Id],
	([dbo].[Person].[FirstName] + @P1 + [dbo].[Person].[LastName]) AS [CustomerName],
	COUNT([dbo].[Purchase].[ShipDate]) AS [ShippedCount],
	DATEPART(year, [dbo].[Purchase].[ShipDate]) AS [ShippedYear]
FROM
	[dbo].[Purchase]
	INNER JOIN [dbo].[Person] ON [dbo].[Purchase].[PersonId] = [dbo].[Person].[Id]
WHERE
	[dbo].[Purchase].[ShipDate] IS NOT NULL
GROUP BY
	[dbo].[Person].[Id],
	[dbo].[Person].[FirstName],
	[dbo].[Person].[LastName],
	DATEPART(year, [dbo].[Purchase].[ShipDate])
;',N'@P1 char(1)',@P1=' '
```

dbExpression was designed to work statically or with dependency injection.  The decision for which to use is typically based on the type of project, 
the team environment, and just what works best for you - it's your choice!
* Statically using a static database accessor to fluently build and execute queries.  This is great for environments or projects where this works best.
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

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2251/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]   : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  ShortRun : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|          ORM |                                                             Method |        Return |     Mean |    StdDev |     Error | Rank |   Gen0 |   Gen1 | Allocated |
|------------- |------------------------------------------------------------------- |-------------- |---------:|----------:|----------:|-----:|-------:|-------:|----------:|
| dbExpression |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 127.2 μs |   4.30 μs |   6.51 μs |    1 | 0.8750 |      - |   7.71 KB |
| dbExpression |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 148.8 μs |   4.16 μs |   6.99 μs |    2 | 1.2500 | 0.2500 |   10.3 KB |
| dbExpression |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 163.2 μs |  13.25 μs |  20.04 μs |    3 | 1.0000 |      - |  10.19 KB |
| dbExpression |                            &#39;Select First Record With Where Clause&#39; |        Person | 213.6 μs |   5.51 μs |   8.34 μs |    4 | 2.2500 | 0.2500 |  18.78 KB |
| dbExpression |                                              &#39;Select First Record&#39; |        Person | 273.2 μs |   9.66 μs |  14.60 μs |    5 | 2.0000 |      - |  16.92 KB |
| dbExpression |                          &#39;Select First Record With Join Condition&#39; |        Person | 294.0 μs |   4.28 μs |   7.19 μs |    6 | 2.0000 |      - |   18.1 KB |
| dbExpression |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 318.1 μs |   9.57 μs |  14.47 μs |    7 | 2.0000 |      - |  19.09 KB |
| dbExpression | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 354.4 μs |   8.64 μs |  13.07 μs |    8 | 2.5000 |      - |  20.28 KB |
| dbExpression |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 416.0 μs |  64.19 μs | 107.87 μs |    9 | 1.0000 |      - |   9.88 KB |
| dbExpression |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 439.6 μs |  25.84 μs |  49.40 μs |   10 | 1.0000 |      - |  12.61 KB |
| dbExpression |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 468.6 μs |  36.37 μs |  54.99 μs |   10 | 1.0000 |      - |   12.5 KB |
| dbExpression |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 681.7 μs | 185.54 μs | 280.51 μs |   11 | 2.0000 |      - |  21.05 KB |

### EF Core (7.0.0)

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2251/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]   : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  ShortRun : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|    ORM |                                                             Method |        Return |     Mean |    StdDev |     Error | Rank |   Gen0 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|----------:|----------:|-----:|-------:|----------:|
| EFCore |                                              &#39;Select First Record&#39; |        Person | 394.9 μs |  14.85 μs |  28.39 μs |    1 |      - |   7.58 KB |
| EFCore |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 423.1 μs |  53.09 μs |  80.27 μs |    1 |      - |   6.17 KB |
| EFCore |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 462.8 μs |  24.14 μs |  36.50 μs |    1 | 1.0000 |   8.19 KB |
| EFCore |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 490.6 μs | 158.56 μs | 239.72 μs |    1 | 1.0000 |  11.49 KB |
| EFCore |                            &#39;Select First Record With Where Clause&#39; |        Person | 490.7 μs |  27.46 μs |  41.51 μs |    1 | 1.0000 |   9.81 KB |
| EFCore |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 499.6 μs |  29.17 μs |  44.10 μs |    1 | 1.0000 |   8.23 KB |
| EFCore |                          &#39;Select First Record With Join Condition&#39; |        Person | 544.3 μs |  11.70 μs |  22.37 μs |    2 | 1.0000 |  10.57 KB |
| EFCore |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 604.4 μs |  64.91 μs |  98.13 μs |    3 | 1.0000 |   9.34 KB |
| EFCore | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 632.3 μs | 131.12 μs | 198.23 μs |    3 | 1.0000 |  13.91 KB |
| EFCore |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 636.1 μs |  58.48 μs |  88.42 μs |    3 | 1.0000 |  13.14 KB |
| EFCore |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 671.9 μs |  21.63 μs |  32.70 μs |    3 | 1.0000 |  10.91 KB |
| EFCore |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 690.9 μs |  82.82 μs | 125.22 μs |    3 | 1.0000 |  11.45 KB |



``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2251/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]   : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  ShortRun : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|                  ORM |                                                             Method |        Return |     Mean |   StdDev |     Error | Rank |   Gen0 | Allocated |
|--------------------- |------------------------------------------------------------------- |-------------- |---------:|---------:|----------:|-----:|-------:|----------:|
| EFCore (No Tracking) |                                              &#39;Select First Record&#39; |        Person | 158.8 μs |  5.67 μs |   9.53 μs |    1 | 0.7500 |   7.87 KB |
| EFCore (No Tracking) |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 434.3 μs | 24.51 μs |  37.06 μs |    2 |      - |   6.17 KB |
| EFCore (No Tracking) |                            &#39;Select First Record With Where Clause&#39; |        Person | 470.0 μs | 30.45 μs |  46.03 μs |    3 | 1.0000 |   10.1 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 483.2 μs | 26.61 μs |  40.24 μs |    3 | 1.0000 |   8.19 KB |
| EFCore (No Tracking) |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 492.3 μs | 27.60 μs |  41.72 μs |    3 | 1.0000 |   8.23 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Join Condition&#39; |        Person | 504.3 μs | 19.78 μs |  29.91 μs |    3 | 1.0000 |  10.99 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 597.9 μs | 35.71 μs |  53.98 μs |    4 | 1.0000 |  11.13 KB |
| EFCore (No Tracking) |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 642.8 μs | 16.79 μs |  28.21 μs |    5 | 1.0000 |  11.45 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 643.0 μs | 34.18 μs |  51.67 μs |    5 | 1.0000 |   9.34 KB |
| EFCore (No Tracking) |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 661.3 μs | 83.50 μs | 126.24 μs |    5 | 1.0000 |  13.36 KB |
| EFCore (No Tracking) |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 670.4 μs | 45.44 μs |  68.70 μs |    5 | 1.0000 |  11.49 KB |
| EFCore (No Tracking) | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 736.0 μs | 43.99 μs |  66.51 μs |    6 | 1.0000 |  14.13 KB |

### Dapper (2.0.123)

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2251/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]   : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  ShortRun : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|    ORM |                                                             Method |        Return |      Mean |   StdDev |    Error | Rank |   Gen0 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |----------:|---------:|---------:|-----:|-------:|----------:|
| Dapper |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic |  95.12 μs | 1.441 μs | 2.421 μs |    1 | 0.3750 |   3.21 KB |
| Dapper |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  95.17 μs | 2.148 μs | 3.609 μs |    1 | 0.2500 |   2.45 KB |
| Dapper |                                              &#39;Select First Record&#39; |        Person |  95.22 μs | 4.614 μs | 6.976 μs |    1 | 0.5000 |   4.66 KB |
| Dapper |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic |  98.36 μs | 4.419 μs | 6.681 μs |    1 | 0.3750 |   3.17 KB |
| Dapper |                          &#39;Select First Record With Join Condition&#39; |        Person | 103.23 μs | 3.029 μs | 4.579 μs |    2 | 0.6250 |    5.8 KB |
| Dapper |                            &#39;Select First Record With Where Clause&#39; |        Person | 106.28 μs | 3.048 μs | 5.122 μs |    2 | 0.6250 |   5.68 KB |
| Dapper |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 145.64 μs | 5.671 μs | 8.574 μs |    3 | 0.2500 |   3.84 KB |
| Dapper |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 147.34 μs | 1.826 μs | 3.491 μs |    3 | 0.5000 |   4.21 KB |
| Dapper |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 148.97 μs | 3.683 μs | 5.568 μs |    3 | 0.7500 |   6.34 KB |
| Dapper |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 152.13 μs | 3.763 μs | 6.323 μs |    3 | 0.5000 |   4.96 KB |
| Dapper |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 160.28 μs | 2.146 μs | 3.244 μs |    4 | 0.7500 |   7.43 KB |
| Dapper | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 160.68 μs | 3.955 μs | 6.646 μs |    4 | 0.7500 |   7.48 KB |





