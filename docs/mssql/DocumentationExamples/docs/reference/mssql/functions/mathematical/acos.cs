using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Mathematical
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos</summary>
    public class ACos : IDocumentationExamples
    {
        private readonly ILogger<ACos> logger;

        public ACos(ILogger<ACos> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            ACos_line_no_43();
            ACos_line_no_66();
            ACos_line_no_89();
            ACos_line_no_130();
            ACos_line_no_163();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 43</summary>
        private void ACos_line_no_43()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 43");

            float? result = db.SelectOne(
                    db.fx.ACos(dbo.Product.Weight)
                )
                .From(dbo.Product)
                .Where(dbo.Product.Weight > 0 & dbo.Product.Weight < 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
            	ACOS([_t0].[Weight])
            FROM
            	[dbo].[Product] AS [_t0]
            WHERE
            	[_t0].[Weight] > @P1
            	AND
            	[_t0].[Weight] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 66</summary>
        private void ACos_line_no_66()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 66");

            float? result = db.SelectOne(
                    db.fx.ACos(dbo.Product.Depth)
                )
                .From(dbo.Product)
                .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
            	ACOS([_t0].[Depth])
            FROM
            	[dbo].[Product] AS [_t0]
            WHERE
            	[_t0].[Depth] > @P1
            	AND
            	[_t0].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 89</summary>
        private void ACos_line_no_89()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 89");

            IEnumerable<Product> result = db.SelectMany<Product>()
                .From(dbo.Product)
                .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
                .OrderBy(db.fx.ACos(dbo.Product.Depth).Desc())
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[_t0].[Id],
            	[_t0].[ProductCategoryType],
            	[_t0].[Name],
            	[_t0].[Description],
            	[_t0].[ListPrice],
            	[_t0].[Price],
            	[_t0].[Quantity],
            	[_t0].[Image],
            	[_t0].[Height],
            	[_t0].[Width],
            	[_t0].[Depth],
            	[_t0].[Weight],
            	[_t0].[ShippingWeight],
            	[_t0].[ValidStartTimeOfDayForPurchase],
            	[_t0].[ValidEndTimeOfDayForPurchase],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Product] AS [_t0]
            WHERE
            	[_t0].[Depth] > @P1
            	AND
            	[_t0].[Depth] < @P2
            ORDER BY
            	ACOS([_t0].[Depth]) DESC;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 130</summary>
        private void ACos_line_no_130()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 130");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.ACos(dbo.Product.Depth).As("calculated_value")
                )
                .From(dbo.Product)
                .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.ACos(dbo.Product.Depth)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[_t0].[ProductCategoryType],
            	ACOS([_t0].[Depth]) AS [calculated_value]
            FROM
            	[dbo].[Product] AS [_t0]
            WHERE
            	[_t0].[Depth] > @P1
            	AND
            	[_t0].[Depth] < @P2
            GROUP BY
            	[_t0].[ProductCategoryType],
            	ACOS([_t0].[Depth]);',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 163</summary>
        private void ACos_line_no_163()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/acos at line 163");

            IEnumerable<ProductCategoryType?> results = db.SelectMany(
                    dbo.Product.ProductCategoryType
                )
                .From(dbo.Product)
                .Where(dbo.Product.Height > 0 & dbo.Product.Height < 1)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.ACos(dbo.Product.Height)
                )
                .Having(
                    db.fx.ACos(dbo.Product.Height) < .5f
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[_t0].[ProductCategoryType]
            FROM
            	[dbo].[Product] AS [_t0]
            WHERE
            	[_t0].[Height] > @P1
            	AND
            	[_t0].[Height] < @P2
            GROUP BY
            	[_t0].[ProductCategoryType],
            	ACOS([_t0].[Height])
            HAVING
            	ACOS([_t0].[Height]) < @P3;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
            */
        }

    }
}
