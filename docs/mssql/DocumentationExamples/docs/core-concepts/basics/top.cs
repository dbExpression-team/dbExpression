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
                [_t0].[Id],
                [_t0].[PersonId],
                [_t0].[OrderNumber],
                [_t0].[TotalPurchaseQuantity],
                [_t0].[TotalPurchaseAmount],
                [_t0].[PurchaseDate],
                [_t0].[ShipDate],
                [_t0].[ExpectedDeliveryDate],
                [_t0].[TrackingIdentifier],
                [_t0].[PaymentMethodType],
                [_t0].[PaymentSourceType],
                [_t0].[DateCreated],
                [_t0].[DateUpdated]
            FROM
                [dbo].[Purchase] AS [_t0]
            ORDER BY
                [_t0].[TotalPurchaseAmount] DESC;
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
                [_t0].[FirstName],
                [_t0].[LastName]
            FROM
                [dbo].[Person] AS [_t0]
            ORDER BY
                [_t0].[LastName] ASC,
                [_t0].[FirstName] ASC;
            */
        }

    }
}
