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
                COUNT([_t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [_t0];
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
                COUNT([_t0].[TotalPurchaseAmount])
            FROM
                [dbo].[Purchase] AS [_t0]
            ORDER BY
                COUNT([_t0].[TotalPurchaseAmount]) DESC;
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
                COUNT(@P1)
            FROM
                [dbo].[Purchase] AS [_t0]
            GROUP BY
                [_t0].[PaymentMethodType]
            HAVING
                COUNT(@P1) > @P2;',N'@P1 nchar(1),@P2 nchar(1),@P3 int',@P1=N'*',@P2=N'*',@P3=10
            */
        }

    }
}
