using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.Aggregate
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/aggregate/min</summary>
    public class Min : IDocumentationExamples
    {
        private readonly ILogger<Min> logger;

        public Min(ILogger<Min> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Min_line_no_70();
            Min_line_no_88();
            Min_line_no_110();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/min at line 70</summary>
        private void Min_line_no_70()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/min at line 70");

            double minSales = db.SelectOne(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT TOP(1)
                MIN([_t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [_t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/min at line 88</summary>
        private void Min_line_no_88()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/min at line 88");

            IEnumerable<double> minSales = db.SelectMany(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .OrderBy(db.fx.Min(dbo.Purchase.TotalPurchaseAmount).Desc())
                .Execute();

            /*
            SELECT
                MIN([_t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [_t0]
            ORDER BY
                MIN([_t0].[TotalPurchaseAmount]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/min at line 110</summary>
        private void Min_line_no_110()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/min at line 110");

            IEnumerable<double> minSales = db.SelectMany(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .GroupBy(dbo.Purchase.PaymentMethodType)
                .Having(db.fx.Min(dbo.Purchase.TotalPurchaseAmount) > 10)
                .OrderBy(db.fx.Min(dbo.Purchase.TotalPurchaseAmount))
                .Execute();

            /*
            exec sp_executesql N'SELECT
                MIN([_t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType]
            HAVING
                MIN([_t0].[TotalPurchaseAmount]) > @P1
            ORDER BY
                MIN([_t0].[TotalPurchaseAmount]) ASC;',N'@P1 float',@P1=10
            */
        }

    }
}
