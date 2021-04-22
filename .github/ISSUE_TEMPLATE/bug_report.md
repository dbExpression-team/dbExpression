---
name: Bug report
about: Create a report to help us improve
title: "[BUG]"
labels: bug
assignees: ''

---

**1) Describe the issue**

_A clear and concise description of the issue._

**2) What is the issue related to?**

- [ ] Installation
- [ ] Code generation
- [ ] Query execution
- [ ] Documentation
- [ ] Other

**3) What version of Microsoft SQL Server are you experiencing the issue?**

- [ ] 2005
- [ ] 2008
- [ ] 2012
- [ ] 2014
- [ ] 2016
- [ ] 2017
- [ ] 2019
- [ ] Azure
- [ ] *Doesn't matter, happens in All versions*

**4) What, if any, error message are you receiving?**

**5) What QueryExpression are you executing (if applicable)?**

_for example:_

```C#
   db.Select<Person>()
      .From(dbo.Person)
      .Execute()
```
**6) If accessible through a profile tool, what query is executed against the database (if applicable)?**

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

_Add any other context about the issue, for example any startup configuration you have applied to dbExpression and/or the configuration used to generate code._
