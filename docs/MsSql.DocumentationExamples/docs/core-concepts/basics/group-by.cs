using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Basics
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/group-by</summary>
    public class Group_By : IDocumentationExamples
    {
        private readonly ILogger<Group_By> logger;

        public Group_By(ILogger<Group_By> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Group_By_line_no_12();
            Group_By_line_no_34();
            Group_By_line_no_71();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/group-by at line 12</summary>
        private void Group_By_line_no_12()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/group-by at line 12");

            IEnumerable<dynamic> counts = db.SelectMany(
                    dbo.Person.LastName,
                    db.fx.Count(dbo.Person.LastName).As("LastNameCount")
                )
                .From(dbo.Person)
                .GroupBy(dbo.Person.LastName)
                .Execute();

            /*
            SELECT
            	[dbo].[Person].[LastName],
            	COUNT([dbo].[Person].[LastName]) AS [LastNameCount]
            FROM
            	[dbo].[Person]
            GROUP BY
            	[dbo].[Person].[LastName];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/group-by at line 34</summary>
        private void Group_By_line_no_34()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/group-by at line 34");

            IEnumerable<dynamic> persons = db.SelectMany(
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    db.fx.Count(dbo.PersonAddress.Id).As("Count")
                )
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .GroupBy(
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                ).OrderBy(
                    dbo.Person.LastName,
                    dbo.Person.FirstName.Desc()
                )
                .Execute();

            /*
            SELECT
            	[dbo].[Person].[FirstName],
            	[dbo].[Person].[LastName],
            	COUNT([dbo].[Person_Address].[Id]) AS [Count]
            FROM
            	[dbo].[Person]
            	INNER JOIN [dbo].[Person_Address] ON [dbo].[Person].[Id] = [dbo].[Person_Address].[PersonId]
            GROUP BY
            	[dbo].[Person].[FirstName],
            	[dbo].[Person].[LastName]
            ORDER BY
            	[dbo].[Person].[LastName] ASC,
            	[dbo].[Person].[FirstName] DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/group-by at line 71</summary>
        private void Group_By_line_no_71()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/group-by at line 71");

            //select unique last names ordered ascending
            IEnumerable<string> uniqueLastNames = db.SelectMany(dbo.Person.LastName)
                .From(dbo.Person)
                .GroupBy(dbo.Person.LastName)
                .OrderBy(dbo.Person.LastName.Asc())
                .Execute();

            /*
            SELECT
                [dbo].[Person].[LastName]
            FROM
                [dbo].[Person]
            GROUP BY
                [dbo].[Person].[LastName]
            ORDER BY
                [dbo].[Person].[LastName] ASC;
            */
        }

    }
}
