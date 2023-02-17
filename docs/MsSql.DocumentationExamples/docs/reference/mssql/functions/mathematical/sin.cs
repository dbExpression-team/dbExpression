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
            Sin_line_no_146();
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
            	SIN([_t0].[Weight])
            FROM
            	[dbo].[Product] AS [_t0];
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
            	SIN([_t0].[Depth])
            FROM
            	[dbo].[Product] AS [_t0]
            WHERE
            	[_t0].[Depth] > @P1
            	AND
            	[_t0].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
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
            ORDER BY
            	SIN([_t0].[Depth]) DESC;
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
            	[_t0].[ProductCategoryType],
            	SIN([_t0].[Depth]) AS [calculated_value]
            FROM
            	[dbo].[Product] AS [_t0]
            GROUP BY
            	[_t0].[ProductCategoryType],
            	SIN([_t0].[Depth]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 146</summary>
        private void Sin_line_no_146()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/sin at line 146");

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
            	[_t0].[ProductCategoryType]
            FROM
            	[dbo].[Product] AS [_t0]
            WHERE
            	[_t0].[Height] > @P1
            	AND
            	[_t0].[Height] < @P2
            GROUP BY
            	[_t0].[ProductCategoryType],
            	SIN([_t0].[Height])
            HAVING
            	SIN([_t0].[Height]) < @P3;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
            */
        }

    }
}
