using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Aliasing
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/aliasing/column</summary>
    public class Column_Aliasing : IDocumentationExamples
    {
        private readonly ILogger<Column_Aliasing> logger;

        public Column_Aliasing(ILogger<Column_Aliasing> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Column_Aliasing_line_no_24();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/aliasing/column at line 24</summary>
        private void Column_Aliasing_line_no_24()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/aliasing/column at line 24");

            IEnumerable<dynamic> purchases = db.SelectMany(
                    dbo.Person.Id.As("PersonId"),
                    dbo.Person.LastName,
                    dbo.Purchase.Id,
                    dbo.Purchase.TotalPurchaseAmount
                )
                .From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .Execute();

            /*
            SELECT
                [t0].[Id] AS [PersonId],
                [t0].[LastName],
                [t1].[Id],
                [t1].[TotalPurchaseAmount]
            FROM
                [dbo].[Purchase] AS [t1]
                INNER JOIN [dbo].[Person] AS [t0] ON [t1].[PersonId] = [t0].[Id];
            */
        }

    }
}
