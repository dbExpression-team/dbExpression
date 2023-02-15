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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/mathematical/round</summary>
    public class Round : IDocumentationExamples
    {
        private readonly ILogger<Round> logger;

        public Round(ILogger<Round> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Round_line_no_203();
            Round_line_no_221();
            Round_line_no_242();
            Round_line_no_263();
            Round_line_no_291();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 203</summary>
        private void Round_line_no_203()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 203");

            IEnumerable<double> value = db.SelectMany(
                    db.fx.Round(dbo.Purchase.TotalPurchaseAmount, 0)
                )
                .From(dbo.Purchase)
                .Execute();

            /*
            SELECT
            	ROUND([dbo].[Purchase].[TotalPurchaseAmount])
            FROM
            	[dbo].[Purchase];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 221</summary>
        private void Round_line_no_221()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 221");

            IEnumerable<int> value = db.SelectMany(
                    dbo.Purchase.Id
                )
                .From(dbo.Purchase)
                .Where(db.fx.Round(dbo.Purchase.TotalPurchaseAmount, -1) == 100)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Purchase].[Id]
            FROM
            	[dbo].[Purchase]
            WHERE
            	ROUND([dbo].[Purchase].[TotalPurchaseAmount], @P1) = @P2;',N'@P1 int,@P2 float',@P1=-1,@P2=100
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 242</summary>
        private void Round_line_no_242()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 242");

            IEnumerable<double> value = db.SelectMany(
                    dbo.Purchase.TotalPurchaseAmount
                )
                .From(dbo.Purchase)
                .OrderBy(db.fx.Round(dbo.Purchase.TotalPurchaseAmount, 1).Desc())
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Purchase].[TotalPurchaseAmount]
            FROM
            	[dbo].[Purchase]
            ORDER BY
            	ROUND([dbo].[Purchase].[TotalPurchaseAmount], @P1) DESC;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 263</summary>
        private void Round_line_no_263()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 263");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Round(dbo.Purchase.TotalPurchaseAmount, 2).As("TotalPurchaseAmount")
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    db.fx.Round(dbo.Purchase.TotalPurchaseAmount, 2)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Purchase].[PaymentMethodType],
            	ROUND([dbo].[Purchase].[TotalPurchaseAmount], @P1) AS [TotalPurchaseAmount]
            FROM
            	[dbo].[Purchase]
            GROUP BY
            	[dbo].[Purchase].[PaymentMethodType],
            	ROUND([dbo].[Purchase].[TotalPurchaseAmount], @P1);',N'@P1 int',@P1=2
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 291</summary>
        private void Round_line_no_291()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/mathematical/round at line 291");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.TotalPurchaseAmount
                )
                .From(dbo.Purchase)
                .GroupBy(
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.TotalPurchaseAmount
                )
                .Having(db.fx.Round(dbo.Purchase.TotalPurchaseAmount, 2) > 10)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Purchase].[PaymentMethodType],
            	[dbo].[Purchase].[TotalPurchaseAmount]
            FROM
            	[dbo].[Purchase]
            GROUP BY
            	[dbo].[Purchase].[PaymentMethodType],
            	[dbo].[Purchase].[TotalPurchaseAmount]
            HAVING
            	ROUND([dbo].[Purchase].[TotalPurchaseAmount], @P1) > @P2;',N'@P1 int,@P2 float',@P1=2,@P2=10
            */
        }

    }
}
