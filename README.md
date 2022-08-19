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
|          ORM |                                                             Method |        Return |      Mean |   StdDev |     Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------------- |------------------------------------------------------------------- |-------------- |----------:|---------:|----------:|-----:|-------:|-------:|----------:|
| dbExpression |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  94.22 μs | 2.676 μs |  4.046 μs |    1 | 0.8750 |      - |      8 KB |
| dbExpression |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 107.94 μs | 2.042 μs |  3.088 μs |    2 | 1.2500 | 0.3750 |     10 KB |
| dbExpression |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 108.24 μs | 1.734 μs |  2.621 μs |    2 | 1.2500 | 0.3750 |     10 KB |
| dbExpression |                                              &#39;Select First Record&#39; |        Person | 147.62 μs | 2.144 μs |  3.603 μs |    3 | 2.0000 | 0.5000 |     17 KB |
| dbExpression |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 156.97 μs | 2.732 μs |  4.130 μs |    4 | 1.0000 |      - |     10 KB |
| dbExpression |                            &#39;Select First Record With Where Clause&#39; |        Person | 163.76 μs | 2.919 μs |  4.414 μs |    5 | 2.2500 | 0.5000 |     19 KB |
| dbExpression |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 171.30 μs | 3.129 μs |  4.730 μs |    6 | 1.5000 | 0.5000 |     14 KB |
| dbExpression |                          &#39;Select First Record With Join Condition&#39; |        Person | 173.58 μs | 2.634 μs |  3.983 μs |    6 | 2.2500 | 0.5000 |     19 KB |
| dbExpression |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 174.02 μs | 3.452 μs |  5.219 μs |    6 | 1.5000 | 0.5000 |     14 KB |
| dbExpression |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 209.69 μs | 6.621 μs | 10.011 μs |    7 | 2.5000 | 0.5000 |     24 KB |
| dbExpression |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 224.83 μs | 5.156 μs |  7.795 μs |    8 | 3.0000 | 0.5000 |     26 KB |
| dbExpression | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 238.20 μs | 7.031 μs | 10.630 μs |    9 | 3.0000 | 0.5000 |     25 KB |



``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|    ORM |                                                             Method |        Return |     Mean |  StdDev |   Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |---------:|--------:|--------:|-----:|-------:|-------:|----------:|
| EFCore |                                              &#39;Select First Record&#39; |        Person | 131.9 μs | 4.10 μs | 6.20 μs |    1 | 1.0000 |      - |      8 KB |
| EFCore |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 144.6 μs | 4.48 μs | 6.78 μs |    2 | 0.7500 |      - |      8 KB |
| EFCore |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 147.9 μs | 2.67 μs | 4.03 μs |    2 | 1.0000 | 0.2500 |     10 KB |
| EFCore |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 151.4 μs | 3.00 μs | 4.54 μs |    2 | 1.0000 | 0.2500 |     10 KB |
| EFCore |                            &#39;Select First Record With Where Clause&#39; |        Person | 161.2 μs | 6.11 μs | 9.24 μs |    3 | 1.2500 |      - |     12 KB |
| EFCore |                          &#39;Select First Record With Join Condition&#39; |        Person | 175.5 μs | 2.08 μs | 3.50 μs |    4 | 1.2500 |      - |     12 KB |
| EFCore |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 198.7 μs | 3.56 μs | 5.38 μs |    5 | 1.2500 |      - |     12 KB |
| EFCore |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 206.5 μs | 6.06 μs | 9.16 μs |    6 | 1.0000 |      - |     11 KB |
| EFCore |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 216.6 μs | 4.74 μs | 7.17 μs |    7 | 1.5000 |      - |     14 KB |
| EFCore |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 219.1 μs | 4.57 μs | 7.67 μs |    7 | 1.5000 |      - |     13 KB |
| EFCore |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 219.2 μs | 5.07 μs | 8.52 μs |    7 | 1.5000 |      - |     13 KB |
| EFCore | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 237.9 μs | 4.77 μs | 7.20 μs |    8 | 1.5000 |      - |     15 KB |



