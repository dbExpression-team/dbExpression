using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.Date_and_time
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/current-timestamp</summary>
    public class Current_Timestamp : IDocumentationExamples
    {
        private readonly ILogger<Current_Timestamp> logger;

        public Current_Timestamp(ILogger<Current_Timestamp> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Current_Timestamp_line_no_31();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/current-timestamp at line 31</summary>
        private void Current_Timestamp_line_no_31()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/current-timestamp at line 31");

            DateTime current = db.SelectOne(
                    db.fx.Current_Timestamp
                )
                .From(dbo.Purchase) // <- "dummy" from clause
                .Execute();

            /*
            SELECT TOP(1)
                CURRENT_TIMESTAMP
            FROM
                [dbo].[Purchase] AS [_t0];
            */
        }

    }
}
