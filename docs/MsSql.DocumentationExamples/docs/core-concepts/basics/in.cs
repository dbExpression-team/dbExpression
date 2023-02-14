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
				[dbo].[Purchase].[Id],
				[dbo].[Purchase].[PersonId],
				[dbo].[Purchase].[OrderNumber],
				[dbo].[Purchase].[TotalPurchaseQuantity],
				[dbo].[Purchase].[TotalPurchaseAmount],
				[dbo].[Purchase].[PurchaseDate],
				[dbo].[Purchase].[ShipDate],
				[dbo].[Purchase].[ExpectedDeliveryDate],
				[dbo].[Purchase].[TrackingIdentifier],
				[dbo].[Purchase].[PaymentMethodType],
				[dbo].[Purchase].[PaymentSourceType],
				[dbo].[Purchase].[DateCreated],
				[dbo].[Purchase].[DateUpdated]
			FROM
				[dbo].[Purchase]
			WHERE
				[dbo].[Purchase].[PaymentMethodType] IN (@P1,@P2,@P3)
			;',N'@P1 varchar(20),@P2 varchar(20),@P3 varchar(20)',@P1='CreditCard',@P2='ACH',@P3='PayPal'
			*/
		}

	}
}
