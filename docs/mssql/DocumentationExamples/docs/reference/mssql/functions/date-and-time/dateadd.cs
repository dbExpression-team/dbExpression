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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd</summary>
    public class DateAdd : IDocumentationExamples
    {
        private readonly ILogger<DateAdd> logger;

        public DateAdd(ILogger<DateAdd> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            DateAdd_line_no_134();
            DateAdd_line_no_152();
            DateAdd_line_no_173();
            DateAdd_line_no_205();
            DateAdd_line_no_232();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 134</summary>
        private void DateAdd_line_no_134()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 134");

            IEnumerable<DateTime?> result = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                DATEADD(year, @P1, [_t0].[ShipDate])
            FROM
                [dbo].[Purchase] AS [_t0];',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 152</summary>
        private void DateAdd_line_no_152()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 152");

            IEnumerable<int> result = db.SelectMany(
                    dbo.Purchase.Id
                )
                .From(dbo.Purchase)
                .Where(db.fx.DateAdd(DateParts.Day, -15, dbo.Purchase.ShipDate) > dbo.Purchase.PurchaseDate)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[Id]
            FROM
                [dbo].[Purchase] AS [_t0]
            WHERE
                DATEADD(day, @P1, [_t0].[ShipDate]) > [_t0].[PurchaseDate];',N'@P1 int',@P1=-15
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 173</summary>
        private void DateAdd_line_no_173()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 173");

            IEnumerable<Purchase> result = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Week, 1, dbo.Purchase.ShipDate))
                .Execute();

            /*
            exec sp_executesql N'SELECT
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
                DATEADD(week, @P1, [_t0].[ShipDate]) ASC;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 205</summary>
        private void DateAdd_line_no_205()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 205");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.DateAdd(DateParts.Week, 1, dbo.Product.DateCreated).As("NewDateCreated")
                )
                .From(dbo.Product)
                .GroupBy(
                    dbo.Product.ProductCategoryType,
                    db.fx.DateAdd(DateParts.Week, 1, dbo.Product.DateCreated)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[ProductCategoryType],
                DATEADD(week, @P1, [_t0].[DateCreated]) AS [NewDateCreated]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType],
                DATEADD(week, @P1, [_t0].[DateCreated]);',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 232</summary>
        private void DateAdd_line_no_232()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/dateadd at line 232");

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
                    db.fx.DateAdd(DateParts.Week, 1, dbo.Purchase.ShipDate) > DateTime.Now
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[PaymentMethodType],
                [_t0].[ShipDate]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                [_t0].[ShipDate]
            HAVING
                DATEADD(week, @P1, [_t0].[ShipDate]) > @P2;',N'@P1 int,@P2 datetime',@P1=1,@P2='2022-09-25 15:37:50.877'
            */
        }

    }
}
