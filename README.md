![dbExpression](https://dbexpressionpublic.blob.core.windows.net/web/dbex-logo.png)

# Microsoft SQL Server. Simplified.

dbExpression is a Microsoft SQL Server database connector that enables fluent composition and execution of type safe SQL queries directly within compiled code.

**dbExpression supports Microsoft SQL Server versions 2005+.**

The docs can be found at [dbexpression.com/docs](https://dbexpression.com/docs).  

## Build Status

[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)

Using linux versions of Microsoft SQL Server on Docker images, integration tests are executed against the following versions:

| Platform            	| Status 					|
| :---------------------| :---------------------------------------------|
|	MSSQL 2017	|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=MSSQL2017%20-%20net7)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)	|
|	MSSQL 2019	|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=MSSQL2019%20-%20net7)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)	|
|	MSSQL 2022	|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=MSSQL2022%20-%20net7)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=master)	|

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
	[t0].[Id],
	([t0].[FirstName] + @P1 + [t0].[LastName]) AS [CustomerName],
	COUNT([t1].[ShipDate]) AS [ShippedCount],
	DATEPART(year, [t1].[ShipDate]) AS [ShippedYear]
FROM
	[dbo].[Purchase] AS [t1]
	INNER JOIN [dbo].[Person] AS [t0] ON [t1].[PersonId] = [t0].[Id]
WHERE
	[t1].[ShipDate] IS NOT NULL
GROUP BY
	[t0].[Id],
	[t0].[FirstName],
	[t0].[LastName],
	DATEPART(year, [t1].[ShipDate]);',N'@P1 varchar(1)',@P1=' '
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

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1574/21H2/SunValley)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.200
  [Host]   : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  ShortRun : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|          ORM |                                                       Method |               Return |     Mean |   StdDev |    Error | Rank |   Gen0 | Allocated |
|------------- |------------------------------------------------------------- |--------------------- |---------:|---------:|---------:|-----:|-------:|----------:|
| **dbExpression** |                                        **&#39;Select First Record&#39;** |               **Person** | **225.5 μs** |  **5.12 μs** |  **7.74 μs** |    **3** | **1.0000** |  **10.11 KB** |
| **dbExpression** |         **&#39;Select First With Dynamic Return (aliased columns)&#39;** |              **dynamic** | **183.3 μs** |  **2.45 μs** |  **4.12 μs** |    **2** | **0.7500** |   **7.12 KB** |
| **dbExpression** |   **&#39;Select First With Dynamic Return Async (aliased columns)&#39;** |        **Task&lt;dynamic&gt;** | **272.8 μs** |  **2.16 μs** |  **3.27 μs** |    **6** | **1.0000** |   **9.35 KB** |
| **dbExpression** |                     **&#39;Select First With Dynamic Return Async&#39;** |        **Task&lt;dynamic&gt;** | **269.6 μs** |  **2.14 μs** |  **3.23 μs** |    **6** | **1.0000** |   **9.46 KB** |
| **dbExpression** |                           **&#39;Select First With Dynamic Return&#39;** |              **dynamic** | **190.9 μs** |  **6.62 μs** | **11.13 μs** |    **2** | **0.7500** |   **7.22 KB** |
| **dbExpression** |                      **&#39;Select First With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **304.8 μs** |  **6.16 μs** |  **9.31 μs** |    **8** | **1.5000** |  **12.35 KB** |
| **dbExpression** |  **&#39;Select First With Join Condition With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **316.6 μs** |  **3.46 μs** |  **5.23 μs** |    **9** | **1.5000** |  **12.88 KB** |
| **dbExpression** |                           **&#39;Select First With Join Condition&#39;** |               **Person** | **219.5 μs** |  **4.66 μs** |  **7.04 μs** |    **3** | **1.2500** |  **10.64 KB** |
| **dbExpression** |                      **&#39;Select First With Scalar Return Async&#39;** |          **Task&lt;Int32&gt;** | **260.3 μs** |  **4.45 μs** |  **6.74 μs** |    **5** | **0.5000** |   **6.72 KB** |
| **dbExpression** |                            **&#39;Select First With Scalar Return&#39;** |                **Int32** | **173.6 μs** |  **3.28 μs** |  **4.96 μs** |    **1** | **0.5000** |   **4.58 KB** |
| **dbExpression** |    **&#39;Select First With Where Clause With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **314.3 μs** |  **5.84 μs** |  **8.83 μs** |    **9** | **1.5000** |  **13.86 KB** |
| **dbExpression** |                             **&#39;Select First With Where Clause&#39;** |               **Person** | **237.7 μs** | **10.62 μs** | **16.06 μs** |    **4** | **1.2500** |  **11.62 KB** |

### EF Core (7.0.3)

