using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.String
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
            	SOUNDEX([t0].[LastName])
            FROM
            	[dbo].[Person] AS [t0];
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
            	[t0].[Id],
            	[t0].[FirstName],
            	[t0].[LastName],
            	[t0].[BirthDate],
            	[t0].[GenderType],
            	[t0].[CreditLimit],
            	[t0].[YearOfLastCreditLimitReview],
            	[t0].[RegistrationDate],
            	[t0].[LastLoginDate],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [t0]
            WHERE
            	SOUNDEX([t0].[LastName]) <> [t0].[LastName];
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
            	[t0].[Id],
            	[t0].[FirstName],
            	[t0].[LastName],
            	[t0].[BirthDate],
            	[t0].[GenderType],
            	[t0].[CreditLimit],
            	[t0].[YearOfLastCreditLimitReview],
            	[t0].[RegistrationDate],
            	[t0].[LastLoginDate],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [t0]
            ORDER BY
            	SOUNDEX([t0].[LastName]) ASC;
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
            	[t0].[AddressType],
            	SOUNDEX([t0].[City]) AS [city]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType],
            	SOUNDEX([t0].[City]);
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
            	COUNT(*) AS [count],
            	[t0].[AddressType]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType],
            	[t0].[City]
            HAVING
            	SOUNDEX([t0].[City]) = @P1;',N'@P1 varchar(4)',@P1='G452'
            */
        }

    }
}
