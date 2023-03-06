using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Advanced
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/advanced/subqueries</summary>
    public class Subqueries : IDocumentationExamples
    {
        private readonly ILogger<Subqueries> logger;

        public Subqueries(ILogger<Subqueries> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Subqueries_line_no_14();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/subqueries at line 14</summary>
        private void Subqueries_line_no_14()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/subqueries at line 14");

            IEnumerable<dynamic> vips = db.SelectMany(
            	dbo.Person.Id,
            	dbo.Person.FirstName,
            	dbo.Person.LastName,
            	dbex.Alias("t0", "TotalPurchase")
            	)
            .From(dbo.Person)
            .InnerJoin(
            	db.SelectMany(
            	    dbo.Purchase.PersonId,
            	    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("TotalPurchase")
            	)
            	.Top(100)
            	.From(dbo.Purchase)
            	.GroupBy(dbo.Purchase.PersonId)
            	.Having(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount) > 25)
            	.OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).Desc())
            ).As("t0")
            .On(dbex.Alias("t0", "PersonId") == dbo.Person.Id)
            .Execute();

            /*
            exec sp_executesql N'SELECT
            	[t0].[Id],
            	[t0].[FirstName],
            	[t0].[LastName],
            	[t0].[TotalPurchase]
            FROM
            	[dbo].[Person] AS [t0]
            	INNER JOIN (
            		SELECT TOP(100)
            			[t1].[PersonId],
            			SUM([t1].[TotalPurchaseAmount]) AS [TotalPurchase]
            		FROM
            			[dbo].[Purchase] AS [t1]
            		GROUP BY
            			[t1].[PersonId]
            		HAVING
            			SUM([t1].[TotalPurchaseAmount]) > @P1
            		ORDER BY
            			SUM([t1].[TotalPurchaseAmount]) DESC
            	) AS [t0] ON [t0].[PersonId] = [t0].[Id];',N'@P1 float',@P1=25
            */
        }

    }
}
