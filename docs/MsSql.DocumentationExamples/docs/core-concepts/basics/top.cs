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
			ORDER BY
			    [dbo].[Purchase].[TotalPurchaseAmount] DESC;
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
				[dbo].[Person].[FirstName],
				[dbo].[Person].[LastName]
			FROM
				[dbo].[Person]
			ORDER BY
				[dbo].[Person].[LastName] ASC,
				[dbo].[Person].[FirstName] ASC
			;
			*/
		}

	}
}
