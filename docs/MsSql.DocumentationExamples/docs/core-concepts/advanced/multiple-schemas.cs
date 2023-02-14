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
	///<summary>Code examples from https://dbexpression.com/docs/core-concepts/advanced/multiple-schemas</summary>
	public class Multiple_Schemas : IDocumentationExamples
	{
		private readonly ILogger<Multiple_Schemas> logger;

		public Multiple_Schemas(ILogger<Multiple_Schemas> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Multiple_Schemas_line_no_10();
		}

		///<summary>https://dbexpression.com/docs/core-concepts/advanced/multiple-schemas at line 10</summary>
		private void Multiple_Schemas_line_no_10()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/multiple-schemas at line 10");

			IEnumerable<dynamic> purchases = db.SelectMany(
			        sec.Person.Id,
			        sec.Person.SocialSecurityNumber,
			        dbo.Purchase.PurchaseDate,
			        dbo.Purchase.OrderNumber,
			        dbo.Purchase.TotalPurchaseAmount
			    )
			    .From(sec.Person)
			    .InnerJoin(dbo.Purchase).On(sec.Person.Id == dbo.Purchase.PersonId)
			    .Execute();

			/*
			SELECT
				[sec].[Person].[Id],
				[sec].[Person].[SSN] AS [SocialSecurityNumber],
				[dbo].[Purchase].[PurchaseDate],
				[dbo].[Purchase].[OrderNumber],
				[dbo].[Purchase].[TotalPurchaseAmount]
			FROM
				[sec].[Person]
				INNER JOIN [dbo].[Purchase] ON [sec].[Person].[Id] = [dbo].[Purchase].[PersonId];
			*/
		}

	}
}