``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1574/21H2/SunValley)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.200
  [Host]   : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  ShortRun : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|    ORM |                                                             Method |               Return |     Mean |   StdDev |    Error | Rank |   Gen0 | Allocated |
|------- |------------------------------------------------------------------- |--------------------- |---------:|---------:|---------:|-----:|-------:|----------:|
| **EFCore** |        **&#39;Select First Record With Dynamic Return (aliased columns)&#39;** |              **dynamic** | **232.9 μs** |  **3.19 μs** |  **5.36 μs** |    **2** | **1.0000** |   **8.34 KB** |
| **EFCore** |  **&#39;Select First Record With Dynamic Return Async (aliased columns)&#39;** |        **Task&lt;dynamic&gt;** | **315.7 μs** |  **3.16 μs** |  **4.78 μs** |    **6** | **1.0000** |  **11.45 KB** |
| **EFCore** |                    **&#39;Select First Record With Dynamic Return Async&#39;** |        **Task&lt;dynamic&gt;** | **329.8 μs** | **12.78 μs** | **19.32 μs** |    **7** | **1.0000** |  **11.42 KB** |
| **EFCore** |                          **&#39;Select First Record With Dynamic Return&#39;** |              **dynamic** | **231.0 μs** |  **2.17 μs** |  **3.65 μs** |    **2** | **1.0000** |   **8.19 KB** |
| **EFCore** |                     **&#39;Select First Record With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **312.0 μs** |  **7.71 μs** | **11.65 μs** |    **6** | **1.0000** |  **10.88 KB** |
| **EFCore** | **&#39;Select First Record With Join Condition With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **335.5 μs** |  **4.36 μs** |  **6.60 μs** |    **7** | **1.5000** |   **13.8 KB** |
| **EFCore** |                          **&#39;Select First Record With Join Condition&#39;** |               **Person** | **229.5 μs** |  **1.20 μs** |  **2.01 μs** |    **2** | **1.0000** |  **10.49 KB** |
| **EFCore** |                     **&#39;Select First Record With Scalar Return Async&#39;** |        **Task&lt;dynamic&gt;** | **310.5 μs** |  **4.89 μs** |  **7.39 μs** |    **6** | **1.0000** |   **9.31 KB** |
| **EFCore** |                           **&#39;Select First Record With Scalar Return&#39;** |                **Int32** | **211.1 μs** |  **2.52 μs** |  **4.81 μs** |    **1** | **0.5000** |   **6.17 KB** |
| **EFCore** |   **&#39;Select First Record With Where Clause With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **322.8 μs** |  **2.68 μs** |  **5.13 μs** |    **7** | **1.5000** |  **13.11 KB** |
| **EFCore** |                            **&#39;Select First Record With Where Clause&#39;** |               **Person** | **219.8 μs** |  **2.33 μs** |  **3.91 μs** |    **1** | **1.0000** |   **9.81 KB** |
| **EFCore** |                                              **&#39;Select First Record&#39;** |               **Person** | **214.0 μs** |  **5.60 μs** |  **8.46 μs** |    **1** | **0.5000** |   **7.58 KB** |


``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1574/21H2/SunValley)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.200
  [Host]   : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  ShortRun : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                  ORM |                                                             Method |               Return |       Mean |    StdDev |     Error | Rank |   Gen0 | Allocated |
