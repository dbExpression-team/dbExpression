using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Basics
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/having</summary>
    public class Having : IDocumentationExamples
    {
        private readonly ILogger<Having> logger;

        public Having(ILogger<Having> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Having_line_no_10();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/having at line 10</summary>
        private void Having_line_no_10()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/having at line 10");

            IEnumerable<dynamic> maxPurchases = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("MaxPurchaseAmt")
                )
                .From(dbo.Person)
                .InnerJoin(dbo.Purchase).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .OrderBy(dbo.Person.LastName)
                .GroupBy(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .Having(
            	    db.fx.Max(dbo.Purchase.TotalPurchaseAmount) >= 18.00
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[Id],
                [_t0].[FirstName],
                [_t0].[LastName],
                MAX([_t1].[TotalPurchaseAmount]) AS [MaxPurchaseAmt]
            FROM
                [dbo].[Person] AS [_t0]
                INNER JOIN [dbo].[Purchase] AS [_t1] ON [_t1].[PersonId] = [_t0].[Id]
            GROUP BY
                [_t0].[Id],
                [_t0].[FirstName],
                [_t0].[LastName]
            HAVING
                MAX([_t1].[TotalPurchaseAmount]) >= @P1
            ORDER BY
                [_t0].[LastName] ASC;',N'@P1 float',@P1=18
            */
        }

    }
}
