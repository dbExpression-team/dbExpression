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
	///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/length</summary>
	public class Len : IDocumentationExamples
	{
		private readonly ILogger<Len> logger;

		public Len(ILogger<Len> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Len_line_no_47();
			Len_line_no_65();
			Len_line_no_94();
			Len_line_no_123();
			Len_line_no_150();
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 47</summary>
		private void Len_line_no_47()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 47");

			IEnumerable<long> result = db.SelectMany(
					db.fx.Len(dbo.Person.LastName)
				)
				.From(dbo.Person)
				.Execute();

			/*
			SELECT
				LEN([dbo].[Person].[LastName])
			FROM
				[dbo].[Person];
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 65</summary>
		private void Len_line_no_65()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 65");

			IEnumerable<Person> persons = db.SelectMany<Person>()
				.From(dbo.Person)
				.Where(db.fx.Len(dbo.Person.LastName) > db.fx.Len(dbo.Person.FirstName))
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
				LEN([dbo].[Person].[LastName]) > LEN([dbo].[Person].[FirstName]);
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 94</summary>
		private void Len_line_no_94()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 94");

			IEnumerable<Person> result = db.SelectMany<Person>()
				.From(dbo.Person)
				.OrderBy(db.fx.Len(dbo.Person.LastName).Desc())
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
				LEN([dbo].[Person].[LastName]) DESC;
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 123</summary>
		private void Len_line_no_123()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 123");

			IEnumerable<dynamic> values = db.SelectMany(
					dbo.Address.AddressType,
					db.fx.Len(dbo.Address.City).As("city")
				)
				.From(dbo.Address)
				.GroupBy(
					dbo.Address.AddressType,
					db.fx.Len(dbo.Address.City)
				)
				.Execute();

			/*
			SELECT
				[dbo].[Address].[AddressType],
				LEN([dbo].[Address].[City]) AS [city]
			FROM
				[dbo].[Address]
			GROUP BY
				[dbo].[Address].[AddressType],
				LEN([dbo].[Address].[City]);
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 150</summary>
		private void Len_line_no_150()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 150");

			IEnumerable<dynamic> addresses = db.SelectMany(
					db.fx.Count().As("count"),
					dbo.Address.AddressType,
					dbo.Address.City
				)
				.From(dbo.Address)
				.GroupBy(
					dbo.Address.AddressType,
					dbo.Address.City
				)
				.Having(
					db.fx.Len(dbo.Address.City) == 1
				)
				.Execute();

			/*
			exec sp_executesql N'SELECT
				COUNT(@P1) AS [count],
				[dbo].[Address].[AddressType],
				[dbo].[Address].[City]
			FROM
				[dbo].[Address]
			GROUP BY
				[dbo].[Address].[AddressType],
				[dbo].[Address].[City]
			HAVING
				LEN([dbo].[Address].[City]) = @P2;',N'@P1 nchar(1),@P2 bigint',@P1=N'*',@P2=1
			*/
		}

	}
}
