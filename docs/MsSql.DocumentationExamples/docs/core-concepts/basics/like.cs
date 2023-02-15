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
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/like</summary>
    public class Like : IDocumentationExamples
    {
        private readonly ILogger<Like> logger;

        public Like(ILogger<Like> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Like_line_no_11();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/like at line 11</summary>
        private void Like_line_no_11()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/like at line 11");

            IEnumerable<Person> persons = db.SelectMany<Person>()
            	.From(dbo.Person)
            	.Where((dbo.Person.FirstName + " " + dbo.Person.LastName).Like("David W%"))
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Person].[Id],
            	[dbo].[Person].[FirstName],
            	[dbo].[Person].[LastName],
            	[dbo].[Person].[BirthDate],
            	[dbo].[Person].[GenderType],
            	[dbo].[Person].[CreditLimit],
            	[dbo].[Person].[YearOfLastCreditLimitReview],
            	[dbo].[Person].[RegistrationDate],
            	[dbo].[Person].[LastLoginDate],
            	[dbo].[Person].[DateCreated],
            	[dbo].[Person].[DateUpdated]
            FROM
            	[dbo].[Person]
            WHERE
            	([dbo].[Person].[FirstName] + @P1 + [dbo].[Person].[LastName]) LIKE @P2;',N'@P1 char(1),@P2 char(8)',@P1=' ',@P2='David W%'
            */
        }

    }
}
