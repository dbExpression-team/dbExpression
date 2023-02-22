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
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/delete-statement</summary>
    public class Delete_Statements : IDocumentationExamples
    {
        private readonly ILogger<Delete_Statements> logger;

        public Delete_Statements(ILogger<Delete_Statements> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Delete_Statements_line_no_15();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/delete-statement at line 15</summary>
        private void Delete_Statements_line_no_15()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/delete-statement at line 15");

            int idToDelete = 9;
            
            int affected = db.Delete()
                .From(dbo.Product)
                .Where(dbo.Product.Id == idToDelete)
                .Execute();

            /*
            exec sp_executesql N'DELETE
                [t0]
            FROM
                [dbo].[Product] AS [t0]
            WHERE
                [t0].[Id] = @P1;
            SELECT @@ROWCOUNT;',N'@P1 int',@P1=9
            */
        }

    }
}
