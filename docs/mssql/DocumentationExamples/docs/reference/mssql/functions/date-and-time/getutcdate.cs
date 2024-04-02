using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Date_and_time
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/getutcdate</summary>
    public class GetUtcDate : IDocumentationExamples
    {
        private readonly ILogger<GetUtcDate> logger;

        public GetUtcDate(ILogger<GetUtcDate> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            GetUtcDate_line_no_31();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/getutcdate at line 31</summary>
        private void GetUtcDate_line_no_31()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/getutcdate at line 31");

            DateTime current = db.SelectOne(
                    db.fx.GetUtcDate()
                )
                .From(dbo.Purchase) // <- "dummy" from clause
                .Execute();

            /*
            SELECT TOP(1)
                GETUTCDATE()
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

    }
}
