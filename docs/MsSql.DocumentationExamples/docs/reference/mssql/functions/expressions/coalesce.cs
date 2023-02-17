using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.Expressions
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
                COALESCE([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate], [_t0].[PurchaseDate]) AS [latest_date]
            FROM
                [dbo].[Purchase] AS [_t0];
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
                COALESCE([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate], [_t0].[PurchaseDate]) AS [latest_date]
            FROM
                [dbo].[Purchase] AS [_t0];
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
                COALESCE(CAST([_t0].[OrderNumber] AS BigInt), [_t0].[Id]) AS [relevant_identifier]
            FROM
                [dbo].[Purchase] AS [_t0];
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
                [_t0].[Id],
                [_t0].[PersonId],
                [_t0].[OrderNumber],
                [_t0].[TotalPurchaseQuantity],
                [_t0].[TotalPurchaseAmount],
                [_t0].[PurchaseDate],
                [_t0].[ShipDate],
                [_t0].[ExpectedDeliveryDate],
                [_t0].[TrackingIdentifier],
                [_t0].[PaymentMethodType],
                [_t0].[PaymentSourceType],
                [_t0].[DateCreated],
                [_t0].[DateUpdated]
            FROM
                [dbo].[Purchase] AS [_t0]
            WHERE
                COALESCE([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate], [_t0].[PurchaseDate]) < @P1;',N'@P1 datetime',@P1='2022-09-20 16:47:54.607'
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
                [_t0].[Id],
                [_t0].[PersonId],
                [_t0].[OrderNumber],
                [_t0].[TotalPurchaseQuantity],
                [_t0].[TotalPurchaseAmount],
                [_t0].[PurchaseDate],
                [_t0].[ShipDate],
                [_t0].[ExpectedDeliveryDate],
                [_t0].[TrackingIdentifier],
                [_t0].[PaymentMethodType],
                [_t0].[PaymentSourceType],
                [_t0].[DateCreated],
                [_t0].[DateUpdated]
            FROM
                [dbo].[Purchase] AS [_t0]
            ORDER BY
                COALESCE([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate], [_t0].[PurchaseDate]) DESC;
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
                [_t0].[PaymentMethodType],
                COALESCE([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate], [_t0].[PurchaseDate]) AS [relevant_date]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                COALESCE([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate], [_t0].[PurchaseDate]);
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
                [_t0].[PaymentMethodType],
                COALESCE([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate], [_t0].[PurchaseDate]) AS [relevant_date]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                [_t0].[ExpectedDeliveryDate],
                [_t0].[ShipDate],
                [_t0].[PurchaseDate]
            HAVING
                COALESCE([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate], [_t0].[PurchaseDate]) < @P1;',N'@P1 datetime',@P1='2022-09-19 00:00:00'
            */
        }

    }
}
