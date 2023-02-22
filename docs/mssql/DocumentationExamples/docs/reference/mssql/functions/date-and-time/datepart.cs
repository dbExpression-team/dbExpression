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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart</summary>
    public class DatePart : IDocumentationExamples
    {
        private readonly ILogger<DatePart> logger;

        public DatePart(ILogger<DatePart> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            DatePart_line_no_103();
            DatePart_line_no_121();
            DatePart_line_no_142();
            DatePart_line_no_174();
            DatePart_line_no_201();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 103</summary>
        private void DatePart_line_no_103()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 103");

            IEnumerable<int?> result = db.SelectMany(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT
                DATEPART(year, [t0].[ShipDate])
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 121</summary>
        private void DatePart_line_no_121()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 121");

            IEnumerable<int> purchase_ids = db.SelectMany(
                    dbo.Purchase.Id
                )
                .From(dbo.Purchase)
                .Where(db.fx.DatePart(DateParts.Weekday, dbo.Purchase.ShipDate) == 6)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[Id]
            FROM
                [dbo].[Purchase] AS [t0]
            WHERE
                DATEPART(weekday, [t0].[ShipDate]) = @P1;',N'@P1 int',@P1=6
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 142</summary>
        private void DatePart_line_no_142()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 142");

            IEnumerable<Purchase> result = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .OrderBy(db.fx.DatePart(DateParts.Week, dbo.Purchase.ShipDate))
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
                DATEPART(week, [t0].[ShipDate]) ASC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 174</summary>
        private void DatePart_line_no_174()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 174");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.DatePart(DateParts.Week, dbo.Product.DateCreated).As("Week")
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.DatePart(DateParts.Week, dbo.Product.DateCreated)
                )
                .Execute();

            /*
            SELECT
                [t0].[ProductCategoryType],
                DATEPART(week, [t0].[DateCreated]) AS [Week]
            FROM
                [dbo].[Product] AS [t0]
            GROUP BY
                [t0].[ProductCategoryType],
                DATEPART(week, [t0].[DateCreated]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 201</summary>
        private void DatePart_line_no_201()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/datepart at line 201");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.ShipDate
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.ShipDate
                )
                .Having(
                    db.fx.DatePart(DateParts.Week, dbo.Purchase.ShipDate) == 1
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[PaymentMethodType],
                [t0].[ShipDate]
            FROM
                [dbo].[Purchase] AS [t0]
            GROUP BY
                [t0].[PaymentMethodType],
                [t0].[ShipDate]
            HAVING
                DATEPART(week, [t0].[ShipDate]) = @P1;',N'@P1 int',@P1=1
            */
        }

    }
}
