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
            	DATEADD(year, @P1, [dbo].[Purchase].[ShipDate])
            FROM
            	[dbo].[Purchase];',N'@P1 int',@P1=1
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
            	[dbo].[Purchase].[Id]
            FROM
            	[dbo].[Purchase]
            WHERE
            	DATEADD(day, @P1, [dbo].[Purchase].[ShipDate]) > [dbo].[Purchase].[PurchaseDate];',N'@P1 int',@P1=-15
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
            	DATEADD(week, @P1, [dbo].[Purchase].[ShipDate]) ASC;',N'@P1 int',@P1=1
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
            	[dbo].[Product].[ProductCategoryType],
            	DATEADD(week, @P1, [dbo].[Product].[DateCreated]) AS [NewDateCreated]
            FROM
            	[dbo].[Product]
            GROUP BY
            	[dbo].[Product].[ProductCategoryType],
            	DATEADD(week, @P1, [dbo].[Product].[DateCreated]);',N'@P1 int',@P1=1
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
            	[dbo].[Purchase].[PaymentMethodType],
            	[dbo].[Purchase].[ShipDate]
            FROM
            	[dbo].[Purchase]
            GROUP BY
            	[dbo].[Purchase].[PaymentMethodType],
            	[dbo].[Purchase].[ShipDate]
            HAVING
            	DATEADD(week, @P1, [dbo].[Purchase].[ShipDate]) > @P2;',N'@P1 int,@P2 datetime',@P1=1,@P2='2022-09-25 15:37:50.877'
            */
        }

    }
}
