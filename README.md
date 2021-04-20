<img src="https://dbexpressionpublic.blob.core.windows.net/web/dbex-logo.png" alt="dbExpression" width="200"/>

dbExpression is a Microsoft SQL Server database connector that enables fluent composition and execution of type safe SQL queries directly within compiled code.

## Build Status

[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=release%2F0.7)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=release%2F0.7)

| Platform            		| Status 					|
| :---            			| :---    					|
|	MSSQL 2017				|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=release%2F0.7&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202017)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=release%2F0.7)	|
|	MSSQL 2019				|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=release%2F0.7&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202019)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=release%2F0.7)	|

## Why dbExpression?
dbExpression was created to close the gap between application code and raw SQL, bringing Microsoft SQL Server functionality into .NET.  dbExpression isn't centered around object relational mapping (ORM) concepts, but instead focuses on allowing you to write powerful type-checked SQL queries comparable to queries written directly in TSQL.

* **Extensible by design**
* Fluently build queries with a clear focus on **WYSIWYG**
* **Compile-time checking** of SQL queries
* Build queries **without magic strings** or string interpolation
* Tooling to easily keep **application code in sync with database schema**
* **ORM features without the ORM handcuffs**

With dbExpression, the code that handles the basics of pushing and pulling data in and out of your target database is generated via a CLI tool.  The code contains all of the classes and functional plumbing necessary to insert, update, delete and query your data with expressions that live directly within your application code.  When you modify your database in any way, regenerating the code exposes those changes to your application, keeping schema changes in sync with your application code.

With dbExpression, you can easily write queries like this:
```c#
dynamic purchases_shipped_by_year = await db.SelectMany(
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
Which look like this when executed using dbExpression:
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
- - -

### Using dbExpression
dbExpression is quick and easy to get up and running using two packages available on NuGet:
1) [dbExpression Microsoft SQL Server package](https://www.nuget.org/profiles/HatTrickLabs)
2) [dbExpression dotnet CLI tool](https://www.nuget.org/profiles/HatTrickLabs)

Jump to the [docs](https://github.com/HatTrickLabs/db-ex/wiki) for installation and configuration instructions and how to author and execute beautiful queries.
