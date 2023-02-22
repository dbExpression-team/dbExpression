using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Basics
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
                [t0].[Id],
                [t0].[FirstName],
                [t0].[LastName],
                MAX([t1].[TotalPurchaseAmount]) AS [MaxPurchaseAmt]
            FROM
                [dbo].[Person] AS [t0]
                INNER JOIN [dbo].[Purchase] AS [t1] ON [t1].[PersonId] = [t0].[Id]
            GROUP BY
                [t0].[Id],
                [t0].[FirstName],
                [t0].[LastName]
            HAVING
                MAX([t1].[TotalPurchaseAmount]) >= @P1
            ORDER BY
                [t0].[LastName] ASC;',N'@P1 float',@P1=18
            */
        }

    }
}
