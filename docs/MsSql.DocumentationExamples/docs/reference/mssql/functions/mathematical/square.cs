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
            Square_line_no_59();
            Square_line_no_82();
            Square_line_no_118();
            Square_line_no_146();
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
                SQUARE([_t0].[Height])
            FROM
                [dbo].[Product] AS [_t0];',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 59</summary>
        private void Square_line_no_59()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 59");

            IEnumerable<int> results = db.SelectMany(
                    dbo.Product.Id
                )
                .From(dbo.Product)
                .Where(db.fx.Square(dbo.Product.Depth) > 0 & db.fx.Square(dbo.Product.Depth) < 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[Id]
            FROM
                [dbo].[Product] AS [_t0]
            WHERE
                SQUARE([_t0].[Depth]) > @P1
                AND
                SQUARE([_t0].[Depth]) < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 82</summary>
        private void Square_line_no_82()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 82");

            IEnumerable<Product> result = db.SelectMany<Product>()
                .From(dbo.Product)
                .OrderBy(db.fx.Square(dbo.Product.Depth).Desc())
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
                SQUARE([_t0].[Depth]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 118</summary>
        private void Square_line_no_118()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 118");

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
                [_t0].[ProductCategoryType],
                SQUARE([_t0].[Depth]) AS [calculated_value]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                SQUARE([_t0].[Depth]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 146</summary>
        private void Square_line_no_146()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/square at line 146");

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
                [_t0].[ProductCategoryType]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                SQUARE([_t0].[Height])
            HAVING
                SQUARE([_t0].[Height]) < @P1;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
            */
        }

    }
}
