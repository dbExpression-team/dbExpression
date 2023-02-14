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
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt</summary>
	public class Sqrt : IDocumentationExamples
	{
		private readonly ILogger<Sqrt> logger;

		public Sqrt(ILogger<Sqrt> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Sqrt_line_no_41();
			Sqrt_line_no_60();
			Sqrt_line_no_83();
			Sqrt_line_no_119();
			Sqrt_line_no_147();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 41</summary>
		private void Sqrt_line_no_41()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 41");

			float? result = db.SelectOne(
			        db.fx.Sqrt(dbo.Product.Height)
			    )
			    .From(dbo.Product)
			    .Execute();

			/*
			SELECT TOP(1)
				SQRT([dbo].[Product].[Height])
			FROM
				[dbo].[Product];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 60</summary>
		private void Sqrt_line_no_60()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 60");

			float? result = db.SelectOne(
			        db.fx.Sqrt(dbo.Product.Depth)
			    )
			    .From(dbo.Product)
			    .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 10)
			    .Execute();

			/*
			exec sp_executesql N'SELECT TOP(1)
				SQRT([dbo].[Product].[Depth])
			FROM
				[dbo].[Product]
			WHERE
				[dbo].[Product].[Depth] > @P1
				AND
				[dbo].[Product].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=10.0
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 83</summary>
		private void Sqrt_line_no_83()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 83");

			IEnumerable<Product> result = db.SelectMany<Product>()
			    .From(dbo.Product)
			    .OrderBy(db.fx.Sqrt(dbo.Product.Depth).Desc())
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
				[dbo].[Product].[Height],
				[dbo].[Product].[ShippingHeight],
				[dbo].[Product].[ValidStartTimeOfDayForPurchase],
				[dbo].[Product].[ValidEndTimeOfDayForPurchase],
				[dbo].[Product].[DateCreated],
				[dbo].[Product].[DateUpdated]
			FROM
				[dbo].[Product]
			ORDER BY
				SQRT([dbo].[Product].[Depth]) DESC;
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 119</summary>
		private void Sqrt_line_no_119()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 119");

			IEnumerable<dynamic> results = db.SelectMany(
			        dbo.Product.ProductCategoryType,
			        db.fx.Sqrt(dbo.Product.Depth).As("calculated_value")
			    )
			    .From(dbo.Product)
			    .GroupBy(
			        dbo.Product.ProductCategoryType,
			        db.fx.Sqrt(dbo.Product.Depth)
			    )
			    .Execute();

			/*
			SELECT
				[dbo].[Product].[ProductCategoryType],
				SQRT([dbo].[Product].[Depth]) AS [calculated_value]
			FROM
				[dbo].[Product]
			GROUP BY
				[dbo].[Product].[ProductCategoryType],
				SQRT([dbo].[Product].[Depth]);
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 147</summary>
		private void Sqrt_line_no_147()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sqrt at line 147");

			IEnumerable<ProductCategoryType?> results = db.SelectMany(
			        dbo.Product.ProductCategoryType
			    )
			    .From(dbo.Product)
			    .GroupBy(
			        dbo.Product.ProductCategoryType,
			        db.fx.Sqrt(dbo.Product.Height)
			    )
			    .Having(
			        db.fx.Sqrt(dbo.Product.Height) < .5f
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Product].[ProductCategoryType]
			FROM
				[dbo].[Product]
			GROUP BY
				[dbo].[Product].[ProductCategoryType],
				SQRT([dbo].[Product].[Height])
			HAVING
				SQRT([dbo].[Product].[Height]) < @P3;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
			*/
		}

	}
}
