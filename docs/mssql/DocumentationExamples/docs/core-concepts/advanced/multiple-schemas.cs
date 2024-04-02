using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
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
                [t0].[Id],
                [t0].[SSN] AS [SocialSecurityNumber],
                [t1].[PurchaseDate],
                [t1].[OrderNumber],
                [t1].[TotalPurchaseAmount]
            FROM
                [sec].[Person] AS [t0]
                INNER JOIN [dbo].[Purchase] AS [t1] ON [t0].[Id] = [t1].[PersonId];
            */
        }

    }
}
