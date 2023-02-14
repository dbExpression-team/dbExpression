using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.Mathematical
{
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling</summary>
	public class Ceiling : IDocumentationExamples
	{
		private readonly ILogger<Ceiling> logger;

		public Ceiling(ILogger<Ceiling> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Ceiling_line_no_41();
			Ceiling_line_no_59();
			Ceiling_line_no_80();
			Ceiling_line_no_101();
			Ceiling_line_no_132();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 41</summary>
		private void Ceiling_line_no_41()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 41");

			IEnumerable<double> value = db.SelectMany(
			        db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount)
			    )
			    .From(dbo.Purchase)
			    .Execute();

			/*
			SELECT
				CEILING([dbo].[Purchase].[TotalPurchaseAmount])
			FROM
				[dbo].[Purchase];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 59</summary>
		private void Ceiling_line_no_59()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 59");

			IEnumerable<int> value = db.SelectMany(
			        dbo.Purchase.Id
			    )
			    .From(dbo.Purchase)
			    .Where(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount) <= 100)
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Purchase].[Id]
			FROM
				[dbo].[Purchase]
			WHERE
				CEILING([dbo].[Purchase].[TotalPurchaseAmount]) <= @P1;',N'@P1 float',@P1=100
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 80</summary>
		private void Ceiling_line_no_80()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 80");

			IEnumerable<double> value = db.SelectMany(
			        dbo.Purchase.TotalPurchaseAmount
			    )
			    .From(dbo.Purchase)
			    .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).Desc())
			    .Execute();

			/*
			SELECT
				[dbo].[Purchase].[TotalPurchaseAmount]
			FROM
				[dbo].[Purchase]
			ORDER BY
				CEILING([dbo].[Purchase].[TotalPurchaseAmount]) DESC;
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 101</summary>
		private void Ceiling_line_no_101()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 101");

			IEnumerable<dynamic> values = db.SelectMany(
			        dbo.Purchase.PaymentMethodType,
			        db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).As("TotalPurchaseAmount")
			    )
			    .From(dbo.Purchase)
			    .GroupBy(
			        dbo.Purchase.PaymentMethodType,
			        db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount)
			    )
			    .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount))
			    .Execute();

			/*
			SELECT
				[dbo].[Purchase].[PaymentMethodType],
				CEILING([dbo].[Purchase].[TotalPurchaseAmount]) AS [TotalPurchaseAmount]
			FROM
				[dbo].[Purchase]
			GROUP BY
				[dbo].[Purchase].[PaymentMethodType],
				CEILING([dbo].[Purchase].[TotalPurchaseAmount])
			ORDER BY
				CEILING([dbo].[Purchase].[TotalPurchaseAmount]) ASC;
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 132</summary>
		private void Ceiling_line_no_132()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/ceiling at line 132");

			IEnumerable<dynamic> values = db.SelectMany(
			        dbo.Purchase.PaymentMethodType,
			        db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).As("TotalPurchaseAmount")
			    )
			    .From(dbo.Purchase)
			    .GroupBy(
			        dbo.Purchase.PaymentMethodType,
			        db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount)
			    )
			    .Having(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount) > 10)
			    .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount))
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Purchase].[PaymentMethodType],
				CEILING([dbo].[Purchase].[TotalPurchaseAmount]) AS [TotalPurchaseAmount]
			FROM
				[dbo].[Purchase]
			GROUP BY
				[dbo].[Purchase].[PaymentMethodType],
				CEILING([dbo].[Purchase].[TotalPurchaseAmount])
			HAVING
				CEILING([dbo].[Purchase].[TotalPurchaseAmount]) > @P1
			ORDER BY
				CEILING([dbo].[Purchase].[TotalPurchaseAmount]) ASC;',N'@P1 float',@P1=10
			*/
		}

	}
}
