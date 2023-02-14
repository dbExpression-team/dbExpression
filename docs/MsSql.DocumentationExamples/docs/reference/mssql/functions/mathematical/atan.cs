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
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan</summary>
	public class ATan : IDocumentationExamples
	{
		private readonly ILogger<ATan> logger;

		public ATan(ILogger<ATan> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			ATan_line_no_41();
			ATan_line_no_60();
			ATan_line_no_83();
			ATan_line_no_119();
			ATan_line_no_147();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 41</summary>
		private void ATan_line_no_41()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 41");

			float? result = db.SelectOne(
			        db.fx.ATan(dbo.Product.Weight)
			    )
			    .From(dbo.Product)
			    .Where(dbo.Product.Weight > 0 & dbo.Product.Weight < 1)
			    .Execute();

			/*
			SELECT TOP(1)
				ATAN([dbo].[Product].[Weight])
			FROM
				[dbo].[Product];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 60</summary>
		private void ATan_line_no_60()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 60");

			float? result = db.SelectOne(
			        db.fx.ATan(dbo.Product.Depth)
			    )
			    .From(dbo.Product)
			    .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
			    .Execute();

			/*
			exec sp_executesql N'SELECT TOP(1)
				ATAN([dbo].[Product].[Depth])
			FROM
				[dbo].[Product]
			WHERE
				[dbo].[Product].[Depth] > @P1
				AND
				[dbo].[Product].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 83</summary>
		private void ATan_line_no_83()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 83");

			IEnumerable<Product> result = db.SelectMany<Product>()
			    .From(dbo.Product)
			    .OrderBy(db.fx.ATan(dbo.Product.Depth).Desc())
			    .Execute();

			/*
			SELECT
				[dbo].[Product].[Id],
				[dbo].[Product].[ProductCategoryType],
				[dbo].[Product].[Name],
				[dbo].[Product].[Description],
				[dbo].[Product].[ListPrice],
				[dbo].[Product].[Price],
				[dbo].[Product].[Quantity],
				[dbo].[Product].[Image],
				[dbo].[Product].[Height],
				[dbo].[Product].[Width],
				[dbo].[Product].[Depth],
				[dbo].[Product].[Weight],
				[dbo].[Product].[ShippingWeight],
				[dbo].[Product].[ValidStartTimeOfDayForPurchase],
				[dbo].[Product].[ValidEndTimeOfDayForPurchase],
				[dbo].[Product].[DateCreated],
				[dbo].[Product].[DateUpdated]
			FROM
				[dbo].[Product]
			ORDER BY
				ATAN([dbo].[Product].[Depth]) DESC;
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 119</summary>
		private void ATan_line_no_119()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 119");

			IEnumerable<dynamic> results = db.SelectMany(
			        dbo.Product.ProductCategoryType,
			        db.fx.ATan(dbo.Product.Depth).As("calculated_value")
			    )
			    .From(dbo.Product)
			    .GroupBy(
			        dbo.Product.ProductCategoryType,
			        db.fx.ATan(dbo.Product.Depth)
			    )
			    .Execute();

			/*
			SELECT
				[dbo].[Product].[ProductCategoryType],
				ATAN([dbo].[Product].[Depth]) AS [calculated_value]
			FROM
				[dbo].[Product]
			GROUP BY
				[dbo].[Product].[ProductCategoryType],
				ATAN([dbo].[Product].[Depth]);
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 147</summary>
		private void ATan_line_no_147()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 147");

			IEnumerable<ProductCategoryType?> results = db.SelectMany(
			        dbo.Product.ProductCategoryType
			    )
			    .From(dbo.Product)
			    .GroupBy(
			        dbo.Product.ProductCategoryType,
			        db.fx.ATan(dbo.Product.Depth)
			    )
			    .Having(
			        db.fx.ATan(dbo.Product.Depth) < .5f
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Product].[ProductCategoryType]
			FROM
				[dbo].[Product]
			GROUP BY
				[dbo].[Product].[ProductCategoryType],
				ATAN([dbo].[Product].[Depth])
			HAVING
				ATAN([dbo].[Product].[Depth]) < @P1;',N'@P1 decimal(4,1)',@P1=0.5
			*/
		}

	}
}
