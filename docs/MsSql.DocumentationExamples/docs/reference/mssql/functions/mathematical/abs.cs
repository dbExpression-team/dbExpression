using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.Mathematical
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs</summary>
    public class Abs : IDocumentationExamples
    {
        private readonly ILogger<Abs> logger;

        public Abs(ILogger<Abs> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Abs_line_no_40();
            Abs_line_no_59();
            Abs_line_no_82();
            Abs_line_no_103();
            Abs_line_no_134();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 40</summary>
        private void Abs_line_no_40()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 40");

            IEnumerable<double> value = db.SelectMany(
                    db.fx.Abs(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT
                ABS([_t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [_t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 59</summary>
        private void Abs_line_no_59()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 59");

            IEnumerable<int> value = db.SelectMany(
                    dbo.Purchase.Id
                )
                .From(dbo.Purchase)
                .Where(
                    db.fx.Abs(dbo.Purchase.TotalPurchaseAmount) != dbo.Purchase.TotalPurchaseAmount
                )
                .Execute();

            /*
            SELECT
                [_t0].[Id]
            FROM
                [dbo].[Purchase] AS [_t0]
            WHERE
                ABS([_t0].[TotalPurchaseAmount]) <> [_t0].[TotalPurchaseAmount];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 82</summary>
        private void Abs_line_no_82()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 82");

            IEnumerable<double> value = db.SelectMany(
                    db.fx.Abs(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .OrderBy(db.fx.Abs(dbo.Purchase.TotalPurchaseAmount).Desc())
                .Execute();

            /*
            SELECT
                ABS([_t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [_t0]
            ORDER BY
                ABS([_t0].[TotalPurchaseAmount]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 103</summary>
        private void Abs_line_no_103()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 103");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Abs(dbo.Purchase.TotalPurchaseAmount).As("TotalPurchaseAmount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Abs(dbo.Purchase.TotalPurchaseAmount)
                )
                .OrderBy(db.fx.Abs(dbo.Purchase.TotalPurchaseAmount))
                .Execute();

            /*
            SELECT
                [_t0].[PaymentMethodType],
                ABS([_t0].[TotalPurchaseAmount]) AS [TotalPurchaseAmount]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                ABS([_t0].[TotalPurchaseAmount])
            ORDER BY
                ABS([_t0].[TotalPurchaseAmount]) ASC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 134</summary>
        private void Abs_line_no_134()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/abs at line 134");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Abs(dbo.Purchase.TotalPurchaseAmount).As("TotalPurchaseAmount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Abs(dbo.Purchase.TotalPurchaseAmount)
                )
                .Having(db.fx.Abs(dbo.Purchase.TotalPurchaseAmount) > 10)
                .OrderBy(db.fx.Abs(dbo.Purchase.TotalPurchaseAmount))
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[PaymentMethodType],
                ABS([_t0].[TotalPurchaseAmount]) AS [TotalPurchaseAmount]
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType],
                ABS([_t0].[TotalPurchaseAmount])
            HAVING
                ABS([_t0].[TotalPurchaseAmount]) > @P1
            ORDER BY
                ABS([_t0].[TotalPurchaseAmount]) ASC;',N'@P1 float',@P1=10
            */
        }

    }
}
