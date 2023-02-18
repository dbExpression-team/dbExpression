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
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/order-by</summary>
    public class Order_By : IDocumentationExamples
    {
        private readonly ILogger<Order_By> logger;

        public Order_By(ILogger<Order_By> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Order_By_line_no_10();
            Order_By_line_no_38();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/order-by at line 10</summary>
        private void Order_By_line_no_10()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/order-by at line 10");

            //select all people ordered by last name descending
            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.LastName.Desc())
                .Execute();

            /*
            SELECT
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
            ORDER BY
                [_t0].[LastName] DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/order-by at line 38</summary>
        private void Order_By_line_no_38()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/order-by at line 38");

            //select all people ordered by gender type ascending and last name ascending
            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(
                    dbo.Person.GenderType,
                    dbo.Person.LastName
                )
                .Execute();

            /*
            SELECT
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
            ORDER BY
                [_t0].[GenderType] ASC,
                [_t0].[LastName] ASC;
            */
        }

    }
}
