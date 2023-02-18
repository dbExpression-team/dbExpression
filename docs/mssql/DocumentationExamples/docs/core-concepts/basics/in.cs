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
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/in</summary>
    public class In : IDocumentationExamples
    {
        private readonly ILogger<In> logger;

        public In(ILogger<In> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            In_line_no_11();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/in at line 11</summary>
        private void In_line_no_11()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/in at line 11");

            IEnumerable<Purchase> purchases = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .Where(
                    dbo.Purchase.PaymentMethodType.In(
                        PaymentMethodType.CreditCard,
                        PaymentMethodType.ACH,
                        PaymentMethodType.PayPal
                    )
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
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
            WHERE
            	[_t0].[PaymentMethodType] IN (@P1,@P2,@P3);',N'@P1 varchar(20),@P2 varchar(20),@P3 varchar(20)',@P1='CreditCard',@P2='ACH',@P3='PayPal'
            */
        }

    }
}
