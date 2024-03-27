using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Mathematical
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
                ABS([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0];
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
                [t0].[Id]
            FROM
                [dbo].[Purchase] AS [t0]
            WHERE
                ABS([t0].[TotalPurchaseAmount]) <> [t0].[TotalPurchaseAmount];
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
                ABS([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0]
            ORDER BY
                ABS([t0].[TotalPurchaseAmount]) DESC;
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
                [t0].[PaymentMethodType],
                ABS([t0].[TotalPurchaseAmount]) AS [TotalPurchaseAmount]
            FROM
                [dbo].[Purchase] AS [t0]
            GROUP BY
                [t0].[PaymentMethodType],
                ABS([t0].[TotalPurchaseAmount])
            ORDER BY
                ABS([t0].[TotalPurchaseAmount]) ASC;
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
                [t0].[PaymentMethodType],
                ABS([t0].[TotalPurchaseAmount]) AS [TotalPurchaseAmount]
            FROM
                [dbo].[Purchase] AS [t0]
            GROUP BY
                [t0].[PaymentMethodType],
                ABS([t0].[TotalPurchaseAmount])
            HAVING
                ABS([t0].[TotalPurchaseAmount]) > @P1
            ORDER BY
                ABS([t0].[TotalPurchaseAmount]) ASC;',N'@P1 float',@P1=10
            */
        }

    }
}
