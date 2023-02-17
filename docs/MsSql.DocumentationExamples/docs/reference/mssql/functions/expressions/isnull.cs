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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull</summary>
    public class IsNull : IDocumentationExamples
    {
        private readonly ILogger<IsNull> logger;

        public IsNull(ILogger<IsNull> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            IsNull_line_no_56();
            IsNull_line_no_73();
            IsNull_line_no_91();
            IsNull_line_no_124();
            IsNull_line_no_156();
            IsNull_line_no_183();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 56</summary>
        private void IsNull_line_no_56()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 56");

            IEnumerable<DateTime?> result = db.SelectMany(
                    db.fx.IsNull(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate).As("latest_date")
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT
                ISNULL([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate]) AS [latest_date]
            FROM
                [dbo].[Purchase] AS [_t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 73</summary>
        private void IsNull_line_no_73()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 73");

            IEnumerable<DateTime> result = db.SelectMany(
                    db.fx.IsNull(dbo.Purchase.ExpectedDeliveryDate, DateTime.UtcNow).As("latest_date")
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                ISNULL([_t0].[ExpectedDeliveryDate], @P1) AS [latest_date]
            FROM
                [dbo].[Purchase] AS [_t0];',N'@P1 datetime',@P1='2022-09-26 16:51:30.997'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 91</summary>
        private void IsNull_line_no_91()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 91");

            IEnumerable<Purchase> purchases = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .Where(
                    db.fx.IsNull(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate) < DateTime.UtcNow.AddDays(-7)
                )
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
            WHERE
                ISNULL([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate]) < @P1;',N'@P1 datetime',@P1='2022-09-20 16:44:07.717'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 124</summary>
        private void IsNull_line_no_124()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 124");

            IEnumerable<Purchase> products = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .OrderBy(db.fx.IsNull(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate).Desc())
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
                ISNULL([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 156</summary>
        private void IsNull_line_no_156()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 156");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.IsNull(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate).As("relevant_date")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.IsNull(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate)
                )
                .Execute();

            /*
            SELECT
                [_t0].[PaymentMethodType],
                ISNULL([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate]) AS [relevant_date]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                ISNULL([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 183</summary>
        private void IsNull_line_no_183()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/expressions/isnull at line 183");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.IsNull(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate).As("relevant_date")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.ExpectedDeliveryDate,
                    dbo.Purchase.ShipDate
                )
                .Having(
                    db.fx.IsNull(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate) < DateTime.UtcNow.Date.AddDays(-7)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[PaymentMethodType],
                ISNULL([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate]) AS [relevant_date]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                [_t0].[ExpectedDeliveryDate],
                [_t0].[ShipDate]
            HAVING
                ISNULL([_t0].[ExpectedDeliveryDate], [_t0].[ShipDate]) < @P1;',N'@P1 datetime',@P1='2022-09-19 00:00:00'
            */
        }

    }
}
