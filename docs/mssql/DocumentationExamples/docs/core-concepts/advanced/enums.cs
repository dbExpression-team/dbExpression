using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Advanced
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/advanced/enums</summary>
    public class Enums : IDocumentationExamples
    {
        private readonly ILogger<Enums> logger;

        public Enums(ILogger<Enums> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Enums_line_no_25();
            Enums_line_no_53();
            Enums_line_no_79();
            Enums_line_no_101();
            Enums_line_no_118();
            Enums_line_no_156();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/enums at line 25</summary>
        private void Enums_line_no_25()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/enums at line 25");

            IEnumerable<Address> billing_addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .Where(dbo.Address.AddressType == AddressType.Billing)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[t0].[Id],
            	[t0].[AddressType],
            	[t0].[Line1],
            	[t0].[Line2],
            	[t0].[City],
            	[t0].[State],
            	[t0].[Zip],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Address] AS [t0]
            WHERE
            	[t0].[AddressType] = @P1;',N'@P1 int',@P1=2
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/enums at line 53</summary>
        private void Enums_line_no_53()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/enums at line 53");

            IEnumerable<Address> billing_and_mailing_addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .Where(dbo.Address.AddressType.In(AddressType.Billing, AddressType.Mailing))
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[t0].[Id],
            	[t0].[AddressType],
            	[t0].[Line1],
            	[t0].[Line2],
            	[t0].[City],
            	[t0].[State],
            	[t0].[Zip],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Address] AS [t0]
            WHERE
            	[t0].[AddressType] IN (@P1,@P2);',N'@P1 int,@P2 int',@P1=2,@P2=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/enums at line 79</summary>
        private void Enums_line_no_79()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/enums at line 79");

            IEnumerable<dynamic> count_by_address_type = db.SelectMany(
                    dbo.Address.AddressType,
                    db.fx.Count(dbo.Address.Id).As("AddressCount")
                )
                .From(dbo.Address)
                .GroupBy(dbo.Address.AddressType)
                .Execute();

            /*
            SELECT
            	[t0].[AddressType],
            	COUNT([t0].[Id]) AS [AddressCount]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/enums at line 101</summary>
        private void Enums_line_no_101()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/enums at line 101");

            IEnumerable<AddressType> address_types = db.SelectMany(
                    db.fx.IsNull(dbo.Address.AddressType, AddressType.Billing)
                )
                .From(dbo.Address)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	ISNULL([t0].[AddressType], @P1)
            FROM
            	[dbo].[Address] AS [t0];',N'@P1 int',@P1=2
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/enums at line 118</summary>
        private void Enums_line_no_118()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/enums at line 118");

            db.Update(
                    dbo.Address.AddressType.Set(AddressType.Mailing)
                )
                .From(dbo.Address)
                .Where(dbo.Address.AddressType == dbex.Null)
                .Execute();

            /*
            exec sp_executesql N'UPDATE
            	[t0]
            SET
            	[t0].[AddressType] = @P1
            FROM
            	[dbo].[Address] AS [t0]
            WHERE
            	[t0].[AddressType] IS NULL;
            SELECT @@ROWCOUNT;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/enums at line 156</summary>
        private void Enums_line_no_156()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/enums at line 156");

            IEnumerable<Purchase> credit_card_purchases = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PaymentMethodType == PaymentMethodType.CreditCard)
                .Execute();

            /*
            exec sp_executesql N'SELECT
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
            WHERE
            	[t0].[PaymentMethodType] = @P1;',N'@P1 varchar(20)',@P1='CreditCard'
            */
        }

    }
}
