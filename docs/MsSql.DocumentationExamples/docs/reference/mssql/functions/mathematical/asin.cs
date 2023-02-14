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
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin</summary>
	public class ASin : IDocumentationExamples
	{
		private readonly ILogger<ASin> logger;

		public ASin(ILogger<ASin> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			ASin_line_no_42();
			ASin_line_no_66();
			ASin_line_no_89();
			ASin_line_no_130();
			ASin_line_no_163();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 42</summary>
		private void ASin_line_no_42()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 42");

			float? result = db.SelectOne(
			        db.fx.ASin(dbo.Product.Weight)
			    )
			    .From(dbo.Product)
			    .Where(dbo.Product.Weight > 0 & dbo.Product.Weight < 1)
			    .Execute();

			/*
			exec sp_executesql N'SELECT TOP(1)
				ASIN([dbo].[Product].[Weight])
			FROM
				[dbo].[Product]
			WHERE
				[dbo].[Product].[Weight] > @P1
				AND
				[dbo].[Product].[Weight] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 66</summary>
		private void ASin_line_no_66()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 66");

			float? result = db.SelectOne(
			        db.fx.ASin(dbo.Product.Depth)
			    )
			    .From(dbo.Product)
			    .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
			    .Execute();

			/*
			exec sp_executesql N'SELECT TOP(1)
				ASIN([dbo].[Product].[Depth])
			FROM
				[dbo].[Product]
			WHERE
				[dbo].[Product].[Depth] > @P1
				AND
				[dbo].[Product].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 89</summary>
		private void ASin_line_no_89()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 89");

			IEnumerable<Product> result = db.SelectMany<Product>()
			    .From(dbo.Product)
			    .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
			    .OrderBy(db.fx.ASin(dbo.Product.Depth).Desc())
			    .Execute();

			/*
			exec sp_executesql N'SELECT
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
			WHERE
				[dbo].[Product].[Depth] > @P1
				AND
				[dbo].[Product].[Depth] < @P2
			ORDER BY
				ASIN([dbo].[Product].[Depth]) DESC;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 130</summary>
		private void ASin_line_no_130()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 130");

			IEnumerable<dynamic> results = db.SelectMany(
			        dbo.Product.ProductCategoryType,
			        db.fx.ASin(dbo.Product.Depth).As("calculated_value")
			    )
			    .From(dbo.Product)
			    .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
			    .GroupBy(
			        dbo.Product.ProductCategoryType,
			        db.fx.ASin(dbo.Product.Depth)
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Product].[ProductCategoryType],
				ASIN([dbo].[Product].[Depth]) AS [calculated_value]
			FROM
				[dbo].[Product]
			WHERE
				[dbo].[Product].[Depth] > @P1
				AND
				[dbo].[Product].[Depth] < @P2
			GROUP BY
				[dbo].[Product].[ProductCategoryType],
				ASIN([dbo].[Product].[Depth]);',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 163</summary>
		private void ASin_line_no_163()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/asin at line 163");

			IEnumerable<ProductCategoryType?> results = db.SelectMany(
			        dbo.Product.ProductCategoryType
			    )
			    .From(dbo.Product)
			    .Where(dbo.Product.Height > 0 & dbo.Product.Height < 1)
			    .GroupBy(
			        dbo.Product.ProductCategoryType,
			        db.fx.ASin(dbo.Product.Height)
			    )
			    .Having(
			        db.fx.ASin(dbo.Product.Height) < .5f
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Product].[ProductCategoryType]
			FROM
				[dbo].[Product]
			WHERE
				[dbo].[Product].[Height] > @P1
				AND
				[dbo].[Product].[Height] < @P2
			GROUP BY
				[dbo].[Product].[ProductCategoryType],
				ASIN([dbo].[Product].[Height])
			HAVING
				ASIN([dbo].[Product].[Height]) < @P3;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
			*/
		}

	}
}
