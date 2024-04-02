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
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/top</summary>
    public class Top : IDocumentationExamples
    {
        private readonly ILogger<Top> logger;

        public Top(ILogger<Top> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Top_line_no_10();
            Top_line_no_43();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/top at line 10</summary>
        private void Top_line_no_10()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/top at line 10");

            //select the top 5 purchases by dollar amount
            IEnumerable<Purchase> purchases = db.SelectMany<Purchase>()
                .Top(5)
                .From(dbo.Purchase)
                .OrderBy(dbo.Purchase.TotalPurchaseAmount.Desc())
                .Execute();

            /*
            SELECT TOP(5)
                [t0].[Id],
                [t0].[PersonId],
                [t0].[OrderNumber],
                [t0].[TotalPurchaseQuantity],
                [t0].[TotalPurchaseAmount],
                [t0].[PurchaseDate],
                [t0].[ShipDate],
                [t0].[ExpectedDeliveryDate],
                [t0].[TrackingIdentifier],
                [t0].[PaymentMethodType],
                [t0].[PaymentSourceType],
                [t0].[DateCreated],
                [t0].[DateUpdated]
            FROM
                [dbo].[Purchase] AS [t0]
            ORDER BY
                [t0].[TotalPurchaseAmount] DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/top at line 43</summary>
        private void Top_line_no_43()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/top at line 43");

            //select the top 5 distinct persons by name
            IEnumerable<dynamic> persons = db.SelectMany(
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .Top(5)
                .Distinct()
                .From(dbo.Person)
                .OrderBy(
                    dbo.Person.LastName,
                    dbo.Person.FirstName
                )
                .Execute();

            /*
            SELECT DISTINCT TOP(5)
                [t0].[FirstName],
                [t0].[LastName]
            FROM
                [dbo].[Person] AS [t0]
            ORDER BY
                [t0].[LastName] ASC,
                [t0].[FirstName] ASC;
            */
        }

    }
}
