![dbExpression](https://dbexpressionpublic.blob.core.windows.net/web/dbex-logo.png)

# Microsoft SQL Server. Simplified.

dbExpression is a Microsoft SQL Server database connector that enables fluent composition and execution of type safe SQL queries directly within compiled code.

**dbExpression supports Microsoft SQL Server versions 2005+.**

The docs can be found at [dbexpression.com/docs](https://dbexpression.com/docs).  

## Build Status

[![Build Status](https://dev.azure.com/dbexpression-team/dbexpression/_apis/build/status/dbexpression-team.dbexpression?branchName=master)](https://dev.azure.com/dbexpression-team/dbexpression/_build/latest?definitionId=2&branchName=main)

Using linux versions of Microsoft SQL Server on Docker images, integration tests are executed against the following versions:

| Platform            	| Status 					|
| :---------------------| :---------------------------------------------|
|	MSSQL 2017	|	[![Build Status](https://dev.azure.com/dbExpression-team/dbexpression/_apis/build/status/dbexpression-team.dbexpression?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=MSSQL2017%20-%20net7)](https://dev.azure.com/dbexpression-team/dbexpression/_build/latest?definitionId=2&branchName=main)	|
|	MSSQL 2019	|	[![Build Status](https://dev.azure.com/dbExpression-team/dbexpression/_apis/build/status/dbexpression-team.dbexpression?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=MSSQL2019%20-%20net7)](https://dev.azure.com/dbexpression-team/dbexpression/_build/latest?definitionId=2&branchName=main)	|
|	MSSQL 2022	|	[![Build Status](https://dev.azure.com/dbExpression-team/dbexpression/_apis/build/status/dbexpression-team.dbexpression?branchName=master&stageName=Test%20MSSQL%20Platforms&jobName=MSSQL2022%20-%20net7)](https://dev.azure.com/dbexpression-team/dbexpression/_build/latest?definitionId=2&branchName=main)	|

## Get dbExpression

| Package            															|  												|
| :-----------------------------------------------------------------------------| :---------------------------------------------------------------------------------------------|
| [DbExpression.MsSql](https://www.nuget.org/packages/DbExpression.MsSql/)		| ![Nuget](https://img.shields.io/nuget/v/DbExpression.MsSql)					|
| [DbExpression.Tools](https://www.nuget.org/packages/DbExpression.Tools/)		| ![Nuget](https://img.shields.io/nuget/v/DbExpression.Tools)					|
| [DbExpression.MsSql.Extensions.DependencyInjection](https://www.nuget.org/packages/DbExpression.MsSql.Extensions.DependencyInjection/)	| ![Nuget](https://img.shields.io/nuget/v/DbExpression.MsSql.Extensions.DependencyInjection)	|
   DbExpression
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
1) [dbExpression Microsoft SQL Server package](https://www.nuget.org/packages/DbExpression.MsSql/)
2) [dbExpression dotnet CLI tool](https://www.nuget.org/packages/DbExpression.Tools/)

Jump to the [docs](https://dbexpression.com/docs) for installation and configuration instructions and how to author and execute beautiful queries.

## Performance

The following shows how we're doing compared to [EF Core](https://github.com/dotnet/efcore) and [Dapper](https://github.com/DapperLib/Dapper).  The benchmarks
used are included in the [Benchmark.MsSql](https://github.com/dbexpression-team/dbexpression/tree/master/benchmark/Benchmark.MsSql) project.

Output from the latest:

``` ini

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22000.2538/21H2/SunValley)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.202
  [Host]   : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| ORM          | Method                                                       | Return               | Mean       | StdDev   | Error    | Rank | Gen0   | Gen1   | Gen2   | Allocated |
|------------- |------------------------------------------------------------- |--------------------- |-----------:|---------:|---------:|-----:|-------:|-------:|-------:|----------:|
| **dbExpression** | **&#39;Select First Record&#39;**                                        | **Person**               |   **434.3 μs** | **25.24 μs** | **38.16 μs** |    **8** | **1.0000** |      **-** |      **-** |   **9.86 KB** |
| **dbExpression** | **&#39;Select First With Dynamic Return (aliased columns)&#39;**         | **dynamic**              |   **231.9 μs** |  **3.31 μs** |  **5.56 μs** |    **1** | **0.5000** |      **-** |      **-** |   **7.05 KB** |
| **dbExpression** | **&#39;Select First With Dynamic Return Async (aliased columns)&#39;**   | **Task&lt;dynamic&gt;**        |   **342.0 μs** |  **1.57 μs** |  **2.64 μs** |    **5** | **1.0000** |      **-** |      **-** |   **9.19 KB** |
| **dbExpression** | **&#39;Select First With Dynamic Return Async&#39;**                     | **Task&lt;dynamic&gt;**        |   **324.6 μs** |  **4.41 μs** |  **7.41 μs** |    **4** | **1.0000** |      **-** |      **-** |   **9.29 KB** |
| **dbExpression** | **&#39;Select First With Dynamic Return&#39;**                           | **dynamic**              |   **273.3 μs** | **10.50 μs** | **15.88 μs** |    **2** | **0.5000** |      **-** |      **-** |   **7.15 KB** |
| **dbExpression** | **&#39;Select First With Entity Return Async&#39;**                      | **Task&lt;Person&gt;**         |   **367.5 μs** |  **4.40 μs** |  **6.66 μs** |    **6** | **1.0000** |      **-** |      **-** |  **12.01 KB** |
| **dbExpression** | **&#39;Select First With Join Condition With Entity Return Async&#39;**  | **Task&lt;Person&gt;**         |   **380.7 μs** | **12.27 μs** | **18.55 μs** |    **7** | **1.0000** |      **-** |      **-** |   **12.5 KB** |
| **dbExpression** | **&#39;Select First With Join Condition&#39;**                           | **Person**               |   **491.4 μs** | **30.05 μs** | **45.43 μs** |    **8** | **1.0000** |      **-** |      **-** |  **10.35 KB** |
| **dbExpression** | **&#39;Select First With Scalar Return Async&#39;**                      | **Task&lt;Int32&gt;**          |   **307.2 μs** | **10.38 μs** | **15.69 μs** |    **3** | **0.5000** |      **-** |      **-** |   **6.56 KB** |
| **dbExpression** | **&#39;Select First With Scalar Return&#39;**                            | **Int32**                |   **299.9 μs** |  **9.38 μs** | **14.18 μs** |    **3** | **0.5000** |      **-** |      **-** |   **4.51 KB** |
| **dbExpression** | **&#39;Select First With Where Clause With Entity Return Async&#39;**    | **Task&lt;Person&gt;**         |   **366.2 μs** |  **6.00 μs** | **11.48 μs** |    **6** | **1.0000** |      **-** |      **-** |  **13.53 KB** |
| **dbExpression** | **&#39;Select First With Where Clause&#39;**                             | **Person**               |   **458.2 μs** | **32.11 μs** | **48.55 μs** |    **8** | **1.0000** |      **-** |      **-** |  **11.38 KB** |
| **dbExpression** | **&#39;Select Top 50 With Dynamic Return (aliased columns)&#39;**        | **IList&lt;dynamic&gt;**       |   **324.8 μs** |  **6.00 μs** |  **9.08 μs** |    **4** | **4.0000** | **1.5000** | **0.5000** |  **31.39 KB** |
| **dbExpression** | **&#39;Select Top 50 With Dynamic Return Async (aliased columns)&#39;**  | **Task&lt;IList&lt;dynamic&gt;&gt;** |   **494.0 μs** | **20.54 μs** | **31.05 μs** |    **8** | **4.0000** | **1.0000** |      **-** |  **37.66 KB** |
| **dbExpression** | **&#39;Select Top 50 With Dynamic Return Async&#39;**                    | **Task&lt;IList&lt;dynamic&gt;&gt;** |   **469.2 μs** |  **8.81 μs** | **13.31 μs** |    **8** | **4.0000** | **1.0000** |      **-** |  **37.75 KB** |
| **dbExpression** | **&#39;Select Top 50 With Dynamic Return&#39;**                          | **IList&lt;dynamic&gt;**       |   **320.7 μs** |  **5.53 μs** |  **9.29 μs** |    **4** | **4.0000** | **1.5000** | **0.5000** |  **31.49 KB** |
| **dbExpression** | **&#39;Select Top 50 With Entity Return Async&#39;**                     | **Task&lt;IList&lt;Person&gt;&gt;**  |   **523.4 μs** | **14.83 μs** | **22.42 μs** |    **9** | **6.0000** |      **-** |      **-** |  **62.52 KB** |
| **dbExpression** | **&#39;Select Top 50 With Join Condition With Entity Return Async&#39;** | **Task&lt;IList&lt;Person&gt;&gt;**  | **1,366.6 μs** | **11.24 μs** | **16.99 μs** |   **12** | **8.0000** | **2.0000** |      **-** |  **65.52 KB** |
| **dbExpression** | **&#39;Select Top 50 With Join Condition&#39;**                          | **IList&lt;Person&gt;**        | **1,200.0 μs** | **16.05 μs** | **24.26 μs** |   **11** | **6.0000** |      **-** |      **-** |  **59.13 KB** |
| **dbExpression** | **&#39;Select Top 50 With Scalar Return Async&#39;**                     | **Task&lt;IList&lt;Int32&gt;&gt;**   |   **359.9 μs** |  **9.97 μs** | **15.07 μs** |    **6** | **1.0000** |      **-** |      **-** |  **15.14 KB** |
| **dbExpression** | **&#39;Select Top 50 With Scalar Return&#39;**                           | **IList&lt;Int32&gt;**         |   **230.2 μs** |  **8.51 μs** | **16.26 μs** |    **1** | **1.0000** |      **-** |      **-** |   **9.06 KB** |
| **dbExpression** | **&#39;Select Top 50 With Where Clause With Entity Return Async&#39;**   | **Task&lt;IList&lt;Person&gt;&gt;**  |   **578.5 μs** | **40.40 μs** | **61.08 μs** |   **10** | **6.0000** |      **-** |      **-** |  **64.04 KB** |
| **dbExpression** | **&#39;Select Top 50 With Where Clause&#39;**                            | **IList&lt;Person&gt;**        |   **420.3 μs** |  **8.78 μs** | **13.28 μs** |    **8** | **7.0000** | **1.5000** | **0.5000** |  **57.86 KB** |
| **dbExpression** | **&#39;Select Top 50&#39;**                                              | **IList&lt;Person&gt;**        |   **439.1 μs** | **11.19 μs** | **16.92 μs** |    **8** | **6.5000** | **1.0000** | **0.5000** |  **56.34 KB** |



### EF Core (8.0.3)

``` ini

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22000.2538/21H2/SunValley)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.202
  [Host]   : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| ORM    | Method                                                             | Return               | Mean       | StdDev    | Error     | Rank | Gen0   | Gen1   | Allocated |
|------- |------------------------------------------------------------------- |--------------------- |-----------:|----------:|----------:|-----:|-------:|-------:|----------:|
| **EFCore** | **&#39;Select First Record With Dynamic Return (aliased columns)&#39;**        | **dynamic**              |   **419.9 μs** |   **6.51 μs** |  **10.93 μs** |    **5** | **1.0000** |      **-** |   **8.31 KB** |
| **EFCore** | **&#39;Select First Record With Dynamic Return Async (aliased columns)&#39;**  | **Task&lt;dynamic&gt;**        |   **430.8 μs** |  **69.79 μs** | **105.51 μs** |    **5** | **1.0000** |      **-** |  **11.36 KB** |
| **EFCore** | **&#39;Select First Record With Dynamic Return Async&#39;**                    | **Task&lt;dynamic&gt;**        |   **386.7 μs** |  **10.61 μs** |  **20.29 μs** |    **3** | **1.0000** |      **-** |  **11.48 KB** |
| **EFCore** | **&#39;Select First Record With Dynamic Return&#39;**                          | **dynamic**              |   **446.9 μs** |  **20.28 μs** |  **34.08 μs** |    **5** | **1.0000** |      **-** |   **8.28 KB** |
| **EFCore** | **&#39;Select First Record With Entity Return Async&#39;**                     | **Task&lt;Person&gt;**         |   **461.4 μs** |  **14.14 μs** |  **23.77 μs** |    **5** | **1.0000** |      **-** |  **10.74 KB** |
| **EFCore** | **&#39;Select First Record With Join Condition With Entity Return Async&#39;** | **Task&lt;Person&gt;**         |   **486.7 μs** |  **47.11 μs** |  **71.23 μs** |    **5** | **1.0000** |      **-** |  **13.66 KB** |
| **EFCore** | **&#39;Select First Record With Join Condition&#39;**                          | **Person**               |   **602.6 μs** |  **18.53 μs** |  **28.02 μs** |    **7** | **1.0000** |      **-** |  **10.53 KB** |
| **EFCore** | **&#39;Select First Record With Scalar Return Async&#39;**                     | **Task&lt;dynamic&gt;**        |   **381.1 μs** |  **38.69 μs** |  **65.02 μs** |    **3** | **1.0000** |      **-** |   **9.52 KB** |
| **EFCore** | **&#39;Select First Record With Scalar Return&#39;**                           | **Int32**                |   **447.0 μs** |  **21.15 μs** |  **35.55 μs** |    **5** |      **-** |      **-** |   **6.25 KB** |
| **EFCore** | **&#39;Select First Record With Where Clause With Entity Return Async&#39;**   | **Task&lt;Person&gt;**         |   **414.6 μs** |  **33.90 μs** |  **56.96 μs** |    **4** | **1.0000** |      **-** |  **13.04 KB** |
| **EFCore** | **&#39;Select First Record With Where Clause&#39;**                            | **Person**               |   **508.5 μs** |  **27.87 μs** |  **42.14 μs** |    **5** | **1.0000** |      **-** |   **9.92 KB** |
| **EFCore** | **&#39;Select First Record&#39;**                                              | **Person**               |   **454.9 μs** |  **18.62 μs** |  **28.16 μs** |    **5** |      **-** |      **-** |   **7.63 KB** |
| **EFCore** | **&#39;Select Top 50 With Dynamic Return (aliased columns)&#39;**              | **IList&lt;dynamic&gt;**       |   **356.0 μs** |   **6.62 μs** |  **12.66 μs** |    **3** | **3.0000** | **1.0000** |  **30.27 KB** |
| **EFCore** | **&#39;Select Top 50 With Dynamic Return Async (aliased columns)&#39;**        | **Task&lt;List&lt;dynamic&gt;&gt;**  |   **741.2 μs** | **184.03 μs** | **278.23 μs** |    **7** | **4.0000** |      **-** |  **33.24 KB** |
| **EFCore** | **&#39;Select Top 50 With Dynamic Return Async&#39;**                          | **Task&lt;IList&lt;dynamic&gt;&gt;** |   **552.7 μs** |  **17.33 μs** |  **33.13 μs** |    **6** | **4.0000** | **1.0000** |  **32.61 KB** |
| **EFCore** | **&#39;Select Top 50 With Dynamic Return&#39;**                                | **IList&lt;dynamic&gt;**       |   **349.6 μs** |   **6.67 μs** |  **12.76 μs** |    **3** | **3.0000** | **1.0000** |  **29.64 KB** |
| **EFCore** | **&#39;Select Top 50 With Entity Return Async&#39;**                           | **Task&lt;IList&lt;Person&gt;&gt;**  |   **475.5 μs** |  **21.60 μs** |  **36.29 μs** |    **5** | **4.0000** |      **-** |  **33.84 KB** |
| **EFCore** | **&#39;Select Top 50 With Join Condition With Entity Return Async&#39;**       | **Task&lt;IList&lt;Person&gt;&gt;**  | **1,263.3 μs** |  **30.30 μs** |  **50.92 μs** |    **9** | **4.0000** |      **-** |  **42.86 KB** |
| **EFCore** | **&#39;Select Top 50 With Join Condition&#39;**                                | **IList&lt;Person&gt;**        | **1,079.9 μs** |  **23.52 μs** |  **35.56 μs** |    **8** | **4.0000** |      **-** |  **36.15 KB** |
| **EFCore** | **&#39;Select Top 50 With Scalar Return Async&#39;**                           | **Task&lt;IList&lt;Int32&gt;&gt;**   |   **433.8 μs** |  **11.74 μs** |  **22.45 μs** |    **5** | **2.0000** |      **-** |  **24.22 KB** |
| **EFCore** | **&#39;Select Top 50 With Scalar Return&#39;**                                 | **IList&lt;Int32&gt;**         |   **294.6 μs** |   **5.59 μs** |   **8.45 μs** |    **2** | **2.5000** |      **-** |  **20.63 KB** |
| **EFCore** | **&#39;Select Top 50 With Where Clause With Entity Return Async&#39;**         | **Task&lt;IList&lt;Person&gt;&gt;**  |   **432.9 μs** |  **13.96 μs** |  **26.70 μs** |    **5** | **2.0000** |      **-** |  **22.24 KB** |
| **EFCore** | **&#39;Select Top 50 With Where Clause&#39;**                                  | **IList&lt;Person&gt;**        |   **285.3 μs** |   **5.32 μs** |   **8.05 μs** |    **1** | **2.0000** |      **-** |   **19.1 KB** |
| **EFCore** | **&#39;Select Top 50&#39;**                                                    | **IList&lt;Person&gt;**        |   **348.2 μs** |  **10.33 μs** |  **17.36 μs** |    **3** | **3.0000** |      **-** |  **27.17 KB** |


``` ini

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22000.2538/21H2/SunValley)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.202
  [Host]   : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| ORM                  | Method                                                             | Return               | Mean       | StdDev    | Error     | Rank | Gen0   | Gen1   | Allocated |
|--------------------- |------------------------------------------------------------------- |--------------------- |-----------:|----------:|----------:|-----:|-------:|-------:|----------:|
| **EFCore (No Tracking)** | **&#39;Select First Record With Dynamic Return (aliased columns)&#39;**        | **dynamic**              |   **345.3 μs** |   **7.34 μs** |  **14.03 μs** |    **3** | **1.0000** |      **-** |   **8.31 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Dynamic Return Async (aliased columns)&#39;**  | **Task&lt;dynamic&gt;**        |   **469.9 μs** |  **38.20 μs** |  **64.19 μs** |    **6** | **1.0000** |      **-** |  **11.36 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Dynamic Return Async&#39;**                    | **Task&lt;dynamic&gt;**        |   **466.6 μs** |  **15.21 μs** |  **29.08 μs** |    **6** | **1.0000** |      **-** |  **11.32 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Dynamic Return&#39;**                          | **dynamic**              |   **373.1 μs** |  **12.89 μs** |  **24.64 μs** |    **4** | **1.0000** |      **-** |   **8.28 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Entity Return Async&#39;**                     | **Task&lt;Person&gt;**         |   **449.0 μs** |  **28.66 μs** |  **43.33 μs** |    **6** | **1.0000** |      **-** |  **10.96 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Join Condition With Entity Return Async&#39;** | **Task&lt;Person&gt;**         |   **478.9 μs** |  **34.20 μs** |  **51.71 μs** |    **6** | **1.0000** |      **-** |  **14.02 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Join Condition&#39;**                          | **Person**               |   **422.8 μs** |  **18.13 μs** |  **30.47 μs** |    **6** | **1.0000** |      **-** |  **10.83 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Scalar Return Async&#39;**                     | **Task&lt;dynamic&gt;**        |   **425.2 μs** |   **9.27 μs** |  **17.72 μs** |    **6** | **1.0000** |      **-** |   **9.22 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Scalar Return&#39;**                           | **Int32**                |   **364.8 μs** |  **15.93 μs** |  **26.76 μs** |    **4** |      **-** |      **-** |   **6.25 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Where Clause With Entity Return Async&#39;**   | **Task&lt;Person&gt;**         |   **444.6 μs** |  **28.83 μs** |  **55.12 μs** |    **6** | **1.0000** |      **-** |  **13.26 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record With Where Clause&#39;**                            | **Person**               |   **385.0 μs** |   **5.76 μs** |  **11.01 μs** |    **5** | **1.0000** |      **-** |  **10.32 KB** |
| **EFCore (No Tracking)** | **&#39;Select First Record&#39;**                                              | **Person**               |   **281.2 μs** |  **16.36 μs** |  **24.73 μs** |    **1** | **0.5000** |      **-** |   **7.92 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Dynamic Return (aliased columns)&#39;**              | **IList&lt;dynamic&gt;**       |   **373.2 μs** |  **32.86 μs** |  **55.21 μs** |    **4** | **3.0000** | **1.0000** |  **30.27 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Dynamic Return Async (aliased columns)&#39;**        | **Task&lt;List&lt;dynamic&gt;&gt;**  |   **517.3 μs** |  **18.63 μs** |  **35.62 μs** |    **6** | **4.0000** | **1.0000** |  **33.24 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Dynamic Return Async&#39;**                          | **Task&lt;IList&lt;dynamic&gt;&gt;** |   **501.0 μs** |   **6.18 μs** |  **11.81 μs** |    **6** | **4.0000** | **1.0000** |  **32.61 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Dynamic Return&#39;**                                | **IList&lt;dynamic&gt;**       |   **368.0 μs** |   **3.97 μs** |   **7.59 μs** |    **4** | **3.0000** | **1.0000** |  **29.64 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Entity Return Async&#39;**                           | **Task&lt;IList&lt;Person&gt;&gt;**  |   **613.6 μs** | **111.38 μs** | **168.39 μs** |    **7** | **4.0000** |      **-** |  **44.78 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Join Condition With Entity Return Async&#39;**       | **Task&lt;IList&lt;Person&gt;&gt;**  | **1,397.4 μs** |  **24.94 μs** |  **41.91 μs** |    **9** | **6.0000** | **2.0000** |  **53.65 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Join Condition&#39;**                                | **IList&lt;Person&gt;**        | **1,241.1 μs** |  **27.99 μs** |  **47.04 μs** |    **8** | **6.0000** | **2.0000** |  **50.68 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Scalar Return Async&#39;**                           | **Task&lt;IList&lt;Int32&gt;&gt;**   |   **455.6 μs** |   **7.99 μs** |  **15.28 μs** |    **6** | **2.0000** |      **-** |  **24.22 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Scalar Return&#39;**                                 | **IList&lt;Int32&gt;**         |   **339.9 μs** |  **31.33 μs** |  **52.64 μs** |    **2** | **2.0000** |      **-** |  **20.63 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Where Clause With Entity Return Async&#39;**         | **Task&lt;IList&lt;Person&gt;&gt;**  |   **454.8 μs** |   **9.65 μs** |  **18.45 μs** |    **6** | **2.0000** |      **-** |  **22.46 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50 With Where Clause&#39;**                                  | **IList&lt;Person&gt;**        |   **336.1 μs** |  **41.18 μs** |  **69.20 μs** |    **2** | **2.0000** |      **-** |  **19.39 KB** |
| **EFCore (No Tracking)** | **&#39;Select Top 50&#39;**                                                    | **IList&lt;Person&gt;**        |   **498.3 μs** |  **30.70 μs** |  **46.42 μs** |    **6** | **5.0000** | **1.0000** |  **41.71 KB** |



### Dapper (2.1.35)

``` ini

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22000.2538/21H2/SunValley)
Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.202
  [Host]   : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| ORM    | Method                                                       | Return               | Mean     | StdDev   | Error    | Rank | Gen0   | Gen1   | Gen2   | Allocated |
|------- |------------------------------------------------------------- |--------------------- |---------:|---------:|---------:|-----:|-------:|-------:|-------:|----------:|
| **Dapper** | **&#39;Select First Record&#39;**                                        | **Person**               | **287.9 μs** |  **5.29 μs** |  **8.88 μs** |    **6** | **0.5000** |      **-** |      **-** |   **4.63 KB** |
| **Dapper** | **&#39;Select First With Dynamic Return (aliased columns)&#39;**         | **dynamic**              | **172.0 μs** |  **4.18 μs** |  **7.03 μs** |    **1** | **0.2500** |      **-** |      **-** |   **3.13 KB** |
| **Dapper** | **&#39;Select First With Dynamic Return Async (aliased columns)&#39;**   | **Task&lt;dynamic&gt;**        | **274.2 μs** |  **1.69 μs** |  **3.24 μs** |    **5** | **0.5000** |      **-** |      **-** |   **4.81 KB** |
| **Dapper** | **&#39;Select First With Dynamic Return Async&#39;**                     | **Task&lt;dynamic&gt;**        | **260.9 μs** |  **2.56 μs** |  **3.87 μs** |    **4** |      **-** |      **-** |      **-** |   **3.74 KB** |
| **Dapper** | **&#39;Select First With Dynamic Return&#39;**                           | **dynamic**              | **169.4 μs** |  **1.27 μs** |  **2.13 μs** |    **1** | **0.2500** |      **-** |      **-** |   **3.09 KB** |
| **Dapper** | **&#39;Select First With Entity Return Async&#39;**                      | **Task&lt;Person&gt;**         | **251.0 μs** |  **8.43 μs** | **14.16 μs** |    **3** | **0.5000** |      **-** |      **-** |   **6.24 KB** |
| **Dapper** | **&#39;Select First With Join Condition With Entity Return Async&#39;**  | **Task&lt;Person&gt;**         | **264.6 μs** |  **4.12 μs** |  **6.23 μs** |    **4** | **0.5000** |      **-** |      **-** |   **7.38 KB** |
| **Dapper** | **&#39;Select First With Join Condition&#39;**                           | **Person**               | **298.4 μs** | **10.50 μs** | **15.87 μs** |    **7** | **0.5000** |      **-** |      **-** |   **5.77 KB** |
| **Dapper** | **&#39;Select First With Scalar Return Async&#39;**                      | **Task&lt;Int32&gt;**          | **247.2 μs** |  **3.57 μs** |  **5.39 μs** |    **3** |      **-** |      **-** |      **-** |   **4.05 KB** |
| **Dapper** | **&#39;Select First With Scalar Return&#39;**                            | **Int32**                | **178.0 μs** |  **5.39 μs** |  **8.15 μs** |    **1** | **0.2500** |      **-** |      **-** |   **2.37 KB** |
| **Dapper** | **&#39;Select First With Where Clause With Entity Return Async&#39;**    | **Task&lt;Person&gt;**         | **259.0 μs** |  **4.19 μs** |  **7.04 μs** |    **4** | **0.5000** |      **-** |      **-** |   **7.27 KB** |
| **Dapper** | **&#39;Select First With Where Clause&#39;**                             | **Person**               | **223.1 μs** | **12.99 μs** | **19.64 μs** |    **2** | **0.5000** |      **-** |      **-** |   **5.59 KB** |
| **Dapper** | **&#39;Select Top 50 With Dynamic Return (aliased columns)&#39;**        | **IList&lt;dynamic&gt;**       | **246.7 μs** |  **4.95 μs** |  **7.49 μs** |    **3** | **1.5000** | **1.2500** |      **-** |  **13.12 KB** |
| **Dapper** | **&#39;Select Top 50 With Dynamic Return Async (aliased columns)&#39;**  | **Task&lt;IList&lt;dynamic&gt;&gt;** | **346.8 μs** |  **7.33 μs** | **11.08 μs** |   **10** | **1.5000** | **1.0000** |      **-** |   **14.8 KB** |
| **Dapper** | **&#39;Select Top 50 With Dynamic Return Async&#39;**                    | **Task&lt;IList&lt;dynamic&gt;&gt;** | **346.3 μs** |  **3.86 μs** |  **5.84 μs** |   **10** | **1.5000** | **1.0000** |      **-** |  **13.73 KB** |
| **Dapper** | **&#39;Select Top 50 With Dynamic Return&#39;**                          | **IList&lt;dynamic&gt;**       | **249.1 μs** |  **2.34 μs** |  **4.48 μs** |    **3** | **1.5000** | **1.0000** |      **-** |  **13.08 KB** |
| **Dapper** | **&#39;Select Top 50 With Entity Return Async&#39;**                     | **Task&lt;IList&lt;Person&gt;&gt;**  | **376.4 μs** |  **6.57 μs** |  **9.93 μs** |   **11** | **3.0000** | **1.0000** |      **-** |  **26.48 KB** |
| **Dapper** | **&#39;Select Top 50 With Join Condition With Entity Return Async&#39;** | **Task&lt;IList&lt;Person&gt;&gt;**  | **432.3 μs** |  **8.47 μs** | **12.80 μs** |   **12** | **3.0000** | **1.0000** |      **-** |  **29.12 KB** |
| **Dapper** | **&#39;Select Top 50 With Join Condition&#39;**                          | **IList&lt;Person&gt;**        | **339.4 μs** |  **3.09 μs** |  **5.20 μs** |    **9** | **3.0000** | **1.0000** | **0.5000** |   **27.5 KB** |
| **Dapper** | **&#39;Select Top 50 With Scalar Return Async&#39;**                     | **Task&lt;IList&lt;Int32&gt;&gt;**   | **309.6 μs** |  **3.60 μs** |  **5.45 μs** |    **8** | **0.5000** |      **-** |      **-** |   **6.02 KB** |
| **Dapper** | **&#39;Select Top 50 With Scalar Return&#39;**                           | **IList&lt;Int32&gt;**         | **223.5 μs** |  **4.20 μs** |  **6.34 μs** |    **2** | **0.5000** |      **-** |      **-** |   **4.33 KB** |
| **Dapper** | **&#39;Select Top 50 With Where Clause With Entity Return Async&#39;**   | **Task&lt;IList&lt;Person&gt;&gt;**  | **379.3 μs** |  **5.52 μs** |  **8.34 μs** |   **11** | **3.0000** | **1.0000** |      **-** |  **27.51 KB** |
| **Dapper** | **&#39;Select Top 50 With Where Clause&#39;**                            | **IList&lt;Person&gt;**        | **299.0 μs** |  **2.81 μs** |  **4.72 μs** |    **7** | **3.0000** | **1.5000** | **0.5000** |  **25.83 KB** |
| **Dapper** | **&#39;Select Top 50&#39;**                                              | **IList&lt;Person&gt;**        | **287.6 μs** |  **3.32 μs** |  **5.02 μs** |    **6** | **3.0000** | **1.0000** | **0.5000** |  **24.86 KB** |
