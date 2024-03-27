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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg</summary>
    public class Avg : IDocumentationExamples
    {
        private readonly ILogger<Avg> logger;

        public Avg(ILogger<Avg> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Avg_line_no_90();
            Avg_line_no_108();
            Avg_line_no_127();
            Avg_line_no_149();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg at line 90</summary>
        private void Avg_line_no_90()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg at line 90");

            double avgSales = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT TOP(1)
                AVG([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg at line 108</summary>
        private void Avg_line_no_108()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg at line 108");

            double avgSales = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct()
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT TOP(1)
                AVG(DISTINCT [t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg at line 127</summary>
        private void Avg_line_no_127()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg at line 127");

            IEnumerable<double> avgSales = db.SelectMany(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .OrderBy(db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Desc())
                .Execute();

            /*
            SELECT
                AVG([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0]
            ORDER BY
                AVG([t0].[TotalPurchaseAmount]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg at line 149</summary>
        private void Avg_line_no_149()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/avg at line 149");

            IEnumerable<double> avgSales = db.SelectMany(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .GroupBy(dbo.Purchase.PaymentMethodType)
                .Having(db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) > 10)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                AVG([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0]
            GROUP BY
                [t0].[PaymentMethodType]
            HAVING
                AVG([t0].[TotalPurchaseAmount]) > @P1;',N'@P1 float',@P1=10
            */
        }

    }
}
