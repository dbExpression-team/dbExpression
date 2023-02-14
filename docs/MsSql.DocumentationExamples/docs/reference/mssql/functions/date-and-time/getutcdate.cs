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
				[dbo].[Purchase];
			*/
		}

	}
}
