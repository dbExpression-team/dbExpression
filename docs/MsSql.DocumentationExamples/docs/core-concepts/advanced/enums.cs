using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Advanced
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
            	[_t0].[Id],
            	[_t0].[AddressType],
            	[_t0].[Line1],
            	[_t0].[Line2],
            	[_t0].[City],
            	[_t0].[State],
            	[_t0].[Zip],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Address] AS [_t0]
            WHERE
            	[_t0].[AddressType] = @P1;',N'@P1 int',@P1=2
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
            	[_t0].[Id],
            	[_t0].[AddressType],
            	[_t0].[Line1],
            	[_t0].[Line2],
            	[_t0].[City],
            	[_t0].[State],
            	[_t0].[Zip],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Address] AS [_t0]
            WHERE
            	[_t0].[AddressType] IN (@P1,@P2);',N'@P1 int,@P2 int',@P1=2,@P2=1
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
            	[_t0].[AddressType],
            	COUNT([_t0].[Id]) AS [AddressCount]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType];
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
            	ISNULL([_t0].[AddressType], @P1)
            FROM
            	[dbo].[Address] AS [_t0];',N'@P1 int',@P1=2
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
            	[_t0]
            SET
            	[_t0].[AddressType] = @P1
            FROM
            	[dbo].[Address] AS [_t0]
            WHERE
            	[_t0].[AddressType] IS NULL;
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
            	[_t0].[PaymentMethodType] = @P1;',N'@P1 varchar(20)',@P1='CreditCard'
            */
        }

    }
}
