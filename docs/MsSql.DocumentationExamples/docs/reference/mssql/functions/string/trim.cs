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
            	TRIM([_t0].[LastName])
            FROM
            	[dbo].[Person] AS [_t0];
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
            	[_t0].[Id],
            	[_t0].[FirstName],
            	[_t0].[LastName],
            	[_t0].[BirthDate],
            	[_t0].[GenderType],
            	[_t0].[CreditLimit],
            	[_t0].[YearOfLastCreditLimitReview],
            	[_t0].[RegistrationDate],
            	[_t0].[LastLoginDate],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [_t0]
            WHERE
            	TRIM([_t0].[LastName]) <> [_t0].[LastName];
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
            	[_t0].[Id],
            	[_t0].[FirstName],
            	[_t0].[LastName],
            	[_t0].[BirthDate],
            	[_t0].[GenderType],
            	[_t0].[CreditLimit],
            	[_t0].[YearOfLastCreditLimitReview],
            	[_t0].[RegistrationDate],
            	[_t0].[LastLoginDate],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [_t0]
            ORDER BY
            	TRIM([_t0].[LastName]) ASC;
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
            	[_t0].[AddressType],
            	TRIM([_t0].[City]) AS [city]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	TRIM([_t0].[City]);
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
            	COUNT(*) AS [count],
            	[_t0].[AddressType]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	[_t0].[City]
            HAVING
            	TRIM([_t0].[City]) = @P1;',N'@P1 varchar(11)',@P1='Los Angeles'
            */
        }

    }
}
