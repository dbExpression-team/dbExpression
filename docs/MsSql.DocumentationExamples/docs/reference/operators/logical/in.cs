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
	///<summary>Code examples from https://dbexpression.com/docs/reference/operators/logical/in</summary>
	public class In : IDocumentationExamples
	{
		private readonly ILogger<In> logger;

		public In(ILogger<In> logger)
		{
			this.logger = logger;
		}

		public void ExecuteExamples()
		{
			In_line_no_78();
			In_line_no_106();
			In_line_no_135();
			In_line_no_166();
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/in at line 78</summary>
		private void In_line_no_78()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/in at line 78");

			IEnumerable<Person> persons = db.SelectMany<Person>()
			    .From(dbo.Person)
			    .Where(dbo.Person.FirstName.In("Jane", "John", "Mary", "Joe"))
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
				[dbo].[Person].[FirstName] IN (@P1,@P2,@P3,@P4);',N'@P1 varchar(20),@P2 varchar(20),@P3 varchar(20),@P4 varchar(20)',@P1='Jane',@P2='John',@P3='Mary',@P4='Joe'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/in at line 106</summary>
		private void In_line_no_106()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/in at line 106");

			IEnumerable<Person> persons = db.SelectMany<Person>()
			    .From(dbo.Person)
			    .Where(!dbo.Person.FirstName.In("Jane", "John", "Mary", "Joe"))
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
				NOT ([dbo].[Person].[FirstName] IN (@P1,@P2,@P3,@P4));',N'@P1 varchar(20),@P2 varchar(20),@P3 varchar(20),@P4 varchar(20)',@P1='Jane',@P2='John',@P3='Mary',@P4='Joe'
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/in at line 135</summary>
		private void In_line_no_135()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/in at line 135");

			IEnumerable<dynamic> product_counts = db.SelectMany(
			        dbo.Product.ProductCategoryType,
			        db.fx.Count().As("CategoryCount")
			    )
			    .From(dbo.Product)
			    .GroupBy(dbo.Product.ProductCategoryType)
			    .Having(
			        dbo.Product.ProductCategoryType.In(
			            ProductCategoryType.Books,
			            ProductCategoryType.ToysAndGames,
			            ProductCategoryType.Electronics
			        )
			    )
			    .Execute();

			/*
			exec sp_executesql N'SELECT
				[dbo].[Product].[ProductCategoryType],
				COUNT(@P1) AS [CategoryCount]
			FROM
				[dbo].[Product]
			GROUP BY
				[dbo].[Product].[ProductCategoryType]
			HAVING
				[dbo].[Product].[ProductCategoryType] IN (@P2,@P3,@P4);',N'@P1 nchar(1),@P2 int,@P3 int,@P4 int',@P1=N'*',@P2=3,@P3=1,@P4=2
			*/
		}

		///<summary>https://dbexpression.com/docs/reference/operators/logical/in at line 166</summary>
		private void In_line_no_166()
		{
			logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/in at line 166");

			IEnumerable<Person> persons = db.SelectMany<Person>()
			    .From(dbo.Person)
			    .InnerJoin(dbo.PersonAddress).On(
			        dbo.PersonAddress.PersonId.In(1, 12, 14)
			        &
			        dbo.PersonAddress.PersonId == dbo.Person.Id
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
				INNER JOIN [dbo].[Person_Address] ON [dbo].[Person_Address].[PersonId] IN (@P1,@P2,@P3)
				AND
				[dbo].[Person_Address].[PersonId] = [dbo].[Person].[Id];',N'@P1 int,@P2 int,@P3 int',@P1=1,@P2=12,@P3=14
			*/
		}

	}
}
