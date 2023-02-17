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
            ATan_line_no_64();
            ATan_line_no_87();
            ATan_line_no_123();
            ATan_line_no_151();
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
                ATAN([_t0].[Weight])
            FROM
                [dbo].[Product] AS [_t0]
            WHERE
                [_t0].[Weight] > @P1
                AND
                [_t0].[Weight] < @P2;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 64</summary>
        private void ATan_line_no_64()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 64");

            float? result = db.SelectOne(
                    db.fx.ATan(dbo.Product.Depth)
                )
                .From(dbo.Product)
                .Where(dbo.Product.Depth > 0 & dbo.Product.Depth < 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
                ATAN([_t0].[Depth])
            FROM
                [dbo].[Product] AS [_t0]
            WHERE
                [_t0].[Depth] > @P1
                AND
                [_t0].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 87</summary>
        private void ATan_line_no_87()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 87");

            IEnumerable<Product> result = db.SelectMany<Product>()
                .From(dbo.Product)
                .OrderBy(db.fx.ATan(dbo.Product.Depth).Desc())
                .Execute();

            /*
            ELECT
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
                ATAN([_t0].[Depth]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 123</summary>
        private void ATan_line_no_123()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 123");

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
                [_t0].[ProductCategoryType],
                ATAN([_t0].[Depth]) AS [calculated_value]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                ATAN([_t0].[Depth]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 151</summary>
        private void ATan_line_no_151()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/atan at line 151");

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
                [_t0].[ProductCategoryType]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                ATAN([_t0].[Depth])
            HAVING
                ATAN([_t0].[Depth]) < @P1;',N'@P1 decimal(4,1)',@P1=0.5
            */
        }

    }
}
