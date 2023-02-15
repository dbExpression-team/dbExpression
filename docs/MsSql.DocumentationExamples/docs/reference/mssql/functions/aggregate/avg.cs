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
            SELECT
            	AVG([dbo].[Purchase].[TotalPurchaseAmount])
            FROM
            	[dbo].[Purchase];
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
            SELECT
            	DISTINCT AVG([dbo].[Purchase].[TotalPurchaseAmount])
            FROM
            	[dbo].[Purchase];
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
            	AVG([dbo].[Purchase].[TotalPurchaseAmount])
            FROM
            	[dbo].[Purchase]
            ORDER BY
            	AVG([dbo].[Purchase].[TotalPurchaseAmount]) DESC;
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
            	AVG([dbo].[Purchase].[TotalPurchaseAmount])
            FROM
            	[dbo].[Purchase]
            GROUP BY
            	[dbo].[Purchase].[PaymentMethodType]
            HAVING
            	AVG([dbo].[Purchase].[TotalPurchaseAmount]) > @P1;',N'@P1 float',@P1=10
            */
        }

    }
}
