using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Basics
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
            	[t0].[Id],
            	[t0].[FirstName],
            	[t0].[LastName],
            	[t0].[BirthDate],
            	[t0].[GenderType],
            	[t0].[CreditLimit],
            	[t0].[YearOfLastCreditLimitReview],
            	[t0].[RegistrationDate],
            	[t0].[LastLoginDate],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [t0]
            WHERE
            	([t0].[FirstName] + @P1 + [t0].[LastName]) LIKE @P2;',N'@P1 char(1),@P2 char(8)',@P1=' ',@P2='David W%'
            */
        }

    }
}
