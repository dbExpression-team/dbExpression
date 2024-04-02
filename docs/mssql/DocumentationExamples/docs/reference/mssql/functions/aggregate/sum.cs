using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Aggregate
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/aggregate/sum</summary>
    public class Sum : IDocumentationExamples
    {
        private readonly ILogger<Sum> logger;

        public Sum(ILogger<Sum> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Sum_line_no_91();
            Sum_line_no_109();
            Sum_line_no_131();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/sum at line 91</summary>
        private void Sum_line_no_91()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/sum at line 91");

            double minSales = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT TOP(1)
                SUM([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/sum at line 109</summary>
        private void Sum_line_no_109()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/sum at line 109");

            IEnumerable<double> minSales = db.SelectMany(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).Desc())
                .Execute();

            /*
            SELECT
                SUM([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0]
            ORDER BY
                SUM([t0].[TotalPurchaseAmount]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/sum at line 131</summary>
        private void Sum_line_no_131()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/sum at line 131");

            IEnumerable<double> minSales = db.SelectMany(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .GroupBy(dbo.Purchase.PaymentMethodType)
                .Having(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount) > 10)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount))
                .Execute();

            /*
            exec sp_executesql N'SELECT
                SUM([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0]
            GROUP BY
                [t0].[PaymentMethodType]
            HAVING
                SUM([t0].[TotalPurchaseAmount]) > @P1
            ORDER BY
                SUM([t0].[TotalPurchaseAmount]) ASC;',N'@P1 float',@P1=10
            */
        }

    }
}
