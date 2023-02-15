using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.Date_and_time
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
            	DATEDIFF(day, [dbo].[Purchase].[PurchaseDate], [dbo].[Purchase].[ShipDate])
            FROM
            	[dbo].[Purchase];
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
            	[dbo].[Purchase].[Id]
            FROM
            	[dbo].[Purchase]
            WHERE
            	DATEDIFF(day, [dbo].[Purchase].[PurchaseDate], [dbo].[Purchase].[ShipDate]) < @P1;',N'@P1 int',@P1=7
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
            	[dbo].[Purchase].[Id],
            	[dbo].[Purchase].[PersonId],
            	[dbo].[Purchase].[OrderNumber],
            	[dbo].[Purchase].[TotalPurchaseQuantity],
            	[dbo].[Purchase].[TotalPurchaseAmount],
            	[dbo].[Purchase].[PurchaseDate],
            	[dbo].[Purchase].[ShipDate],
            	[dbo].[Purchase].[ExpectedDeliveryDate],
            	[dbo].[Purchase].[TrackingIdentifier],
            	[dbo].[Purchase].[PaymentMethodType],
            	[dbo].[Purchase].[PaymentSourceType],
            	[dbo].[Purchase].[DateCreated],
            	[dbo].[Purchase].[DateUpdated]
            FROM
            	[dbo].[Purchase]
            ORDER BY
            	DATEDIFF(week, [dbo].[Purchase].[PurchaseDate], [dbo].[Purchase].[ShipDate]) ASC;
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
            	[dbo].[Purchase].[PaymentMethodType],
            	DATEDIFF(week, [dbo].[Purchase].[PurchaseDate], [dbo].[Purchase].[ShipDate]) AS [WeeksBetween]
            FROM
            	[dbo].[Purchase]
            GROUP BY
            	[dbo].[Purchase].[PaymentMethodType],
            	DATEDIFF(week, [dbo].[Purchase].[PurchaseDate], [dbo].[Purchase].[ShipDate]);
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
            	[dbo].[Purchase].[PaymentMethodType],
            	DATEDIFF(day, [dbo].[Purchase].[PurchaseDate], [dbo].[Purchase].[ShipDate]) AS [DaysBetween]
            FROM
            	[dbo].[Purchase]
            GROUP BY
            	[dbo].[Purchase].[PaymentMethodType],
            	DATEDIFF(day, [dbo].[Purchase].[PurchaseDate], [dbo].[Purchase].[ShipDate])
            HAVING
            	DATEDIFF(day, [dbo].[Purchase].[PurchaseDate], [dbo].[Purchase].[ShipDate]) < @P1;',N'@P1 int',@P1=7
            */
        }

    }
}
