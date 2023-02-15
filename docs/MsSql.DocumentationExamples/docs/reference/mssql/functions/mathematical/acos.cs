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
            	ACOS([dbo].[Product].[Weight])
            FROM
            	[dbo].[Product]
            WHERE
            	[dbo].[Product].[Weight] > @P1
            	AND
            	[dbo].[Product].[Weight] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
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
            	ACOS([dbo].[Product].[Depth])
            FROM
            	[dbo].[Product]
            WHERE
            	[dbo].[Product].[Depth] > @P1
            	AND
            	[dbo].[Product].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
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
            	ACOS([dbo].[Product].[Depth]) DESC;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
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
            	[dbo].[Product].[ProductCategoryType],
            	ACOS([dbo].[Product].[Depth]) AS [calculated_value]
            FROM
            	[dbo].[Product]
            WHERE
            	[dbo].[Product].[Depth] > @P1
            	AND
            	[dbo].[Product].[Depth] < @P2
            GROUP BY
            	[dbo].[Product].[ProductCategoryType],
            	ACOS([dbo].[Product].[Depth]);',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
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
            	[dbo].[Product].[ProductCategoryType]
            FROM
            	[dbo].[Product]
            WHERE
            	[dbo].[Product].[Height] > @P1
            	AND
            	[dbo].[Product].[Height] < @P2
            GROUP BY
            	[dbo].[Product].[ProductCategoryType],
            	ACOS([dbo].[Product].[Height])
            HAVING
            	ACOS([dbo].[Product].[Height]) < @P3;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
            */
        }

    }
}
