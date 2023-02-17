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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysdatetime</summary>
    public class SysDateTime : IDocumentationExamples
    {
        private readonly ILogger<SysDateTime> logger;

        public SysDateTime(ILogger<SysDateTime> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            SysDateTime_line_no_31();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysdatetime at line 31</summary>
        private void SysDateTime_line_no_31()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/date-and-time/sysdatetime at line 31");

            DateTime current = db.SelectOne(
                    db.fx.SysDateTime()
                )
                .From(dbo.Purchase) // <- "dummy" from clause
                .Execute();

            /*
            SELECT TOP(1)
                SYSDATETIME()
            FROM
                [dbo].[Purchase] AS [_t0];
            */
        }

    }
}
