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
            ORDER BY
                [dbo].[Person].[LastName] DESC;
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
            ORDER BY
                [dbo].[Person].[GenderType] ASC,
                [dbo].[Person].[LastName] ASC;
            */
        }

    }
}
