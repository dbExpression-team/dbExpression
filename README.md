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

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2130/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|          ORM |                                                             Method |        Return |     Mean |   StdDev |     Error | Rank |   Gen0 |   Gen1 | Allocated |
|------------- |------------------------------------------------------------------- |-------------- |---------:|---------:|----------:|-----:|-------:|-------:|----------:|
| dbExpression |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 198.3 μs | 19.07 μs |  28.82 μs |    1 | 0.7500 |      - |   7.61 KB |
| dbExpression |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 210.3 μs | 17.04 μs |  25.76 μs |    1 | 1.0000 | 0.2500 |   10.2 KB |
| dbExpression |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 221.3 μs | 25.49 μs |  38.53 μs |    1 | 1.0000 | 0.2500 |  10.09 KB |
| dbExpression |                            &#39;Select First Record With Where Clause&#39; |        Person | 284.7 μs | 18.10 μs |  27.37 μs |    2 | 2.0000 | 0.5000 |  18.71 KB |
| dbExpression |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 329.4 μs | 17.71 μs |  29.76 μs |    3 | 1.0000 |      - |   9.77 KB |
| dbExpression |                                              &#39;Select First Record&#39; |        Person | 336.6 μs | 35.99 μs |  60.49 μs |    3 | 2.0000 | 0.5000 |  16.84 KB |
| dbExpression |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 358.4 μs | 27.47 μs |  46.16 μs |    3 | 1.5000 | 0.5000 |  12.51 KB |
| dbExpression |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 378.0 μs | 34.86 μs |  52.71 μs |    3 | 1.5000 | 0.5000 |   12.4 KB |
| dbExpression |                          &#39;Select First Record With Join Condition&#39; |        Person | 398.5 μs | 17.74 μs |  29.82 μs |    3 | 2.0000 | 0.5000 |  18.03 KB |
| dbExpression |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 400.3 μs | 26.88 μs |  40.64 μs |    3 | 2.0000 | 0.5000 |  19.02 KB |
| dbExpression |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 443.6 μs | 72.04 μs | 108.92 μs |    3 | 2.5000 | 0.5000 |  20.98 KB |
| dbExpression | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 518.6 μs | 47.72 μs |  72.14 μs |    4 | 2.0000 | 0.5000 |  20.21 KB |


``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2130/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|    ORM |                                                             Method |        Return |     Mean |   StdDev |     Error | Rank |   Gen0 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|---------:|----------:|-----:|-------:|----------:|
| EFCore |                                              &#39;Select First Record&#39; |        Person | 254.0 μs | 22.16 μs |  33.50 μs |    1 | 1.0000 |   8.29 KB |
| EFCore |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 328.2 μs | 29.65 μs |  49.82 μs |    2 |      - |   7.62 KB |
| EFCore |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 335.6 μs | 34.78 μs |  52.59 μs |    2 | 1.0000 |   9.98 KB |
| EFCore |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 357.4 μs | 30.92 μs |  46.74 μs |    2 | 1.0000 |   9.94 KB |
| EFCore |                            &#39;Select First Record With Where Clause&#39; |        Person | 382.8 μs | 34.58 μs |  58.10 μs |    2 | 1.0000 |  11.91 KB |
| EFCore |                          &#39;Select First Record With Join Condition&#39; |        Person | 383.6 μs | 43.41 μs |  72.94 μs |    2 | 1.0000 |  12.02 KB |
| EFCore |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 396.8 μs | 27.85 μs |  42.11 μs |    2 | 1.0000 |  11.79 KB |
| EFCore | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 434.8 μs | 33.50 μs |  50.65 μs |    3 | 1.0000 |  15.53 KB |
| EFCore |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 444.7 μs | 62.23 μs | 104.58 μs |    3 |      - |  14.55 KB |
| EFCore |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 457.0 μs | 33.26 μs |  50.28 μs |    3 | 1.0000 |  13.02 KB |
| EFCore |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 457.3 μs | 82.23 μs | 124.32 μs |    3 | 1.0000 |   10.8 KB |
| EFCore |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 485.6 μs | 49.15 μs |  74.30 μs |    3 | 1.0000 |  12.89 KB |



