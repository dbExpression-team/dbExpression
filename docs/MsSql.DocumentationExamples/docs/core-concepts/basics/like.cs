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
            	[_t0].[Id],
            	[_t0].[FirstName],
            	[_t0].[LastName],
            	[_t0].[BirthDate],
            	[_t0].[GenderType],
            	[_t0].[CreditLimit],
            	[_t0].[YearOfLastCreditLimitReview],
            	[_t0].[RegistrationDate],
            	[_t0].[LastLoginDate],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [_t0]
            WHERE
            	([_t0].[FirstName] + @P1 + [_t0].[LastName]) LIKE @P2;',N'@P1 char(1),@P2 char(8)',@P1=' ',@P2='David W%'
            */
        }

    }
}
