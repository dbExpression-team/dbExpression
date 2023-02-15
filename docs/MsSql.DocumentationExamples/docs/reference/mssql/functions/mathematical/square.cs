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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/square</summary>
    public class Square : IDocumentationExamples
    {
        private readonly ILogger<Square> logger;

        public Square(ILogger<Square> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Square_line_no_41();
            Square_line_no_63();
            Square_line_no_86();
            Square_line_no_122();
            Square_line_no_150();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 41</summary>
        private void Square_line_no_41()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 41");

            float? result = db.SelectOne(
                    db.fx.Square(dbo.Product.Height)
                )
                .From(dbo.Product)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
            	SQUARE([dbo].[Product].[Height])
            FROM
            	[dbo].[Product]
            WHERE
            	[dbo].[Product].[Height] > @P1
            	AND
            	[dbo].[Product].[Height] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 63</summary>
        private void Square_line_no_63()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 63");

            IEnumerable<int> results = db.SelectMany(
                    dbo.Product.Id
                )
                .From(dbo.Product)
                .Where(db.fx.Square(dbo.Product.Depth) > 0 & db.fx.Square(dbo.Product.Depth) < 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
            	[dbo].[Product].[Id]
            FROM
            	[dbo].[Product]
            WHERE
            	[dbo].[Product].[Depth] > @P1
            	AND
            	[dbo].[Product].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 86</summary>
        private void Square_line_no_86()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 86");

            IEnumerable<Product> result = db.SelectMany<Product>()
                .From(dbo.Product)
                .OrderBy(db.fx.Square(dbo.Product.Depth).Desc())
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
            	SQUARE([dbo].[Product].[Depth]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 122</summary>
        private void Square_line_no_122()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 122");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.Square(dbo.Product.Depth).As("calculated_value")
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Square(dbo.Product.Depth)
                )
                .Execute();

            /*
            SELECT
            	[dbo].[Product].[ProductCategoryType],
            	SQUARE([dbo].[Product].[Depth]) AS [calculated_value]
            FROM
            	[dbo].[Product]
            GROUP BY
            	[dbo].[Product].[ProductCategoryType],
            	SQUARE([dbo].[Product].[Depth]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 150</summary>
        private void Square_line_no_150()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 150");

            IEnumerable<ProductCategoryType?> results = db.SelectMany(
                    dbo.Product.ProductCategoryType
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Square(dbo.Product.Height)
                )
                .Having(
                    db.fx.Square(dbo.Product.Height) < .5f
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Product].[ProductCategoryType]
            FROM
            	[dbo].[Product]
            GROUP BY
            	[dbo].[Product].[ProductCategoryType],
            	SQUARE([dbo].[Product].[Height])
            HAVING
            	SQUARE([dbo].[Product].[Height]) < @P3;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
            */
        }

    }
}
