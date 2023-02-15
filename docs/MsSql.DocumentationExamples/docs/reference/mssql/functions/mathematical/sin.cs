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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin</summary>
    public class Sin : IDocumentationExamples
    {
        private readonly ILogger<Sin> logger;

        public Sin(ILogger<Sin> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Sin_line_no_41();
            Sin_line_no_59();
            Sin_line_no_82();
            Sin_line_no_118();
            Sin_line_no_150();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 41</summary>
        private void Sin_line_no_41()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 41");

            float? result = db.SelectOne(
                    db.fx.Sin(dbo.Product.Weight)
                )
                .From(dbo.Product)
                .Execute();

            /*
            SELECT TOP(1)
            	SIN([dbo].[Product].[Weight])
            FROM
            	[dbo].[Product];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 59</summary>
        private void Sin_line_no_59()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 59");

            IEnumerable<float?> result = db.SelectMany(
                    db.fx.Sin(dbo.Product.Depth)
                )
                .From(dbo.Product)
                .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	SIN([dbo].[Product].[Depth])
            FROM
            	[dbo].[Product]
            WHERE
            	[dbo].[Product].[Depth] > @P1
            	AND
            	[dbo].[Product].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 82</summary>
        private void Sin_line_no_82()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 82");

            IEnumerable<Product> result = db.SelectMany<Product>()
                .From(dbo.Product)
                .OrderBy(db.fx.Sin(dbo.Product.Depth).Desc())
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
            	SIN([dbo].[Product].[Depth]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 118</summary>
        private void Sin_line_no_118()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 118");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.Sin(dbo.Product.Depth).As("calculated_value")
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Sin(dbo.Product.Depth)
                )
                .Execute();

            /*
            SELECT
            	[dbo].[Product].[ProductCategoryType],
            	SIN([dbo].[Product].[Depth]) AS [calculated_value]
            FROM
            	[dbo].[Product]
            WHERE
            	[dbo].[Product].[Depth] > @P1
            	AND
            	[dbo].[Product].[Depth] < @P2
            GROUP BY
            	[dbo].[Product].[ProductCategoryType],
            	SIN([dbo].[Product].[Depth]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 150</summary>
        private void Sin_line_no_150()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 150");

            IEnumerable<ProductCategoryType?> results = db.SelectMany(
                    dbo.Product.ProductCategoryType
                )
                .From(dbo.Product)
                .Where(dbo.Product.Height > 0 & dbo.Product.Height < 1)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Sin(dbo.Product.Height)
                )
                .Having(
                    db.fx.Sin(dbo.Product.Height) < .5f
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
            	SIN([dbo].[Product].[Height])
            HAVING
            	SIN([dbo].[Product].[Height]) < @P3;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
            */
        }

    }
}
