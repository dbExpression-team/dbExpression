---
name: Bug report
about: Create a report to help us improve
title: "[BUG]"
labels: bug
assignees: ''

---

**Describe the bug**
A clear and concise description of what the bug is.

**Is the issue with query execution or code generation?**

- [ ] Code generation
- [ ] Query execution

**What platform are you working against?**

- [ ] Microsoft SQL Server version 2005
- [ ] Microsoft SQL Server version 2008
- [ ] Microsoft SQL Server version 2012
- [ ] Microsoft SQL Server version 2014
- [ ] Microsoft SQL Server version 2016
- [ ] Microsoft SQL Server version 2017
- [ ] Microsoft SQL Server version 2019
- [ ] Microsoft Azure Sql Database

**What query are you executing?**
ex: 
```C#
   db.Select<Person>()
      .From(dbo.Person)
      .Execute()
```
**What, if any, error message are you receiving?**

**If accessible through a profile tool, what query is executing against the database platform?**
ex:
```TSQL
   SELECT
      [dbo].[Person].[FirstName],
      [dbo].[Person].[LastName]
   FROM
      [dbo].[Person]
```
**Screenshots**
If applicable, add screenshots to help explain your problem.

**Additional context**
Add any other context about the problem here, for example any configuration you have applied to DbExpression.
