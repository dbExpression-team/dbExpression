using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Conversion
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/conversion/cast</summary>
    public class Cast : IDocumentationExamples
    {
        private readonly ILogger<Cast> logger;

        public Cast(ILogger<Cast> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Cast_line_no_126();
            Cast_line_no_144();
            Cast_line_no_166();
            Cast_line_no_194();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/conversion/cast at line 126</summary>
        private void Cast_line_no_126()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/conversion/cast at line 126");

            string? result = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.TotalPurchaseAmount).AsVarChar(20)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT TOP(1)
                CAST([_t0].[TotalPurchaseAmount] AS VarChar(20))
            FROM
                [dbo].[Purchase] AS [_t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/conversion/cast at line 144</summary>
        private void Cast_line_no_144()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/conversion/cast at line 144");

            int cast = db.SelectOne(
                    db.fx.Cast(dbo.Address.Zip).AsInt()
                )
                .From(dbo.Address)
                .OrderBy(db.fx.Cast(dbo.Address.Zip).AsInt().Desc())
                .Execute();

            /*
            SELECT TOP(1)
                CAST([_t0].[Zip] AS Int)
            FROM
                [dbo].[Address] AS [_t0]
            ORDER BY
                CAST([_t0].[Zip] AS Int) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/conversion/cast at line 166</summary>
        private void Cast_line_no_166()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/conversion/cast at line 166");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.Cast(dbo.Product.Quantity).AsBigInt().As("Quantity")
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.Cast(dbo.Product.Quantity).AsBigInt()
                )
                .Execute();

            /*
            SELECT
                [_t0].[ProductCategoryType],
                CAST([_t0].[Quantity] AS BigInt) AS [Quantity]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                CAST([_t0].[Quantity] AS BigInt);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/conversion/cast at line 194</summary>
        private void Cast_line_no_194()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/conversion/cast at line 194");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.Cast(dbo.Product.Quantity).AsBigInt().As("Quantity")
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    dbo.Product.Quantity
                )
                .Having(db.fx.Cast(dbo.Product.Quantity).AsBigInt() <= 1_000_000)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[ProductCategoryType],
                CAST([_t0].[Quantity] AS BigInt) AS [Quantity]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                [_t0].[Quantity]
            HAVING
                CAST([_t0].[Quantity] AS BigInt) <= @P1;',N'@P1 bigint',@P1=1000000
            */
        }

    }
}
