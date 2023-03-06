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
                ATAN([t0].[Weight])
            FROM
                [dbo].[Product] AS [t0]
            WHERE
                [t0].[Weight] > @P1
                AND
                [t0].[Weight] < @P2;
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
                ATAN([t0].[Depth])
            FROM
                [dbo].[Product] AS [t0]
            WHERE
                [t0].[Depth] > @P1
                AND
                [t0].[Depth] < @P2;',N'@P1 decimal(4,1),@P2 decimal(4,1)',@P1=0.0,@P2=1.0
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
                [t0].[Id],
                [t0].[ProductCategoryType],
                [t0].[Name],
                [t0].[Description],
                [t0].[ListPrice],
                [t0].[Price],
                [t0].[Quantity],
                [t0].[Image],
                [t0].[Height],
                [t0].[Width],
                [t0].[Depth],
                [t0].[Weight],
                [t0].[ShippingWeight],
                [t0].[ValidStartTimeOfDayForPurchase],
                [t0].[ValidEndTimeOfDayForPurchase],
                [t0].[DateCreated],
                [t0].[DateUpdated]
            FROM
                [dbo].[Product] AS [t0]
            ORDER BY
                ATAN([t0].[Depth]) DESC;
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
                [t0].[ProductCategoryType],
                ATAN([t0].[Depth]) AS [calculated_value]
            FROM
                [dbo].[Product] AS [t0]
            GROUP BY
                [t0].[ProductCategoryType],
                ATAN([t0].[Depth]);
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
                [t0].[ProductCategoryType]
            FROM
                [dbo].[Product] AS [t0]
            GROUP BY
                [t0].[ProductCategoryType],
                ATAN([t0].[Depth])
            HAVING
                ATAN([t0].[Depth]) < @P1;',N'@P1 decimal(4,1)',@P1=0.5
            */
        }

    }
}
