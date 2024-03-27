using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Mathematical
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot</summary>
    public class Cot : IDocumentationExamples
    {
        private readonly ILogger<Cot> logger;

        public Cot(ILogger<Cot> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Cot_line_no_41();
            Cot_line_no_59();
            Cot_line_no_77();
            Cot_line_no_113();
            Cot_line_no_142();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 41</summary>
        private void Cot_line_no_41()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 41");

            float? result = db.SelectOne(
                    db.fx.Cot(dbo.Product.Weight)
                )
                .From(dbo.Product)
                .Execute();

            /*
            SELECT TOP(1)
                COT([t0].[Weight])
            FROM
                [dbo].[Product] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 59</summary>
        private void Cot_line_no_59()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 59");

            float? result = db.SelectOne(
                    db.fx.Cot(dbo.Product.Depth)
                )
                .From(dbo.Product)
                .Execute();

            /*
            SELECT TOP(1)
                COT([t0].[Depth])
            FROM
                [dbo].[Product] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 77</summary>
        private void Cot_line_no_77()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 77");

            IEnumerable<Product> result = db.SelectMany<Product>()
                .From(dbo.Product)
                .OrderBy(db.fx.Cot(dbo.Product.Depth).Desc())
                .Execute();

            /*
            SELECT
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
                COT([t0].[Depth]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 113</summary>
        private void Cot_line_no_113()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 113");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.Cot(dbo.Product.Depth).As("calculated_value")
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Cot(dbo.Product.Depth)
                )
                .Execute();

            /*
            SELECT
                [t0].[ProductCategoryType],
                COT([t0].[Depth]) AS [calculated_value]
            FROM
                [dbo].[Product] AS [t0]
            GROUP BY
                [t0].[ProductCategoryType],
                COT([t0].[Depth]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 142</summary>
        private void Cot_line_no_142()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/cot at line 142");

            IEnumerable<ProductCategoryType?> results = db.SelectMany(
                    dbo.Product.ProductCategoryType
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Cot(dbo.Product.Height),
                    dbo.Product.Width
                )
                .Having(
                    db.fx.Cot(dbo.Product.Height) > dbo.Product.Width
                )
                .Execute();

            /*
            SELECT
                [t0].[ProductCategoryType]
            FROM
                [dbo].[Product] AS [t0]
            GROUP BY
                [t0].[ProductCategoryType],
                COT([t0].[Height]),
                [t0].[Width]
            HAVING
                COT([t0].[Height]) > [t0].[Width];
            */
        }

    }
}
