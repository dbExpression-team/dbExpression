using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.System
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/system/newid</summary>
    public class NewId : IDocumentationExamples
    {
        private readonly ILogger<NewId> logger;

        public NewId(ILogger<NewId> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            NewId_line_no_31();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/system/newid at line 31</summary>
        private void NewId_line_no_31()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/system/newid at line 31");

            Guid id = db.SelectOne(
                    db.fx.NewId()
                )
                .From(dbo.Purchase) // <- "dummy" from clause
                .Execute();

            /*
            SELECT TOP(1)
            	NEWID()
            FROM
            	[dbo].[Purchase];
            */
        }

    }
}
