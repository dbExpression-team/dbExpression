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
            	SOUNDEX([dbo].[Person].[LastName])
            FROM
            	[dbo].[Person];
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
            	SOUNDEX([dbo].[Person].[LastName]) = SOUNDEX([dbo].[Person].[FirstName]);
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
            	SOUNDEX([dbo].[Person].[LastName]) ASC;
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
            	[dbo].[Address].[AddressType],
            	SOUNDEX([dbo].[Address].[City]) AS [city]
            FROM
            	[dbo].[Address]
            GROUP BY
            	[dbo].[Address].[AddressType],
            	SOUNDEX([dbo].[Address].[City]);
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
            	[dbo].[Address].[AddressType]
            FROM
            	[dbo].[Address]
            GROUP BY
            	[dbo].[Address].[AddressType],
            	[dbo].[Address].[City]
            HAVING
            	SOUNDEX([dbo].[Address].[City]) = @P2;',N'@P1 nchar(1),@P2 char(4)',@P1=N'*',@P2='G452'
            */
        }

    }
}