``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|                  ORM |                                                             Method |        Return |     Mean |  StdDev |   Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|--------------------- |------------------------------------------------------------------- |-------------- |---------:|--------:|--------:|-----:|-------:|-------:|----------:|
| EFCore (No Tracking) |                                              &#39;Select First Record&#39; |        Person | 135.3 μs | 4.79 μs | 7.24 μs |    1 | 1.0000 | 0.2500 |      9 KB |
| EFCore (No Tracking) |                           &#39;Select First Record With Scalar Return&#39; |         Int32 | 139.5 μs | 3.27 μs | 4.94 μs |    1 | 0.7500 |      - |      8 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic | 148.1 μs | 2.28 μs | 3.45 μs |    2 | 1.0000 | 0.2500 |     10 KB |
| EFCore (No Tracking) |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic | 153.9 μs | 5.01 μs | 7.58 μs |    3 | 1.0000 | 0.2500 |     10 KB |
| EFCore (No Tracking) |                            &#39;Select First Record With Where Clause&#39; |        Person | 154.5 μs | 5.22 μs | 9.97 μs |    3 | 1.2500 | 0.2500 |     12 KB |
| EFCore (No Tracking) |                          &#39;Select First Record With Join Condition&#39; |        Person | 172.3 μs | 3.33 μs | 5.04 μs |    4 | 1.5000 | 0.5000 |     13 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 201.8 μs | 3.79 μs | 5.73 μs |    5 | 1.2500 | 0.2500 |     12 KB |
| EFCore (No Tracking) |                     &#39;Async Select First Record With Scalar Return&#39; | Task&lt;dynamic&gt; | 205.2 μs | 5.72 μs | 8.64 μs |    5 | 1.2500 |      - |     11 KB |
| EFCore (No Tracking) |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 214.3 μs | 5.18 μs | 7.83 μs |    6 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 215.2 μs | 2.00 μs | 3.83 μs |    6 | 1.5000 | 0.5000 |     15 KB |
| EFCore (No Tracking) |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 217.5 μs | 4.38 μs | 6.62 μs |    6 | 1.5000 |      - |     13 KB |
| EFCore (No Tracking) | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 238.1 μs | 3.78 μs | 5.72 μs |    7 | 1.5000 | 0.5000 |     16 KB |



``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1889 (20H2/October2020Update)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.303
  [Host]   : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT
  ShortRun : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT


```
|    ORM |                                                             Method |        Return |      Mean |   StdDev |    Error | Rank |  Gen 0 |  Gen 1 | Allocated |
|------- |------------------------------------------------------------------- |-------------- |----------:|---------:|---------:|-----:|-------:|-------:|----------:|
| Dapper |                                              &#39;Select First Record&#39; |        Person |  84.22 μs | 1.791 μs | 2.708 μs |    1 | 0.5000 | 0.1250 |      5 KB |
| Dapper |                           &#39;Select First Record With Scalar Return&#39; |         Int32 |  85.34 μs | 2.512 μs | 3.798 μs |    1 | 0.2500 |      - |      2 KB |
| Dapper |                          &#39;Select First Record With Dynamic Return&#39; |       dynamic |  87.76 μs | 5.038 μs | 7.616 μs |    1 | 0.3750 |      - |      3 KB |
| Dapper |        &#39;Select First Record With Dynamic Return (aliased columns)&#39; |       dynamic |  89.55 μs | 1.963 μs | 2.968 μs |    1 | 0.3750 |      - |      3 KB |
| Dapper |                          &#39;Select First Record With Join Condition&#39; |        Person |  91.15 μs | 2.836 μs | 4.766 μs |    1 | 0.6250 | 0.1250 |      6 KB |
| Dapper |                            &#39;Select First Record With Where Clause&#39; |        Person |  93.22 μs | 0.511 μs | 0.773 μs |    1 | 0.6250 | 0.1250 |      6 KB |
| Dapper |                    &#39;Async Select First Record With Dynamic Return&#39; | Task&lt;dynamic&gt; | 134.75 μs | 0.722 μs | 1.213 μs |    2 | 0.5000 |      - |      5 KB |
| Dapper |                     &#39;Async Select First Record With Entity Return&#39; |  Task&lt;Person&gt; | 144.19 μs | 1.587 μs | 2.400 μs |    3 | 0.7500 |      - |      7 KB |
| Dapper | &#39;Async Select First Record With Join Condition With Entity Return&#39; |  Task&lt;Person&gt; | 146.04 μs | 1.211 μs | 2.036 μs |    3 | 1.0000 | 0.2500 |      8 KB |
| Dapper |                     &#39;Async Select First Record With Scalar Return&#39; |   Task&lt;Int32&gt; | 146.20 μs | 4.455 μs | 6.735 μs |    3 | 0.5000 |      - |      5 KB |
| Dapper |  &#39;Async Select First Record With Dynamic Return (aliased columns)&#39; | Task&lt;dynamic&gt; | 147.01 μs | 1.624 μs | 2.456 μs |    3 | 0.5000 |      - |      6 KB |
| Dapper |   &#39;Async Select First Record With Where Clause With Entity Return&#39; |  Task&lt;Person&gt; | 148.54 μs | 1.324 μs | 2.532 μs |    3 | 1.0000 | 0.2500 |      8 KB |


