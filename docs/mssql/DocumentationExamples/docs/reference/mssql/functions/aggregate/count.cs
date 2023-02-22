using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Aggregate
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/aggregate/count</summary>
    public class Count : IDocumentationExamples
    {
        private readonly ILogger<Count> logger;

        public Count(ILogger<Count> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Count_line_no_46();
            Count_line_no_64();
            Count_line_no_86();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/count at line 46</summary>
        private void Count_line_no_46()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/count at line 46");

            int count = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT TOP(1)
                COUNT([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/count at line 64</summary>
        private void Count_line_no_64()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/count at line 64");

            int count = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Desc())
                .Execute();

            /*
            SELECT TOP(1)
                COUNT([t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [t0]
            ORDER BY
                COUNT([t0].[TotalPurchaseAmount]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/count at line 86</summary>
        private void Count_line_no_86()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/count at line 86");

            IEnumerable<int> counts = db.SelectMany(
                    db.fx.Count()
                )
                .From(dbo.Purchase)
                .GroupBy(dbo.Purchase.PaymentMethodType)
                .Having(db.fx.Count() > 10)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(*)
            FROM
            	[dbo].[Purchase] AS [t0]
            GROUP BY
            	[t0].[PaymentMethodType]
            HAVING
            	COUNT(*) > @P1;',N'@P1 int',@P1=10
            */
        }

    }
}
