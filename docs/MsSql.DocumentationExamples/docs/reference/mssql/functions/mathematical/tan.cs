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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan</summary>
    public class Tan : IDocumentationExamples
    {
        private readonly ILogger<Tan> logger;

        public Tan(ILogger<Tan> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Tan_line_no_41();
            Tan_line_no_59();
            Tan_line_no_77();
            Tan_line_no_117();
            Tan_line_no_146();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 41</summary>
        private void Tan_line_no_41()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 41");

            float? result = db.SelectOne(
                    db.fx.Tan(dbo.Product.Weight)
                )
                .From(dbo.Product)
                .Execute();

            /*
            SELECT TOP(1)
            	TAN([dbo].[Product].[Weight])
            FROM
            	[dbo].[Product];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 59</summary>
        private void Tan_line_no_59()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 59");

            float? result = db.SelectOne(
                    db.fx.Tan(dbo.Product.Depth)
                )
                .From(dbo.Product)
                .Execute();

            /*
            SELECT TOP(1)
            	TAN([dbo].[Product].[Depth])
            FROM
            	[dbo].[Product];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 77</summary>
        private void Tan_line_no_77()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 77");

            IEnumerable<Product> result = db.SelectMany<Product>()
                .From(dbo.Product)
                .OrderBy(db.fx.Tan(dbo.Product.Depth).Desc())
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
            WHERE
            	[dbo].[Product].[Depth] > @P1
            	AND
            	[dbo].[Product].[Depth] < @P2
            ORDER BY
            	TAN([dbo].[Product].[Depth]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 117</summary>
        private void Tan_line_no_117()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 117");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.Tan(dbo.Product.Depth).As("calculated_value")
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Tan(dbo.Product.Depth)
                )
                .Execute();

            /*
            SELECT
            	[dbo].[Product].[ProductCategoryType],
            	TAN([dbo].[Product].[Depth]) AS [calculated_value]
            FROM
            	[dbo].[Product]
            GROUP BY
            	[dbo].[Product].[ProductCategoryType],
            	TAN([dbo].[Product].[Depth]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 146</summary>
        private void Tan_line_no_146()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/tan at line 146");

            IEnumerable<ProductCategoryType?> results = db.SelectMany(
                    dbo.Product.ProductCategoryType
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Tan(dbo.Product.Height),
                    dbo.Product.Width
                )
                .Having(
                    db.fx.Tan(dbo.Product.Height) > dbo.Product.Width
                )
                .Execute();

            /*
            SELECT
            	[dbo].[Product].[ProductCategoryType]
            FROM
            	[dbo].[Product]
            GROUP BY
            	[dbo].[Product].[ProductCategoryType],
            	TAN([dbo].[Product].[Height])
            HAVING
            	TAN([dbo].[Product].[Height]) > [dbo].[Product].[Width];
            */
        }

    }
}