``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2130/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                  ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |   Gen0 |   Gen1 | Allocated |
|--------------------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|-------:|----------:|
| EFCore (No Tracking) |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 238.9 μs | 16.87 μs | 25.51 μs |    1 | 1.0000 |      - |   9.98 KB |
| EFCore (No Tracking) |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 239.7 μs | 11.65 μs | 17.62 μs |    1 | 0.7500 |      - |   7.62 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 248.9 μs | 24.17 μs | 36.54 μs |    1 | 1.0000 |      - |   9.94 KB |
| EFCore (No Tracking) |                                              &#39;Select First Record&#39; |        Person | 260.6 μs | 58.61 μs | 98.49 μs |    1 | 1.0000 | 0.2500 |   8.58 KB |
| EFCore (No Tracking) |                            &#39;Select First Record With Where Clause&#39; |        Person | 264.1 μs | 17.40 μs | 26.31 μs |    2 | 1.0000 |      - |  11.51 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Join Condition&#39; |        Person | 292.0 μs | 24.33 μs | 40.89 μs |    3 | 1.5000 | 0.5000 |  12.32 KB |
| EFCore (No Tracking) |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 310.8 μs | 23.52 μs | 35.56 μs |    3 | 1.5000 |      - |  13.06 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 327.7 μs | 22.46 μs | 37.74 μs |    3 | 1.0000 |      - |  11.84 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 365.6 μs | 40.73 μs | 61.57 μs |    3 | 1.0000 |      - |  10.97 KB |
| EFCore (No Tracking) |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 378.9 μs | 44.67 μs | 75.07 μs |    3 | 1.5000 |      - |  13.02 KB |
| EFCore (No Tracking) |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 386.5 μs | 35.48 μs | 53.63 μs |    3 | 1.0000 |      - |  14.77 KB |
| EFCore (No Tracking) | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 416.8 μs | 47.50 μs | 71.81 μs |    3 | 2.0000 |      - |  16.72 KB |



``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.2130/20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100-preview.7.22377.5
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|    ORM |                                                             Method |        Return |     Mean |   StdDev |    Error | Rank |   Gen0 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|---------:|---------:|-----:|-------:|----------:|
| Dapper |                                              &#39;Select First Record&#39; |        Person | 125.9 μs |  6.38 μs |  9.64 μs |    1 | 0.5000 |   4.66 KB |
| Dapper |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 129.3 μs |  6.74 μs | 11.33 μs |    1 | 0.2500 |   2.45 KB |
| Dapper |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 135.1 μs |  8.34 μs | 12.62 μs |    2 | 0.2500 |   3.17 KB |
| Dapper |                          &#39;Select First Record With Join Condition&#39; |        Person | 138.8 μs |  6.64 μs | 11.16 μs |    2 | 0.5000 |    5.8 KB |
| Dapper |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 142.6 μs | 11.51 μs | 22.01 μs |    2 | 0.2500 |   3.21 KB |
| Dapper |                            &#39;Select First Record With Where Clause&#39; |        Person | 152.9 μs |  9.13 μs | 13.80 μs |    3 | 0.5000 |   5.68 KB |
| Dapper |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 212.7 μs | 21.10 μs | 31.90 μs |    4 |      - |   3.84 KB |
| Dapper |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 214.0 μs | 12.42 μs | 20.87 μs |    4 | 0.5000 |   6.34 KB |
| Dapper |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 220.4 μs |  5.46 μs | 10.45 μs |    5 | 0.5000 |   7.43 KB |
| Dapper | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 222.4 μs |  9.90 μs | 14.97 μs |    5 | 0.7500 |   7.48 KB |
| Dapper |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 229.9 μs | 16.14 μs | 24.41 μs |    5 | 0.5000 |   4.21 KB |
| Dapper |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 250.5 μs | 29.24 μs | 49.13 μs |    5 | 0.5000 |   4.96 KB |




