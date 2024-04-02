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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysutcdatetime</summary>
    public class SysUtcDate : IDocumentationExamples
    {
        private readonly ILogger<SysUtcDate> logger;

        public SysUtcDate(ILogger<SysUtcDate> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            SysUtcDate_line_no_31();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysutcdatetime at line 31</summary>
        private void SysUtcDate_line_no_31()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysutcdatetime at line 31");

            DateTime current = db.SelectOne(
                    db.fx.SysUtcDateTime()
                )
                .From(dbo.Purchase) // <- "dummy" from clause
                .Execute();

            /*
            SELECT TOP(1)
                SYSUTCDATETIME()
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

    }
}
