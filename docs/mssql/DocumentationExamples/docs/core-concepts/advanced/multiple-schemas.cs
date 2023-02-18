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
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/advanced/multiple-schemas</summary>
    public class Multiple_Schemas : IDocumentationExamples
    {
        private readonly ILogger<Multiple_Schemas> logger;

        public Multiple_Schemas(ILogger<Multiple_Schemas> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Multiple_Schemas_line_no_10();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/multiple-schemas at line 10</summary>
        private void Multiple_Schemas_line_no_10()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/multiple-schemas at line 10");

            IEnumerable<dynamic> purchases = db.SelectMany(
                    sec.Person.Id,
                    sec.Person.SocialSecurityNumber,
                    dbo.Purchase.PurchaseDate,
                    dbo.Purchase.OrderNumber,
                    dbo.Purchase.TotalPurchaseAmount
                )
                .From(sec.Person)
                .InnerJoin(dbo.Purchase).On(sec.Person.Id == dbo.Purchase.PersonId)
                .Execute();

            /*
            SELECT
                [_t0].[Id],
                [_t0].[SSN] AS [SocialSecurityNumber],
                [_t1].[PurchaseDate],
                [_t1].[OrderNumber],
                [_t1].[TotalPurchaseAmount]
            FROM
                [sec].[Person] AS [_t0]
                INNER JOIN [dbo].[Purchase] AS [_t1] ON [_t0].[Id] = [_t1].[PersonId];
            */
        }

    }
}
