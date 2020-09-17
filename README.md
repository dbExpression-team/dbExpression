# dbExpression

dbExpression is a lightweight framework for fluently building and executing strongly-typed statements against target platforms, generally relational database platforms like Microsoft Sql Server.
 While other frameworks typically use LINQ where statements written in code resemble the authoring language (C#/VB, etc), expressions written with dbExpression take a completely different approach, where the authored statement in code looks like the target platform's native language.  In the case of Microsoft Sql Server, expressions written using dbExpression _look like TSQL_.

**The primary goal of dbExpression is to provide a strongly-typed representation of your target platform, and get out of the way and let you write code.**

## Features
- Write SQL statements in code exactly as you would write them in a query tool
- Net Standard 2.0, runs on Windows and Linux
- Your database schema in compiled code using fast and simple scaffolding via code generation.
- Supports numerous native database functions, from average, population standard deviation, cast, isnull, and many more!
- Configure dbExpression to produce exactly what you need
    - Have a legacy database that stores integers in a char field?  No problem, simply configure that field to be an integer and dbExpression will take care of the rest.
    - Want to store enums as strings? No problem, provide simple configuration for database fields.
- Extremely extensible.  Don't like the way we handle something?  Simply plug-in your own implementation, configure it, and we'll use it!
- And much, much more!


Using dbExpression, you can write simple statements returning entities:
```C#
    var personId = 12;

    Person person = db.SelectOne<Person>()
        .From(dbo.Person)
        .Where(dbo.Person.Id == personId)
        .Execute();

    Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Id} was born on {person.BirthDate.HasValue ? person.BirthDate.ToShortDateString() : "[unknown]"}."); 
    
    /*
    Output:
    Joe Smith (12) was born on 3/1/1970.
    */
```

Or more complex statements returning only the fields you need:

```C#
    int year = 2017;
    int purchaseCount = 3;  //any person making 3 or more purchases in a calendar year are considered VIP customers

    var vipStatistics = await db.SelectMany(
        db.fx.Count(dbo.Purchase.PurchaseDate).As("PurchaseCount"),
        dbo.Person.Id,
        (dbo.Person.FirstName + " " + dbo.Person.LastName).As("FullName"),
        db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("PurchaseYear")
    )
    .From(dbo.Purchase)
    .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
    .OrderBy(
        db.fx.Count(dbo.Purchase.PurchaseDate).Desc
    )
    .GroupBy(
        dbo.Person.Id,
        (dbo.Person.FirstName + " " + dbo.Person.LastName),
        db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
    )
    .Having(
        db.fx.Count(dbo.Purchase.PurchaseDate) >= purchaseCount
        & db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) == year
    )
    .ExecuteAsync();

    foreach (var vip in vipStatistics)
    {
        Console.WriteLine($"{vip.FullName} ({vip.Id}) has made {vip.PurchaseCount} purchases in {vip.PurchaseYear}.");
    }

    /*
    Output:
    Jane Doe (23) has made 8 purchases in 2017.
    Joe Smith (12) has made 6 purchases in 2017.
    Danny O'Connor (8) has made 4 purchases in 2017.
    */
```
The sql statement executed agains Microsoft Sql Server:

```SQL
exec sp_executesql N'SELECT
	COUNT([dbo].[Purchase].[PurchaseDate]) AS [PurchaseCount],
	[dbo].[Person].[Id],
	(([dbo].[Person].[FirstName] + @P1) + [dbo].[Person].[LastName]) AS [FullName],
	DATEPART(year, [dbo].[Purchase].[PurchaseDate]) AS [PurchaseYear]
FROM
	[dbo].[Purchase]
	INNER JOIN [dbo].[Person] ON [dbo].[Purchase].[PersonId] = [dbo].[Person].[Id]
GROUP BY
	[dbo].[Person].[Id],
	(([dbo].[Person].[FirstName] + @P1) + [dbo].[Person].[LastName]),
	DATEPART(year, [dbo].[Purchase].[PurchaseDate])
HAVING
	(COUNT([dbo].[Purchase].[PurchaseDate]) >= @P2 AND DATEPART(year, [dbo].[Purchase].[PurchaseDate]) = @P3)
ORDER BY
	COUNT([dbo].[Purchase].[PurchaseDate]) DESC
;',N'@P1 varchar(1),@P2 int,@P3 int',@P1=' ',@P2=3,@P3=2017
```

## Target Platforms
Currently, dbExpression supports the following versions of Microsoft Sql Server:
- Microsoft Sql Server, versions 2005-2019
- Micrsoft Azure Sql Db, all versions

 dbExpression is built from the ground up as a DSL over Microsoft Sql Server, eliminating the [object-relational impedance mismatch](https://en.wikipedia.org/wiki/Object-relational_impedance_mismatch)
 that has inherent confusion in code written using LINQ, sent into some ORM black box, and somehow magically translated to SQL.  It overcomes the "How did it interpret I wanted to do that from what I wrote?!!"

## Build Status

[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=release%2F1.0)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=release%2F1.0)

dbExpression uses Docker images containing native platforms (i.e. Microsoft Sql Server on Linux).  We run a full suite of integration tests against all of the following:

| Platform            		| Status 					|
| :---            			| :---    					|
|	MSSQL 2017				|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=release%2F1.0&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202017)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=release%2F1.0)	|
|	MSSQL 2019				|	[![Build Status](https://dev.azure.com/hattricklabs/DbEx/_apis/build/status/HatTrickLabs.db-ex?branchName=release%2F1.0&stageName=Test%20MSSQL%20Platforms&jobName=Test%20MSSQL%202019)](https://dev.azure.com/hattricklabs/DbEx/_build/latest?definitionId=2&branchName=release%2F1.0)	|

## Getting Started

Getting started is simple, follow these steps and be up and running in 10 minutes!
<details>
<summary>
Install the db-ex command line tool
</summary>
<p>
//TODO: JROD

Useful links:

https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools
</p>
</details>
<details>
<summary>
Reference the dbExpression NuGet package in your project
</summary>
//TODO: Gary
</details>
<details>
<summary>
Point the tool at your database and generate your database into C#
</summary>
//TODO: Gary
</details>
<details>
<summary>
Configure dbExpression, typically in Startup.cs
</summary>
//TODO: Gary
</details>
<details>
<summary>
Write and execute queries!
</summary>
//TODO: JROD, lots of samples
</details>

Also, check out our sample projects in this repository under the 'samples' directory.  These are the best way to learn hands-on how to use dbExpression.





