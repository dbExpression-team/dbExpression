using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Operators.Logical
{
	///<summary>Code examples from https://dbexpression.com/docs/reference/operators/logical/like</summary>
	public class Like : IDocumentationExamples
	{
		private readonly ILogger<Like> logger;

		public Like(ILogger<Like> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			Like_line_no_69();
			Like_line_no_97();
			Like_line_no_127();
			Like_line_no_152();
			Like_line_no_187();
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 69</summary>
		private void Like_line_no_69()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 69");

			IEnumerable<Person> persons = db.SelectMany<Person>()
			    .From(dbo.Person)
			    .Where(dbo.Person.FirstName.Like("J%"))
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
			WHERE
				[dbo].[Person].[FirstName] LIKE @P1;',N'@P1 char(2)',@P1='J%'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 97</summary>
		private void Like_line_no_97()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 97");

			IEnumerable<Person> persons = db.SelectMany<Person>()
			    .From(dbo.Person)
			    .Where(!dbo.Person.FirstName.Like("J%"))
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
			WHERE
				NOT ([dbo].[Person].[FirstName] LIKE @P1);',N'@P1 char(2)',@P1='J%'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 127</summary>
		private void Like_line_no_127()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 127");

			IEnumerable<string> product_counts = db.SelectMany(
			        dbo.Product.Name
			    )
			    .From(dbo.Product)
			    .GroupBy(dbo.Product.Name)
			    .Having(dbo.Product.Name.Like("%Book%"))
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Product].[Name]
			FROM
				[dbo].[Product]
			GROUP BY
				[dbo].[Product].[Name]
			HAVING
				[dbo].[Product].[Name] LIKE @P1;',N'@P1 char(6)',@P1='%Book%'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 152</summary>
		private void Like_line_no_152()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 152");

			IEnumerable<Person> persons = db.SelectMany<Person>()
			    .From(dbo.Person)
			    .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
			    .InnerJoin(dbo.Address).On(
			        dbo.Address.Zip.Like("80%")
			        &
			        dbo.PersonAddress.AddressId == dbo.Address.Id
			    )
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
				INNER JOIN [dbo].[Person_Address] ON [dbo].[Person].[Id] = [dbo].[Person_Address].[PersonId]
				INNER JOIN [dbo].[Address] ON [dbo].[Address].[Zip] LIKE @P1
				AND
				[dbo].[Person_Address].[AddressId] = [dbo].[Address].[Id];',N'@P1 char(3)',@P1='80%'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 187</summary>
		private void Like_line_no_187()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 187");

			IEnumerable<Person> persons = db.SelectMany<Person>()
			    .From(dbo.Person)
			    .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
			    .InnerJoin(dbo.Address).On(
			        !dbo.Address.Zip.Like("80%")
			        &
			        dbo.PersonAddress.AddressId == dbo.Address.Id
			    )
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
				INNER JOIN [dbo].[Person_Address] ON [dbo].[Person].[Id] = [dbo].[Person_Address].[PersonId]
				INNER JOIN [dbo].[Address] ON NOT ([dbo].[Address].[Zip] LIKE @P1)
				AND
				[dbo].[Person_Address].[AddressId] = [dbo].[Address].[Id];',N'@P1 char(3)',@P1='80%'
			*/
		}

	}
}
