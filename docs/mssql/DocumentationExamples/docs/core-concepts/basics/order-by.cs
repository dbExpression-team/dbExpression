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
            ORDER BY
                [t0].[LastName] DESC;
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
            ORDER BY
                [t0].[GenderType] ASC,
                [t0].[LastName] ASC;
            */
        }

    }
}
