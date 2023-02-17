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
                SQRT([_t0].[Height])
            FROM
                [dbo].[Product] AS [_t0];
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
                SQRT([_t0].[Depth])
            FROM
                [dbo].[Product] AS [_t0]
            WHERE
                [_t0].[Depth] > @P1
                AND
                [_t0].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=10.0
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
                SQRT([_t0].[Depth]) DESC;
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
                [_t0].[ProductCategoryType],
                SQRT([_t0].[Depth]) AS [calculated_value]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                SQRT([_t0].[Depth]);
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
                [_t0].[ProductCategoryType]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                SQRT([_t0].[Height])
            HAVING
                SQRT([_t0].[Height]) < @P1;',N'@P1 decimal(4,1),@P2 decimal(4,1),@P3 real',@P1=0.0,@P2=1.0,@P3=0.5
            */
        }

    }
}
