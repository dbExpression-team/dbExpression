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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/soundex</summary>
    public class Soundex : IDocumentationExamples
    {
        private readonly ILogger<Soundex> logger;

        public Soundex(ILogger<Soundex> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Soundex_line_no_45();
            Soundex_line_no_63();
            Soundex_line_no_92();
            Soundex_line_no_122();
            Soundex_line_no_150();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 45</summary>
        private void Soundex_line_no_45()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 45");

            IEnumerable<string> result = db.SelectMany(
            		db.fx.Soundex(dbo.Person.LastName)
            	)
            	.From(dbo.Person)
            	.Execute();

            /*
            SELECT
            	SOUNDEX([_t0].[LastName])
            FROM
            	[dbo].[Person] AS [_t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 63</summary>
        private void Soundex_line_no_63()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 63");

            IEnumerable<Person> result = db.SelectMany<Person>()
                .From(dbo.Person)
            	.Where(db.fx.Soundex(dbo.Person.LastName) != dbo.Person.LastName)
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
            	SOUNDEX([_t0].[LastName]) <> [_t0].[LastName];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 92</summary>
        private void Soundex_line_no_92()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 92");

            IEnumerable<Person> result = db.SelectMany<Person>()
            	.From(dbo.Person)
            	.OrderBy(db.fx.Soundex(dbo.Person.LastName))
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
            	SOUNDEX([_t0].[LastName]) ASC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 122</summary>
        private void Soundex_line_no_122()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 122");

            IEnumerable<dynamic> values = db.SelectMany(
            		dbo.Address.AddressType,
            		db.fx.Soundex(dbo.Address.City).As("city")
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		db.fx.Soundex(dbo.Address.City)
            	)
            	.Execute();

            /*
            SELECT
            	[_t0].[AddressType],
            	SOUNDEX([_t0].[City]) AS [city]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	SOUNDEX([_t0].[City]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 150</summary>
        private void Soundex_line_no_150()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/soundex at line 150");

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
            		db.fx.Soundex(dbo.Address.City) == "G452"
            	)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(@P1) AS [count],
            	[_t0].[AddressType]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	[_t0].[City]
            HAVING
            	SOUNDEX([_t0].[City]) = @P2;',N'@P1 nchar(1),@P2 char(4)',@P1=N'*',@P2='G452'
            */
        }

    }
}
