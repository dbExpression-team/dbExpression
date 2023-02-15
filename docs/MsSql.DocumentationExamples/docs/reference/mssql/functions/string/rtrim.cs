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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/rtrim</summary>
    public class RTrim : IDocumentationExamples
    {
        private readonly ILogger<RTrim> logger;

        public RTrim(ILogger<RTrim> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            RTrim_line_no_42();
            RTrim_line_no_60();
            RTrim_line_no_89();
            RTrim_line_no_118();
            RTrim_line_no_146();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 42</summary>
        private void RTrim_line_no_42()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 42");

            IEnumerable<string> result = db.SelectMany(
            		db.fx.RTrim(dbo.Person.LastName)
            	)
            	.From(dbo.Person)
            	.Execute();

            /*
            SELECT
            	RTRIM([dbo].[Person].[LastName])
            FROM
            	[dbo].[Person];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 60</summary>
        private void RTrim_line_no_60()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 60");

            IEnumerable<Person> result = db.SelectMany<Person>()
                .From(dbo.Person)
            	.Where(db.fx.RTrim(dbo.Person.LastName) != dbo.Person.LastName)
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
            	RTRIM([dbo].[Person].[LastName]) <> [dbo].[Person].[LastName];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 89</summary>
        private void RTrim_line_no_89()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 89");

            IEnumerable<Person> result = db.SelectMany<Person>()
            	.From(dbo.Person)
            	.OrderBy(db.fx.RTrim(dbo.Person.LastName))
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
            	RTRIM([dbo].[Person].[LastName]) ASC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 118</summary>
        private void RTrim_line_no_118()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 118");

            IEnumerable<dynamic> values = db.SelectMany(
            		dbo.Address.AddressType,
            		db.fx.RTrim(dbo.Address.City).As("city")
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		db.fx.RTrim(dbo.Address.City)
            	)
            	.Execute();

            /*
            SELECT
            	[dbo].[Address].[AddressType],
            	RTRIM([dbo].[Address].[City]) AS [city]
            FROM
            	[dbo].[Address]
            GROUP BY
            	[dbo].[Address].[AddressType],
            	RTRIM([dbo].[Address].[City]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 146</summary>
        private void RTrim_line_no_146()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 146");

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
            		db.fx.RTrim(dbo.Address.City) == "Los Angeles"
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
            	RTRIM([dbo].[Address].[City]) = @P2;',N'@P1 nchar(1),@P2 char(11)',@P1=N'*',@P2='Los Angeles'
            */
        }

    }
}
