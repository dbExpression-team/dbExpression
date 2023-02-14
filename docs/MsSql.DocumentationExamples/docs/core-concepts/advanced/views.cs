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
	///<summary>Code examples from https://dbexpression.com/docs/core-concepts/advanced/views</summary>
	public class Views : IDocumentationExamples
	{
		private readonly ILogger<Views> logger;

		public Views(ILogger<Views> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Views_line_no_15();
			Views_line_no_62();
			Views_line_no_87();
			Views_line_no_109();
			Views_line_no_136();
		}

		///<summary>https://dbexpression.com/docs/core-concepts/advanced/views at line 15</summary>
		private void Views_line_no_15()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/views at line 15");

			IEnumerable<dynamic> aggregates = db.SelectMany(
			    dbo.Person.Id,
			    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("TotalAmount"),
			    db.fx.Count(dbo.Purchase.Id).As("TotalCount")
			)
			.From(dbo.Person)
			.InnerJoin(dbo.Purchase).On(dbo.Purchase.PersonId == dbo.Person.Id)
			.GroupBy(
			    dbo.Person.Id
			)
			.Execute();

			/*
			SELECT
				[dbo].[Person].[Id],
				SUM([dbo].[Purchase].[TotalPurchaseAmount]) AS [TotalAmount],
				COUNT([dbo].[Purchase].[Id]) AS [TotalCount]
			FROM
				[dbo].[Person]
				INNER JOIN [dbo].[Purchase] ON [dbo].[Purchase].[PersonId] = [dbo].[Person].[Id]
			GROUP BY
				[dbo].[Person].[Id]
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/advanced/views at line 62</summary>
		private void Views_line_no_62()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/views at line 62");

			//return a PersonTotalPurchasesView, where the person's id is 1.
			PersonTotalPurchasesView? person_total = db.SelectOne<PersonTotalPurchasesView>()
			    .From(dbo.PersonTotalPurchasesView)
			    .Where(dbo.PersonTotalPurchasesView.Id == 1)
			    .Execute();

			/*
			exec sp_executesql N'SELECT TOP(1)
				[dbo].[PersonTotalPurchasesView].[Id],
				[dbo].[PersonTotalPurchasesView].[TotalAmount],
				[dbo].[PersonTotalPurchasesView].[TotalCount]
			FROM
				[dbo].[PersonTotalPurchasesView]
			WHERE
				[dbo].[PersonTotalPurchasesView].[Id] = @P1;',N'@P1 int',@P1=1
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/advanced/views at line 87</summary>
		private void Views_line_no_87()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/views at line 87");

			//return a list of PersonTotalPurchasesView, where the list contains any person who has a sum of purchases exceeding $2,500.
			IEnumerable<PersonTotalPurchasesView> people_totals = db.SelectMany<PersonTotalPurchasesView>()
			    .From(dbo.PersonTotalPurchasesView)
			    .Where(dbo.PersonTotalPurchasesView.TotalAmount > 2500)
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[PersonTotalPurchasesView].[Id],
				[dbo].[PersonTotalPurchasesView].[TotalAmount],
				[dbo].[PersonTotalPurchasesView].[TotalCount]
			FROM
				[dbo].[PersonTotalPurchasesView]
			WHERE
				[dbo].[PersonTotalPurchasesView].[TotalAmount] > @P1;',N'@P1 money',@P1=$2500.0000
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/advanced/views at line 109</summary>
		private void Views_line_no_109()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/views at line 109");

			//update any person's credit limit by 10% (rounding down to the nearest integer) who has spent more than $2,500 and a credit limit exists
			int affectedCount = db.Update(
			        dbo.Person.CreditLimit.Set(db.fx.Cast(db.fx.Floor(dbo.Person.CreditLimit * 1.1)).AsInt())
			    )
			    .From(dbo.Person)
			    .InnerJoin(dbo.PersonTotalPurchasesView).On(dbo.Person.Id == dbo.PersonTotalPurchasesView.Id)
			    .Where(dbo.PersonTotalPurchasesView.TotalAmount > 2500)
			    .Execute();

			/*
			exec sp_executesql N'UPDATE
				[dbo].[Person]
			SET
				[CreditLimit] = CAST(FLOOR(([CreditLimit] * @P1)) AS Int)
			FROM
				[dbo].[Person]
				INNER JOIN [dbo].[PersonTotalPurchasesView] ON [dbo].[Person].[Id] = [dbo].[PersonTotalPurchasesView].[Id]
			WHERE
				[dbo].[PersonTotalPurchasesView].[TotalAmount] > @P2;
			SELECT @@ROWCOUNT;',N'@P1 float,@P2 money',@P1=1.1000000000000001,@P2=$2500.0000
			*/
		}

		///<summary>https://dbexpression.com/docs/core-concepts/advanced/views at line 136</summary>
		private void Views_line_no_136()
		{
			logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/views at line 136");

			//delete all addresses for any person that hasn't made any purchases
			int affectedCount = db.Delete()
				.From(dbo.PersonAddress)
				.InnerJoin(dbo.Person).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
				.LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Person.Id == dbo.PersonTotalPurchasesView.Id)
				.Where(dbo.PersonTotalPurchasesView.Id == dbex.Null)
				.Execute();

			/*
			DELETE
				[dbo].[Person]
			FROM
				[dbo].[Person]
				LEFT JOIN [dbo].[PersonTotalPurchasesView] ON [dbo].[Person].[Id] = [dbo].[PersonTotalPurchasesView].[Id]
			WHERE
				[dbo].[PersonTotalPurchasesView].[Id] IS NULL;
			SELECT @@ROWCOUNT;
			*/
		}

	}
}
