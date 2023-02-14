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
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/trim</summary>
	public class Trim : IDocumentationExamples
	{
		private readonly ILogger<Trim> logger;

		public Trim(ILogger<Trim> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Trim_line_no_42();
			Trim_line_no_60();
			Trim_line_no_89();
			Trim_line_no_118();
			Trim_line_no_146();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 42</summary>
		private void Trim_line_no_42()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 42");

			IEnumerable<string> result = db.SelectMany(
					db.fx.Trim(dbo.Person.LastName)
				)
				.From(dbo.Person)
				.Execute();

			/*
			SELECT
				TRIM([dbo].[Person].[LastName])
			FROM
				[dbo].[Person];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 60</summary>
		private void Trim_line_no_60()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 60");

			IEnumerable<Person> result = db.SelectMany<Person>()
			    .From(dbo.Person)
				.Where(db.fx.Trim(dbo.Person.LastName) != dbo.Person.LastName)
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
				TRIM([dbo].[Person].[LastName]) <> [dbo].[Person].[LastName];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 89</summary>
		private void Trim_line_no_89()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 89");

			IEnumerable<Person> result = db.SelectMany<Person>()
				.From(dbo.Person)
				.OrderBy(db.fx.Trim(dbo.Person.LastName))
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
				TRIM([dbo].[Person].[LastName]) ASC;
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 118</summary>
		private void Trim_line_no_118()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 118");

			IEnumerable<dynamic> values = db.SelectMany(
					dbo.Address.AddressType,
					db.fx.Trim(dbo.Address.City).As("city")
				)
				.From(dbo.Address)
				.GroupBy(
					dbo.Address.AddressType,
					db.fx.Trim(dbo.Address.City)
				)
				.Execute();

			/*
			SELECT
				[dbo].[Address].[AddressType],
				TRIM([dbo].[Address].[City]) AS [city]
			FROM
				[dbo].[Address]
			GROUP BY
				[dbo].[Address].[AddressType],
				TRIM([dbo].[Address].[City]);
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 146</summary>
		private void Trim_line_no_146()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/trim at line 146");

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
					db.fx.Trim(dbo.Address.City) == "Los Angeles"
				)
				.Execute();

			/*
			exec sp_executesql N'SELECT
				COUNT(@P1) AS [count],
				[dbo].[Address].[AddressType]
			FROM
				[dbo].[Address]
			GROUP BY
				[dbo].[Address].[AddressType],
				[dbo].[Address].[City]
			HAVING
				TRIM([dbo].[Address].[City]) = @P2;',N'@P1 nchar(1),@P2 char(11)',@P1=N'*',@P2='Los Angeles'
			*/
		}

	}
}
