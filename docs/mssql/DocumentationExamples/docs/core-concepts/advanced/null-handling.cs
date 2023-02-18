using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Advanced
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/advanced/null-handling</summary>
    public class Null_Handling : IDocumentationExamples
    {
        private readonly ILogger<Null_Handling> logger;

        public Null_Handling(ILogger<Null_Handling> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Null_Handling_line_no_29();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/null-handling at line 29</summary>
        private void Null_Handling_line_no_29()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/null-handling at line 29");

            // it is known that the equality comparison is to a type of
            // DateTime? as we are casting a CLR null to DateTime?
            db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.LastLoginDate == (DateTime?)null)
                .Execute();
            
            // equality comparison to a NullElement provided by dbex.Null,
            // which is fully understood by dbExpression
            db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.LastLoginDate == dbex.Null)
                .Execute();

            /*
            SELECT TOP(1)
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
            	[_t0].[LastLoginDate] IS NULL;
            */
        }

    }
}
