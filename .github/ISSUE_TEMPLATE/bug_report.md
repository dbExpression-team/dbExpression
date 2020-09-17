---
name: Bug report
about: Create a report to help us improve
title: "[BUG]"
labels: bug
assignees: ''

---

**1) Describe the bug**

_A clear and concise description of the issue._

**2) Is the issue with query execution or code generation?**

- [ ] Query execution
- [ ] Code generation

**3) What platform are you working against?**

- [ ] Microsoft SQL Server version 2005
- [ ] Microsoft SQL Server version 2008
- [ ] Microsoft SQL Server version 2012
- [ ] Microsoft SQL Server version 2014
- [ ] Microsoft SQL Server version 2016
- [ ] Microsoft SQL Server version 2017
- [ ] Microsoft SQL Server version 2019
- [ ] Microsoft Azure Sql Database

**4) What, if any, error message are you receiving?**

**5) What query are you executing (if applicable)?**

_for example:_

```C#
   db.Select<Person>()
      .From(dbo.Person)
      .Execute()
```
**6) If accessible through a profile tool, what query is executing against the database platform? (if applicable)**

_for example:_

```TSQL
   SELECT
      [dbo].[Person].[FirstName],
      [dbo].[Person].[LastName]
   FROM
      [dbo].[Person]
```

**7) Screenshots**

_If applicable, add screenshots to help explain the issue._

**8) Additional context**

_Add any other context about the problem here, for example any startup configuration you have applied to DbExpression and/or the configuration used to generate code._