|--------------------- |------------------------------------------------------------------- |--------------------- |-----------:|----------:|----------:|-----:|-------:|----------:|
| **EFCore (No Tracking)** |        **&#39;Select First Record With Dynamic Return (aliased columns)&#39;** |              **dynamic** |   **622.4 μs** |  **54.17 μs** |  **81.90 μs** |    **8** | **1.0000** |   **8.23 KB** |
| **EFCore (No Tracking)** |  **&#39;Select First Record With Dynamic Return Async (aliased columns)&#39;** |        **Task&lt;dynamic&gt;** |   **851.2 μs** |  **87.21 μs** | **131.85 μs** |    **9** |      **-** |  **11.46 KB** |
| **EFCore (No Tracking)** |                    **&#39;Select First Record With Dynamic Return Async&#39;** |        **Task&lt;dynamic&gt;** |   **832.2 μs** |  **87.97 μs** | **133.00 μs** |    **9** |      **-** |  **11.57 KB** |
| **EFCore (No Tracking)** |                          **&#39;Select First Record With Dynamic Return&#39;** |              **dynamic** |   **559.2 μs** |  **41.33 μs** |  **62.48 μs** |    **7** | **1.0000** |   **8.19 KB** |
| **EFCore (No Tracking)** |                     **&#39;Select First Record With Entity Return Async&#39;** |         **Task&lt;Person&gt;** |   **851.0 μs** |  **75.07 μs** | **113.49 μs** |    **9** | **1.0000** |  **11.09 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Join Condition With Entity Return Async&#39;** |         **Task&lt;Person&gt;** |   **906.8 μs** | **114.03 μs** | **172.39 μs** |    **9** |      **-** |  **14.02 KB** |
| **EFCore (No Tracking)** |                          **&#39;Select First Record With Join Condition&#39;** |               **Person** |   **257.9 μs** |   **8.96 μs** |  **13.54 μs** |    **2** | **1.0000** |  **10.79 KB** |
| **EFCore (No Tracking)** |                     **&#39;Select First Record With Scalar Return Async&#39;** |        **Task&lt;dynamic&gt;** |   **857.1 μs** |  **91.61 μs** | **138.51 μs** |    **9** |      **-** |   **9.31 KB** |
| **EFCore (No Tracking)** |                           **&#39;Select First Record With Scalar Return&#39;** |                **Int32** |   **622.6 μs** |  **34.51 μs** |  **52.17 μs** |    **8** |      **-** |   **6.17 KB** |
| **EFCore (No Tracking)** |   **&#39;Select First Record With Where Clause With Entity Return Async&#39;** |         **Task&lt;Person&gt;** |   **740.8 μs** |  **38.77 μs** |  **65.14 μs** |    **9** |      **-** |  **13.33 KB** |
| **EFCore (No Tracking)** |                            **&#39;Select First Record With Where Clause&#39;** |               **Person** |   **750.8 μs** |  **70.30 μs** | **106.28 μs** |    **9** | **1.0000** |   **10.1 KB** |
| **EFCore (No Tracking)** |                                              **&#39;Select First Record&#39;** |               **Person** |   **236.4 μs** |   **5.98 μs** |   **9.04 μs** |    **1** | **0.5000** |   **7.87 KB** |


### Dapper (2.0.123)

``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1574/21H2/SunValley)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.200
  [Host]   : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  ShortRun : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|    ORM |                                                       Method |               Return |     Mean |    StdDev |     Error | Rank |   Gen0 | Allocated |
|------- |------------------------------------------------------------- |--------------------- |---------:|----------:|----------:|-----:|-------:|----------:|
| **Dapper** |                                        **&#39;Select First Record&#39;** |               **Person** | **170.6 μs** |   **3.32 μs** |   **5.58 μs** |    **1** | **0.5000** |   **4.66 KB** |
| **Dapper** |         **&#39;Select First With Dynamic Return (aliased columns)&#39;** |              **dynamic** | **172.7 μs** |   **1.47 μs** |   **2.81 μs** |    **1** | **0.2500** |   **3.21 KB** |
| **Dapper** |   **&#39;Select First With Dynamic Return Async (aliased columns)&#39;** |        **Task&lt;dynamic&gt;** | **639.1 μs** |  **49.95 μs** |  **75.52 μs** |   **10** |      **-** |   **4.95 KB** |
| **Dapper** |                     **&#39;Select First With Dynamic Return Async&#39;** |        **Task&lt;dynamic&gt;** | **620.0 μs** |  **49.14 μs** |  **74.29 μs** |   **10** |      **-** |   **3.82 KB** |
| **Dapper** |                           **&#39;Select First With Dynamic Return&#39;** |              **dynamic** | **175.1 μs** |   **3.51 μs** |   **5.30 μs** |    **1** | **0.2500** |   **3.17 KB** |
| **Dapper** |                      **&#39;Select First With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **257.7 μs** |   **3.41 μs** |   **5.15 μs** |    **5** | **0.5000** |   **6.33 KB** |
| **Dapper** |  **&#39;Select First With Join Condition With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **670.1 μs** |  **31.10 μs** |  **47.02 μs** |   **10** | **0.5000** |   **7.47 KB** |
| **Dapper** |                           **&#39;Select First With Join Condition&#39;** |               **Person** | **184.4 μs** |   **3.20 μs** |   **4.84 μs** |    **2** | **0.5000** |    **5.8 KB** |
| **Dapper** |                      **&#39;Select First With Scalar Return Async&#39;** |          **Task&lt;Int32&gt;** | **685.8 μs** |  **38.25 μs** |  **57.83 μs** |   **10** |      **-** |    **4.2 KB** |
| **Dapper** |                            **&#39;Select First With Scalar Return&#39;** |                **Int32** | **172.2 μs** |   **3.19 μs** |   **4.83 μs** |    **1** | **0.2500** |   **2.45 KB** |
| **Dapper** |    **&#39;Select First With Where Clause With Entity Return Async&#39;** |         **Task&lt;Person&gt;** | **666.4 μs** |  **34.63 μs** |  **52.36 μs** |   **10** |      **-** |   **7.42 KB** |
| **Dapper** |                             **&#39;Select First With Where Clause&#39;** |               **Person** | **181.6 μs** |   **3.50 μs** |   **5.30 μs** |    **2** | **0.5000** |   **5.68 KB** |


