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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/aggregate/max</summary>
    public class Max : IDocumentationExamples
    {
        private readonly ILogger<Max> logger;

        public Max(ILogger<Max> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Max_line_no_71();
            Max_line_no_89();
            Max_line_no_111();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/max at line 71</summary>
        private void Max_line_no_71()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/max at line 71");

            double minSales = db.SelectOne(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT TOP(1)
                MAX([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/max at line 89</summary>
        private void Max_line_no_89()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/max at line 89");

            IEnumerable<double> minSales = db.SelectMany(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .OrderBy(db.fx.Max(dbo.Purchase.TotalPurchaseAmount).Desc())
                .Execute();

            /*
            SELECT
                MAX([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0]
            ORDER BY
                MAX([t0].[TotalPurchaseAmount]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/max at line 111</summary>
        private void Max_line_no_111()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/max at line 111");

            IEnumerable<double> minSales = db.SelectMany(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .GroupBy(dbo.Purchase.PaymentMethodType)
                .Having(db.fx.Max(dbo.Purchase.TotalPurchaseAmount) > 10)
                .OrderBy(db.fx.Max(dbo.Purchase.TotalPurchaseAmount))
                .Execute();

            /*
            exec sp_executesql N'SELECT
                MAX([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0]
            GROUP BY
                [t0].[PaymentMethodType]
            HAVING
                MAX([t0].[TotalPurchaseAmount]) > @P1
            ORDER BY
                MAX([t0].[TotalPurchaseAmount]) ASC;',N'@P1 float',@P1=10
            */
        }

    }
}
