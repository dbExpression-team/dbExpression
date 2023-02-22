using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Date_and_time
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/getdate</summary>
    public class GetDate : IDocumentationExamples
    {
        private readonly ILogger<GetDate> logger;

        public GetDate(ILogger<GetDate> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            GetDate_line_no_31();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/getdate at line 31</summary>
        private void GetDate_line_no_31()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/getdate at line 31");

            DateTime current = db.SelectOne(
                    db.fx.GetDate()
                )
                .From(dbo.Purchase) // <- "dummy" from clause
                .Execute();

            /*
            SELECT TOP(1)
                GETDATE()
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

    }
}
