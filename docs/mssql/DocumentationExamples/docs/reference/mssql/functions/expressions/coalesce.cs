using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Expressions
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce</summary>
    public class Coalesce : IDocumentationExamples
    {
        private readonly ILogger<Coalesce> logger;

        public Coalesce(ILogger<Coalesce> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Coalesce_line_no_149();
            Coalesce_line_no_166();
            Coalesce_line_no_185();
            Coalesce_line_no_205();
            Coalesce_line_no_238();
            Coalesce_line_no_270();
            Coalesce_line_no_297();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 149</summary>
        private void Coalesce_line_no_149()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 149");

            IEnumerable<object?> result = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("latest_date")
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT
                COALESCE([t0].[ExpectedDeliveryDate], [t0].[ShipDate], [t0].[PurchaseDate]) AS [latest_date]
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 166</summary>
        private void Coalesce_line_no_166()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 166");

            IEnumerable<DateTime> result = db.SelectMany(
                    db.fx.Coalesce<DateTime>(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("latest_date")
                )
                .From(dbo.Purchase)
                .Execute();
                // dbo.Purchase.PurchaseDate does not allow nulls, so the last parameter will always return a non-null value
                // therefore, the return can be DateTime, not DateTime?

            /*
            SELECT
                COALESCE([t0].[ExpectedDeliveryDate], [t0].[ShipDate], [t0].[PurchaseDate]) AS [latest_date]
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 185</summary>
        private void Coalesce_line_no_185()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 185");

            object? result = db.SelectOne(
                    db.fx.Coalesce(db.fx.Cast(dbo.Purchase.OrderNumber).AsBigInt(), dbo.Purchase.Id).As("relevant_identifier")
                )
                .From(dbo.Purchase)
                .Execute();
                // dbo.Purchase.OrderNumber is a varchar (string) while
                // dbo.Purchase.Id is an int

            /*
            SELECT TOP(1)
                COALESCE(CAST([t0].[OrderNumber] AS BigInt), [t0].[Id]) AS [relevant_identifier]
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 205</summary>
        private void Coalesce_line_no_205()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 205");

            IEnumerable<Purchase> purchases = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .Where(
                    db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate) < DateTime.UtcNow.AddDays(-7)
                )
                .Execute();

            /*
            exec sp_executesql N'ELECT
                [t0].[Id],
                [t0].[PersonId],
                [t0].[OrderNumber],
                [t0].[TotalPurchaseQuantity],
                [t0].[TotalPurchaseAmount],
                [t0].[PurchaseDate],
                [t0].[ShipDate],
                [t0].[ExpectedDeliveryDate],
                [t0].[TrackingIdentifier],
                [t0].[PaymentMethodType],
                [t0].[PaymentSourceType],
                [t0].[DateCreated],
                [t0].[DateUpdated]
            FROM
                [dbo].[Purchase] AS [t0]
            WHERE
                COALESCE([t0].[ExpectedDeliveryDate], [t0].[ShipDate], [t0].[PurchaseDate]) < @P1;',N'@P1 datetime',@P1='2022-09-20 16:47:54.607'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 238</summary>
        private void Coalesce_line_no_238()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 238");

            IEnumerable<Purchase> products = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc())
                .Execute();

            /*
            SELECT
                [t0].[Id],
                [t0].[PersonId],
                [t0].[OrderNumber],
                [t0].[TotalPurchaseQuantity],
                [t0].[TotalPurchaseAmount],
                [t0].[PurchaseDate],
                [t0].[ShipDate],
                [t0].[ExpectedDeliveryDate],
                [t0].[TrackingIdentifier],
                [t0].[PaymentMethodType],
                [t0].[PaymentSourceType],
                [t0].[DateCreated],
                [t0].[DateUpdated]
            FROM
                [dbo].[Purchase] AS [t0]
            ORDER BY
                COALESCE([t0].[ExpectedDeliveryDate], [t0].[ShipDate], [t0].[PurchaseDate]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 270</summary>
        private void Coalesce_line_no_270()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 270");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                )
                .Execute();

            /*
            SELECT
                [t0].[PaymentMethodType],
                COALESCE([t0].[ExpectedDeliveryDate], [t0].[ShipDate], [t0].[PurchaseDate]) AS [relevant_date]
            FROM
                [dbo].[Purchase] AS [t0]
            GROUP BY
                [t0].[PaymentMethodType],
                COALESCE([t0].[ExpectedDeliveryDate], [t0].[ShipDate], [t0].[PurchaseDate]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 297</summary>
        private void Coalesce_line_no_297()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/coalesce at line 297");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.ExpectedDeliveryDate,
                    dbo.Purchase.ShipDate,
                    dbo.Purchase.PurchaseDate
                )
                .Having(
                    db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate) < DateTime.UtcNow.Date.AddDays(-7)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[PaymentMethodType],
                COALESCE([t0].[ExpectedDeliveryDate], [t0].[ShipDate], [t0].[PurchaseDate]) AS [relevant_date]
            FROM
                [dbo].[Purchase] AS [t0]
            GROUP BY
                [t0].[PaymentMethodType],
                [t0].[ExpectedDeliveryDate],
                [t0].[ShipDate],
                [t0].[PurchaseDate]
            HAVING
                COALESCE([t0].[ExpectedDeliveryDate], [t0].[ShipDate], [t0].[PurchaseDate]) < @P1;',N'@P1 datetime',@P1='2022-09-19 00:00:00'
            */
        }

    }
}
