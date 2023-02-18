using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Date_and_time
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff</summary>
    public class DateDiff : IDocumentationExamples
    {
        private readonly ILogger<DateDiff> logger;

        public DateDiff(ILogger<DateDiff> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            DateDiff_line_no_146();
            DateDiff_line_no_164();
            DateDiff_line_no_185();
            DateDiff_line_no_217();
            DateDiff_line_no_244();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 146</summary>
        private void DateDiff_line_no_146()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 146");

            IEnumerable<int?> result = db.SelectMany(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT
                DATEDIFF(day, [_t0].[PurchaseDate], [_t0].[ShipDate])
            FROM
                [dbo].[Purchase] AS [_t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 164</summary>
        private void DateDiff_line_no_164()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 164");

            IEnumerable<int> result = db.SelectMany(
                    dbo.Purchase.Id
                )
                .From(dbo.Purchase)
                .Where(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate) < 7)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[Id]
            FROM
                [dbo].[Purchase] AS [_t0]
            WHERE
                DATEDIFF(day, [_t0].[PurchaseDate], [_t0].[ShipDate]) < @P1;',N'@P1 int',@P1=7
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 185</summary>
        private void DateDiff_line_no_185()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 185");

            IEnumerable<Purchase> result = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .OrderBy(db.fx.DateDiff(DateParts.Week, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
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
                DATEDIFF(week, [_t0].[PurchaseDate], [_t0].[ShipDate]) ASC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 217</summary>
        private void DateDiff_line_no_217()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 217");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.DateDiff(DateParts.Week, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).As("WeeksBetween")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.DateDiff(DateParts.Week, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                )
                .Execute();

            /*
            SELECT
                [_t0].[PaymentMethodType],
                DATEDIFF(week, [_t0].[PurchaseDate], [_t0].[ShipDate]) AS [WeeksBetween]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                DATEDIFF(week, [_t0].[PurchaseDate], [_t0].[ShipDate]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 244</summary>
        private void DateDiff_line_no_244()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datediff at line 244");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).As("DaysBetween")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                )
                .Having(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate) < 7
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[PaymentMethodType],
                DATEDIFF(day, [_t0].[PurchaseDate], [_t0].[ShipDate]) AS [DaysBetween]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                DATEDIFF(day, [_t0].[PurchaseDate], [_t0].[ShipDate])
            HAVING
                DATEDIFF(day, [_t0].[PurchaseDate], [_t0].[ShipDate]) < @P1;',N'@P1 int',@P1=7
            */
        }

    }
}
