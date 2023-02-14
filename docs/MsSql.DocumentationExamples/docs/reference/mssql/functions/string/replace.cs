using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.String
{
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/replace</summary>
	public class Replace : IDocumentationExamples
	{
		private readonly ILogger<Replace> logger;

		public Replace(ILogger<Replace> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Replace_line_no_71();
			Replace_line_no_89();
			Replace_line_no_112();
			Replace_line_no_141();
			Replace_line_no_168();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 71</summary>
		private void Replace_line_no_71()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 71");

			IEnumerable<string> result = db.SelectMany(
			        db.fx.Replace(dbo.Address.Line1, "St.", "Ave.")
				)
				.From(dbo.Address)
				.Execute();

			/*
			exec sp_executesql N'SELECT
				REPLACE([dbo].[Address].[Line1], @P1, @P2)
			FROM
				[dbo].[Address];',N'@P1 char(3),@P2 char(4)',@P1='St.',@P2='Ave.'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 89</summary>
		private void Replace_line_no_89()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 89");

			IEnumerable<dynamic> result = db.SelectMany(
			        dbo.Product.Id,
			        dbo.Product.Name
			    )
			    .From(dbo.Product)
			    .Where(db.fx.Replace(dbo.Product.Name, "Player", "Play") != dbo.Product.Name)
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Product].[Id],
				[dbo].[Product].[Name]
			FROM
				[dbo].[Product]
			WHERE
				REPLACE([dbo].[Product].[Name], @P1, @P2) <> [dbo].[Product].[Name];',N'@P1 char(6),@P2 char(4)',@P1='Player',@P2='Play'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 112</summary>
		private void Replace_line_no_112()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 112");

			IEnumerable<Person> persons = db.SelectMany<Person>()
			    .From(dbo.Person)
			    .OrderBy(db.fx.Replace(dbo.Person.LastName, "Mr. ", ""))
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Person].[Id],
				[dbo].[Person].[FirstName],
				[dbo].[Person].[LastName],
				[dbo].[Person].[BirthDate],
				[dbo].[Person].[GenderType],
				[dbo].[Person].[CreditLimit],
				[dbo].[Person].[YearOfLastCreditLimitReview],
				[dbo].[Person].[RegistrationDate],
				[dbo].[Person].[LastLoginDate],
				[dbo].[Person].[DateCreated],
				[dbo].[Person].[DateUpdated]
			FROM
				[dbo].[Person]
			ORDER BY
				REPLACE([dbo].[Person].[LastName], @P1, @P2) ASC;',N'@P1 char(4),@P2 varchar(1)',@P1='Mr. ',@P2=''
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 141</summary>
		private void Replace_line_no_141()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 141");

			IEnumerable<dynamic> values = db.SelectMany(
			        db.fx.Count().As("count"),
			        dbo.Product.Name
			    )
			    .From(dbo.Product)
			    .GroupBy(
			        dbo.Product.Name,
			        db.fx.Replace(dbo.Product.Name, "Player", "Play")
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				COUNT(@P1) AS [count],
				[dbo].[Product].[Name]
			FROM
				[dbo].[Product]
			GROUP BY
				[dbo].[Product].[Name],
				REPLACE([dbo].[Product].[Name], @P2, @P3);',N'@P1 nchar(1),@P2 char(6),@P3 char(4)',@P1=N'*',@P2='Player',@P3='Play'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 168</summary>
		private void Replace_line_no_168()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/replace at line 168");

			IEnumerable<dynamic> values = db.SelectMany(
			        db.fx.Count().As("count"),
			        dbo.Product.Name
			    )
			    .From(dbo.Product)
			    .GroupBy(dbo.Product.Name)
			    .Having(
			        db.fx.Replace(dbo.Product.Name, "Play", "Player") != dbo.Product.Name
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				COUNT(@P1) AS [count],
				[dbo].[Product].[Name]
			FROM
				[dbo].[Product]
			GROUP BY
				[dbo].[Product].[Name]
			HAVING
				REPLACE([dbo].[Product].[Name], @P2, @P3) <> [dbo].[Product].[Name];',N'@P1 nchar(1),@P2 char(4),@P3 char(6)',@P1=N'*',@P2='Play',@P3='Player'
			*/
		}

	}
}
