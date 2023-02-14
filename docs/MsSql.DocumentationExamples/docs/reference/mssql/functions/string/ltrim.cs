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
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/ltrim</summary>
	public class LTrim : IDocumentationExamples
	{
		private readonly ILogger<LTrim> logger;

		public LTrim(ILogger<LTrim> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			LTrim_line_no_42();
			LTrim_line_no_60();
			LTrim_line_no_89();
			LTrim_line_no_118();
			LTrim_line_no_146();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 42</summary>
		private void LTrim_line_no_42()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 42");

			IEnumerable<string> result = db.SelectMany(
					db.fx.LTrim(dbo.Person.LastName)
				)
				.From(dbo.Person)
				.Execute();

			/*
			SELECT
				LTRIM([dbo].[Person].[LastName])
			FROM
				[dbo].[Person];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 60</summary>
		private void LTrim_line_no_60()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 60");

			IEnumerable<Person> result = db.SelectMany<Person>()
			    .From(dbo.Person)
				.Where(db.fx.LTrim(dbo.Person.LastName) != dbo.Person.LastName)
				.Execute();

			/*
			SELECT
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
			WHERE
				LTRIM([dbo].[Person].[LastName]) <> [dbo].[Person].[LastName];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 89</summary>
		private void LTrim_line_no_89()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 89");

			IEnumerable<Person> result = db.SelectMany<Person>()
				.From(dbo.Person)
				.OrderBy(db.fx.LTrim(dbo.Person.LastName))
				.Execute();

			/*
			SELECT
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
				LTRIM([dbo].[Person].[LastName]) ASC;
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 118</summary>
		private void LTrim_line_no_118()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 118");

			IEnumerable<dynamic> values = db.SelectMany(
					dbo.Address.AddressType,
					db.fx.LTrim(dbo.Address.City).As("city")
				)
				.From(dbo.Address)
				.GroupBy(
					dbo.Address.AddressType,
					db.fx.LTrim(dbo.Address.City)
				)
				.Execute();

			/*
			SELECT
				[dbo].[Address].[AddressType],
				LTRIM([dbo].[Address].[City]) AS [city]
			FROM
				[dbo].[Address]
			GROUP BY
				[dbo].[Address].[AddressType],
				LTRIM([dbo].[Address].[City]);
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 146</summary>
		private void LTrim_line_no_146()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/ltrim at line 146");

			IEnumerable<dynamic> addresses = db.SelectMany(
					db.fx.Count().As("count"),
					dbo.Address.AddressType
				)
				.From(dbo.Address)
				.GroupBy(
					dbo.Address.AddressType,
					dbo.Address.City
				)
				.Having(
					db.fx.LTrim(dbo.Address.City) == "Chicago"
				)
				.Execute();

			/*
			exec sp_executesql N'SELECT
				COUNT(*) AS [count],
				LTRIM([dbo].[Address].[City])
			FROM
				[dbo].[Address]
			GROUP BY
				[dbo].[Address].[AddressType],
				LTRIM([dbo].[Address].[City])
			HAVING
				LTRIM([dbo].[Address].[City]) = @P2;',N'@P1 nchar(1),@P2 char(7)',@P1=N'*',@P2='Chicago'
			*/
		}

	}
}
