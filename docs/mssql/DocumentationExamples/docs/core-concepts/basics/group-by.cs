using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Basics
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
                [t0].[LastName],
                COUNT([t0].[LastName]) AS [LastNameCount]
            FROM
                [dbo].[Person] AS [t0]
            GROUP BY
                [t0].[LastName];
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
                [t0].[FirstName],
                [t0].[LastName],
                COUNT([t1].[Id]) AS [Count]
            FROM
                [dbo].[Person] AS [t0]
                INNER JOIN [dbo].[Person_Address] AS [t1] ON [t0].[Id] = [t1].[PersonId]
            GROUP BY
                [t0].[FirstName],
                [t0].[LastName]
            ORDER BY
                [t0].[LastName] ASC,
                [t0].[FirstName] DESC;
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
                [t0].[LastName]
            FROM
                [dbo].[Person] AS [t0]
            GROUP BY
                [t0].[LastName]
            ORDER BY
                [t0].[LastName] ASC;
            */
        }

    }
}
