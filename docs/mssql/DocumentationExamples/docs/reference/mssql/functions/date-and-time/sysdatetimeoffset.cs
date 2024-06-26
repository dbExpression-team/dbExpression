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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysdatetimeoffset</summary>
    public class SysDateTimeOffset : IDocumentationExamples
    {
        private readonly ILogger<SysDateTimeOffset> logger;

        public SysDateTimeOffset(ILogger<SysDateTimeOffset> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            SysDateTimeOffset_line_no_31();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysdatetimeoffset at line 31</summary>
        private void SysDateTimeOffset_line_no_31()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysdatetimeoffset at line 31");

            DateTimeOffset current = db.SelectOne(
                    db.fx.SysDateTimeOffset()
                )
                .From(dbo.Purchase) // <- "dummy" from clause
                .Execute();

            /*
            SELECT TOP(1)
                SYSDATETIMEOFFSET()
            FROM
                [dbo].[Purchase] AS [t0];
            */
        }

    }
}
